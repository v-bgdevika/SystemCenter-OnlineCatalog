using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    [Serializable]
    public class MPBDetails
    {
        public Guid VersionIndependentGuid { get; set; }        
        public string Version { get; set; }
        public string SystemName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public InstallMPStatus Status { get; set; }
        public string PublicKeyToken { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MPBDetails()
        {
            this.Version = string.Empty;
            this.SystemName = string.Empty;
            this.DisplayName = string.Empty;
            this.Description = string.Empty;
            this.Status = InstallMPStatus.NONE;
            this.PublicKeyToken = string.Empty;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filePath">string</param>
        public MPBDetails(string filePath):this()
        {
            DiskMpBase mpBase = new DiskBundle(filePath, Common.managementGroup);

            if (null != mpBase)
            {
                SetProperties(mpBase);
            }
        }

        /// <summary>
        /// Set properties from DiskMpBase object
        /// </summary>
        /// <param name="mpBase">DiskMpBase</param>
        private void SetProperties(DiskMpBase mpBase)
        {
            if (InstallMPStatus.INVALID_MANAGEMENT_PACK == mpBase.Status)
            {
                this.Status = mpBase.Status;
                return;
            }

            this.VersionIndependentGuid = mpBase.VersionIndependentGuid;
            this.Version = mpBase.Version.ToString();

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
        }
    }
}
