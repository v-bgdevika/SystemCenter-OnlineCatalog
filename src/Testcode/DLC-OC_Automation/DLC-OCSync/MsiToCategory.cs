using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MsiToCategory
    {
        public string ProductId { get; set; }
        public string MsiUrl { get; set; }
        public string CatalogItemId { get; set; }
        public string CategoryName { get; set; }
        public string LanguageId { get; set; }
        public string Language { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productId">string</param>
        /// <param name="msiUrl">string</param>
        /// <param name="catalogItemId">string</param>
        /// <param name="categoryName">string</param>
        /// <param name="languageId">string</param>
        /// <param name="language">string</param>
        public MsiToCategory(string productId, string msiUrl, string catalogItemId, string categoryName, string languageId, string language)
        {
            this.ProductId = productId;
            this.MsiUrl = msiUrl;
            this.CatalogItemId = catalogItemId;
            this.CategoryName = categoryName;
            this.LanguageId = languageId;
            this.Language = language;
        }
    }
}
