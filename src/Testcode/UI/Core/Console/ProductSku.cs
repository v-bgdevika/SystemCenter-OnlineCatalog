//-------------------------------------------------------------------
// <copyright file="ProductSku.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Product Sku definition.
// </summary>
//  <history>
//  [mbickle] 01JUN05:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Maui.Core;
    using Maui.Core.Utilities;
    using Mom.Test.UI.Core.Common;
    #endregion

    /// <summary>
    /// MOM Product Skus.
    /// </summary>
    public enum ProductSkuLevel
    {
        /// <summary>
        /// Unknown Sku
        /// </summary>
        Unknown,
        
        /// <summary>
        /// Operations Manager Sku
        /// </summary>
        Mom,

        /// <summary>
        /// OM Web Console
        /// </summary>
        Web,

        /// <summary>
        /// OM SharePoint WebPart
        /// </summary>
        SharePoint
    }
    
    /// <summary>
    /// ProductSku Class
    /// </summary>
    public class ProductSku
    {
        #region Member variables
        /// <summary>
        /// Cached Product Sku information.
        /// </summary>
        private static ProductSkuLevel cachedProductSku = ProductSkuLevel.Unknown; // Product Sku
        #endregion

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property to return the MOM Product Sku.
        /// </summary>
        /// <history>
        ///     [mbickle] 13JUL05 Created
        /// </history>
        /// ------------------------------------------------------------------
        public static ProductSkuLevel Sku
        {
            get
            {
                string momConsolePath = Utilities.MomPathConsole + Constants.MomConsoleExe;

                if (cachedProductSku == ProductSkuLevel.Unknown)
                {
                    if (System.IO.File.Exists(momConsolePath))
                    {
                        // MOM is installed
                        cachedProductSku = ProductSkuLevel.Mom;
                    }
                    else
                    {
                        //Unfortunately we don't really have a way of detecting the web or sharepoint UI's

                        // Unknown
                        cachedProductSku = ProductSkuLevel.Unknown;
                    }
                }

                return cachedProductSku;
            }

            set
            {
                cachedProductSku = value;
            }
        }

        /// <summary>
        /// Returns the Product Sku Console Exe name.
        /// </summary>
        public static String SkuExe
        {
            get
            {
                ProductSkuLevel sku = Sku;
                string productExe = null;

                switch (sku)
                {
                    case ProductSkuLevel.Mom:
                        productExe = Constants.MomConsoleExe;
                        break;
                    
                    case ProductSkuLevel.Web:
                        // Only supporting IE at this time... We have a bunch of other updates that would
                        // need to be made in order to support any browser other than IE. This would be 
                        // another necessary update.
                        productExe = Constants.InternetExplorerExe;
                        break;
                    
                    default:
                        productExe = null;
                        break;
                }

                return productExe;
            }
        }
   }
}
