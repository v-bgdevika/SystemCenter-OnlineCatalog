using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class CatalogCategoryDetails
    {
        public int CatalogItemId { get; set; }
        public string Name { get; set; }
        public int LanguageCatalogItemId { get; set; }
        public MPLanguage Language { get; set; }
        public int MpCatalogItemId { get; set; }
        public Guid VersionIndependentGuid { get; set; }
        public Version Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="catalogItemId">int</param>
        /// <param name="name">string</param>
        /// <param name="languageCatalogItemId">int</param>
        /// <param name="language">MPLanguage</param>
        /// <param name="mpCatalogItemId">int</param>
        /// <param name="versionIndependentGuid">Guid</param>
        /// <param name="version">Version</param>
        public CatalogCategoryDetails(int catalogItemId, string name, int languageCatalogItemId, MPLanguage language, int mpCatalogItemId, Guid versionIndependentGuid, Version version)
        {
            this.CatalogItemId = catalogItemId;
            this.Name = name;
            this.LanguageCatalogItemId = languageCatalogItemId;
            this.Language = language;
            this.MpCatalogItemId = mpCatalogItemId;
            this.VersionIndependentGuid = versionIndependentGuid;
            this.Version = version;
        }
    }
}
