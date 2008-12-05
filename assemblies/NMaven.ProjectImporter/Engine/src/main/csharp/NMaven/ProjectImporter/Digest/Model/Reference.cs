using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using NMaven.Utils;
using System.Reflection;

/// Author: Leopoldo Lee Agdeppa III

namespace NMaven.ProjectImporter.Digest.Model
{

    public class Reference : IncludeBase
    {

        #region Constructors

        public Reference(string projectBasePath, GacUtility gac) 
            : base(projectBasePath)
        {
            this.gac = gac;
        }

        #endregion

        #region Properties

        private GacUtility gac; 
        public GacUtility GacUtility
        {
            get 
            {
                if (gac == null)
                {
                    gac = new GacUtility();
                }
 
                return gac; 
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string hintPath;
        public string HintPath
        {
            get { return hintPath; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                hintPath = value; 
                SetReferenceFromFile(value); 
            }
        }

        public string HintFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(hintPath))
                {
                    return null;
                }
                else if (Path.IsPathRooted(hintPath))
                {
                    return Path.GetFullPath(hintPath);
                }
                else
                {
                    return Path.GetFullPath(Path.Combine(projectBasePath, hintPath));
                }

            }
        }

        public string AssemblyInfo
        {
            set
            {
                if (value.Split(',').Length > 1)
                {
                    SetAssemblyInfoValues(value);
                }
                else
                {
                    SetAssemblyValuesFromGac(value);
                }
            }
        }

        private string version;
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string publicKeyToken;
        public string PublicKeyToken
        {
            get { return publicKeyToken; }
            set { publicKeyToken = value; }
        }

        private string culture;
        public string Culture
        {
            get { return culture; }
            set { culture = value; }
        }

        private string processorArchitecture;
        public string ProcessorArchitecture
        {
            get { return processorArchitecture; }
            set { processorArchitecture = value; }
        }

        #endregion


        #region HelperMethods

        private void SetReferenceFromFile(string dll)
        {
            if (string.IsNullOrEmpty(dll))
            {
                return;
            }
            SetReferenceFromFile(new FileInfo(dll));
        }


        private void SetReferenceFromFile(FileInfo dll)
        {
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(dll.FullName);
            SetAssemblyInfoValues(asm.ToString());
        }


        private void SetAssemblyInfoValues(string assemblyInfo)
        {
            if (!string.IsNullOrEmpty(assemblyInfo))
            {
                string[] referenceValues = assemblyInfo.Split(',');
                this.Name = referenceValues[0].Trim();

                if (referenceValues.Length > 1)
                {
                    for (int i = 1; i < referenceValues.Length; i++)
                    {
                        if (referenceValues[i].Contains("Version="))
                        {
                            this.Version = referenceValues[i].Replace("Version=", "").Trim();
                        }
                        else if (referenceValues[i].Contains("PublicKeyToken="))
                        {
                            this.PublicKeyToken = referenceValues[i].Replace("PublicKeyToken=", "").Trim();
                        }
                        else if (referenceValues[i].Contains("Culture="))
                        {
                            this.Culture = referenceValues[i].Replace("Culture=", "").Trim();
                        }
                        else if (referenceValues[i].Contains("processorArchitecture="))
                        {
                            this.ProcessorArchitecture = referenceValues[i].Replace("processorArchitecture=", "").Trim();
                        }
                    }
                }

            }

        }



        private void SetAssemblyValuesFromGac(string name)
        {
            this.Name = name.Split(',')[0].Trim();
            string str = GacUtility.GetAssemblyInfo(this.Name);
            SetAssemblyInfoValues(str);
        }

        #endregion






    }
}