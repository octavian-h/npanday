/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

package npanday.plugin.azure;

import npanday.ArtifactType;
import npanday.PathUtil;
import org.apache.maven.artifact.Artifact;
import org.apache.maven.plugin.MojoExecutionException;
import org.apache.maven.plugin.MojoFailureException;
import org.codehaus.plexus.archiver.ArchiverException;
import org.codehaus.plexus.archiver.zip.ZipUnArchiver;

import java.io.File;
import java.util.Set;

/**
 * @author <a href="mailto:lcorneliussen@apache.org">Lars Corneliussen</a>
 * @goal resolve-worker-roles
 * @requiresDependencyResolution runtime
 */
public class ResolveWorkerRoleFilesMojo
    extends AbstractNPandayMojo
{
    /**
     * The Zip archiver.
     *
     * @parameter expression="${component.org.codehaus.plexus.archiver.UnArchiver#zip}"
     * @required
     */
    private ZipUnArchiver unarchiver;

    public void execute() throws MojoExecutionException, MojoFailureException
    {
        // TODO: this mojo could be moved to application-maven-plugin / unpack-dependencies (as with msdeploy)
        super.execute();

        final Set projectDependencyArtifacts = project.getDependencyArtifacts();
        for ( Object artifactAsObject : projectDependencyArtifacts )
        {
            Artifact artifact = (Artifact) artifactAsObject;
            if ( artifact.getType().equals( ArtifactType.DOTNET_APPLICATION.getPackagingType() )
                || artifact.getType().equals( ArtifactType.DOTNET_APPLICATION.getExtension() ) )
            {
                unpack( artifact );
            }
        }
    }

    private void unpack( Artifact artifact ) throws MojoFailureException
    {
        // TODO: partially duplicate code with MSDeploy unpack-dependencies
        File targetDirectory = new File( PathUtil.getPreparedPackageFolder( project ), artifact.getArtifactId() );
        try
        {
            if ( !artifact.isResolved() )
            {
                throw new MojoFailureException(
                    "NPANDAY-131-000: The artifact should already have been resolved: " + artifact
                );
            }

            final File packageSource = artifact.getFile();
            assert packageSource != null : "package source should not be null here";
            getLog().info(
                "NPANDAY-131-002: Unpacking worker role " + artifact.getArtifactId() + " from " + packageSource + " "
                    + "to " + targetDirectory
            );

            // unarchiver expects the dir to be there
            targetDirectory.mkdirs();

            unarchiver.setSourceFile( packageSource );
            unarchiver.setDestDirectory( targetDirectory );
            unarchiver.extract();

            if ( targetDirectory.listFiles().length == 0 )
            {
                throw new MojoFailureException(
                    "NPANDAY-131-003: Wasn't able to unpack worker role " + artifact.getArtifactId()
                );
            }
        }
        catch ( ArchiverException e )
        {
            throw new MojoFailureException(
                "NPANDAY-131-001: Unable to unpack worker role from artifact: " + artifact
            );
        }
    }
}
