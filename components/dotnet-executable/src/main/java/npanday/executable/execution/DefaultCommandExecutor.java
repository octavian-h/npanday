package npanday.executable.execution;

import npanday.PathUtil;
import npanday.executable.CommandExecutor;
import npanday.executable.ExecutionException;
import org.codehaus.plexus.logging.Logger;
import org.codehaus.plexus.util.cli.CommandLineException;
import org.codehaus.plexus.util.cli.CommandLineUtils;
import org.codehaus.plexus.util.cli.Commandline;
import org.codehaus.plexus.util.cli.StreamConsumer;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

/**
 * @author Shane Isbell
 * @author <a href="mailto:lcorneliussen@apache.org">Lars Corneliussen</a>
 */
public class DefaultCommandExecutor
    implements CommandExecutor
{
    /**
     * Instance of a plugin logger.
     */
    private Logger logger;

    /**
     * Standard Out
     */
    private StreamConsumer stdOut;

    /**
     * Standard Error
     */
    private ErrorStreamConsumer stdErr;

    /**
     * Process result
     */
    private int result;

    public void setLogger( Logger logger )
    {
        this.logger = logger;
    }

    public void executeCommand( String executable, List<String> commands ) throws ExecutionException
    {
        executeCommand( executable, commands, null, true );
    }

    public void executeCommand( String executable, List<String> commands, boolean failsOnErrorOutput ) throws
        ExecutionException
    {
        executeCommand( executable, commands, null, failsOnErrorOutput );
    }

    public void executeCommand(
        String executable, List<String> commands, File workingDirectory, boolean failsOnErrorOutput ) throws
        ExecutionException
    {
        if ( commands == null )
        {
            commands = new ArrayList<String>();
        }
        stdOut = new StandardStreamConsumer( logger );
        stdErr = new ErrorStreamConsumer( logger );

        Commandline commandline = new CustomCommandline();

        // NPANDAY-409
        // On non-Windows platforms, such as Linux, "gmcs" not resolved
        // to gmcs.exe in working directory due to /usr/bin/gmcs
        // but "./gmcs.exe" resolved as desired in working directory
        String osName = System.getProperty( "os.name" );
        if ( !osName.toLowerCase().contains( "win" ) )
        {
            File executableFile = PathUtil.getExecutable( workingDirectory, executable );
            // do not prefix for internal commands, such as mkdir
            if ( executableFile != null && workingDirectory.equals( executableFile.getParentFile() ) )
            {
                executable = new File( "./", executableFile.getName() ).toString();
            }
        }

        commandline.setExecutable( executable );
        commandline.addArguments( commands.toArray( new String[commands.size()] ) );

        if ( workingDirectory != null && workingDirectory.exists() )
        {
            // TODO: Wrong use of working directory! $(basedir) should be the working dir,
            // and the executable paths should be absolute
            commandline.setWorkingDirectory( workingDirectory.getAbsolutePath() );
        }
        else if ( workingDirectory != null && !workingDirectory.exists() )
        {
            logger.info(
                "NPANDAY-040-006: Did not find executable path for " + executable + ", " + "will try system path"
            );
        }

        try
        {
            result = CommandLineUtils.executeCommandLine( commandline, stdOut, stdErr );
            if ( logger != null )
            {
                logger.debug(
                    "NPANDAY-040-005: Executed command: Commandline = " + commandline + ", Result = " + result
                );
            }
            else
            {
                System.out.println(
                    "NPANDAY-040-004: Executed command: Commandline = " + commandline + ", Result = " + result
                );
            }
            if ( ( failsOnErrorOutput && stdErr.hasError() ) || result != 0 )
            {
                throw new ExecutionException(
                    "NPANDAY-040-001: Could not execute: Command = " + commandline.toString() + ", Result = " + result
                );
            }
        }
        catch ( CommandLineException e )
        {
            throw new ExecutionException(
                "NPANDAY-040-002: Could not execute: Command = " + commandline.toString(), e
            );
        }
    }

    public int getResult()
    {
        return result;
    }

    public String getStandardOut()
    {
        return stdOut.toString();
    }

    public String getStandardError()
    {
        return stdErr.toString();
    }

}
