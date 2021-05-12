using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DLC_OCSync
{
    public class MPorMPBDetails
    {
        public string FileName { get; private set; }
        public Guid VersionIndependentGuid { get; private set; }
        public Version Version { get; private set; }
        public string SystemName { get; private set; }
        public string PublicKeyToken { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public InstallMPStatus Status { get; private set; }
        public List<MPIdentity> Dependencies { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private MPorMPBDetails()
        {
            this.SystemName = string.Empty;
            this.PublicKeyToken = string.Empty;
            this.DisplayName = string.Empty;
            this.Description = string.Empty;
            this.Status = InstallMPStatus.NONE;
            this.Dependencies = new List<MPIdentity>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        /// <param name="systemName">string</param>
        /// <param name="publicKeyToken">string</param>
        /// <param name="displayName">string</param>
        /// <param name="description">string</param>
        public MPorMPBDetails(Guid versionIndependentGuid, Version version, string systemName, string publicKeyToken, string displayName, string description) : this()
        {
            this.VersionIndependentGuid = versionIndependentGuid;
            this.Version = version;

            if (null != systemName)
            {
                this.SystemName = systemName;
            }

            if(null != publicKeyToken)
            {
                this.PublicKeyToken = publicKeyToken;
            }

            if (null != displayName)
            {
                this.DisplayName = displayName;
            }

            if (null != description)
            {
                this.Description = description;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mpBase">DiskMpBase</param>
        public MPorMPBDetails(DiskMpBase mpBase) : this()
        {
            SetProperties(mpBase);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="localFilePath">string</param>
        public MPorMPBDetails(string localFilePath):this()
        {
            DiskMpBase mpBase = null;

            this.FileName = Path.GetFileName(localFilePath);

            if (localFilePath.EndsWith(".mp", StringComparison.OrdinalIgnoreCase))
            {
                mpBase = new DiskMP(localFilePath);
                if (null != mpBase)
                {
                    SetProperties(mpBase);
                }
            }
            else if (localFilePath.EndsWith(".mpb", StringComparison.OrdinalIgnoreCase))
            {
                ProcessMPB(localFilePath);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">string</param>
        /// <param name="managementGroup">ManagementGroup</param>
        public MPorMPBDetails(string filePath, ManagementGroup managementGroup):this()
        {
            DiskMpBase mpBase = null;

            this.FileName = Path.GetFileName(filePath);

            if (filePath.EndsWith(".mp", StringComparison.OrdinalIgnoreCase))
            {
                mpBase = new DiskMP(filePath);
                if (null != mpBase)
                {
                    SetProperties(mpBase);
                }
            }
            else if (filePath.EndsWith(".mpb", StringComparison.OrdinalIgnoreCase))
            {
                ProcessMPB(filePath);
            }
        }

        /// <summary>
        /// Set properties from DiskMpBase object
        /// </summary>
        /// <param name="mpBase">DiskMpBase</param>
        private void SetProperties(DiskMpBase mpBase)
        {
            if(InstallMPStatus.INVALID_MANAGEMENT_PACK == mpBase.Status)
            {
                this.Status = mpBase.Status;
                return;
            }

            this.VersionIndependentGuid = mpBase.VersionIndependentGuid;
            this.Version = mpBase.Version;

            if (null != mpBase.SystemName)
            {
                this.SystemName = mpBase.SystemName;
            }
            
            if(null != mpBase.PublicKey)
            {
                this.PublicKeyToken = mpBase.PublicKey;
            }

            if (null != mpBase.DisplayName)
            {
                this.DisplayName = mpBase.DisplayName;
            }

            if (null != mpBase.Description)
            {
                this.Description = mpBase.Description;
            }

            this.Dependencies = mpBase.Dependencies.ToList();
        }

        /// <summary>
        /// Set properties
        /// </summary>
        /// <param name="mpbDetails">MPBDetails</param>
        private void SetProperties(MPBDetails mpbDetails)
        {
            if (InstallMPStatus.INVALID_MANAGEMENT_PACK == mpbDetails.Status)
            {
                this.Status = mpbDetails.Status;
                return;
            }

            this.VersionIndependentGuid = mpbDetails.VersionIndependentGuid;
            this.Version = new Version(mpbDetails.Version);

            if (null != mpbDetails.SystemName)
            {
                this.SystemName = mpbDetails.SystemName;
            }

            if(null != mpbDetails.PublicKeyToken)
            {
                this.PublicKeyToken = mpbDetails.PublicKeyToken;
            }

            if (null != mpbDetails.DisplayName)
            {
                this.DisplayName = mpbDetails.DisplayName;
            }

            if (null != mpbDetails.Description)
            {
                this.Description = mpbDetails.Description;
            }
        }

        /// <summary>
        /// Checks for equality but does not considers dependencies
        /// </summary>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        /// <returns>bool</returns>
        public bool EqualsWithoutDependencies(MPorMPBDetails mpOrMPBDetails)
        {
            if( this.VersionIndependentGuid == mpOrMPBDetails.VersionIndependentGuid
                && this.Version == mpOrMPBDetails.Version
                && this.SystemName == mpOrMPBDetails.SystemName
                && this.DisplayName == mpOrMPBDetails.DisplayName
                && this.Description == mpOrMPBDetails.Description
                && this.PublicKeyToken == mpOrMPBDetails.PublicKeyToken)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Process MPB file.
        /// </summary>
        /// <param name="filePath">string</param>
        private void ProcessMPB(string filePath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\ProcessMPBFile.exe";
            startInfo.Arguments = "\"" + filePath + "\"";
            var proc = Process.Start(startInfo);
            proc.Close();
            Thread.Sleep(20 * 1000);

            string xmlFilePath = filePath + ".xml";
            MPBDetails mpbDetails = ProcessMPBXml(xmlFilePath);
            if (mpbDetails != null)
            {
                SetProperties(mpbDetails);
            }

            File.Delete(xmlFilePath);
        }

        /// <summary>
        /// Process xml file containing MPB information.
        /// </summary>
        /// <param name="xmlFilePath">string</param>
        /// <returns>MPBDetails</returns>
        private MPBDetails ProcessMPBXml(string xmlFilePath)
        {
            TextReader reader = null;

            try
            {
                var serializer = new XmlSerializer(typeof(MPBDetails));
                reader = new StreamReader(xmlFilePath);
                return (MPBDetails)serializer.Deserialize(reader);
            }
            catch (FileNotFoundException ex)
            {
                Common.Exception(ex.Message);
                return null;
            }
            finally
            {
                if (null != reader)
                {
                    reader.Close();
                }
            }
        }
    }
}
