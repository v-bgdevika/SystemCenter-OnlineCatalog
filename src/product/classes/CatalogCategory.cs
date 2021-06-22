//-----------------------------------------------------------------------
// <copyright file="CatalogCategory.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    /// <summary>
    /// This class represents a category in the management pack catalog.
    /// </summary>   
    public class CatalogCategory : CatalogItem
    {
        /// <summary>
        /// This field stores the parent category id of a category
        /// </summary>
        private int parentCategoryId;

        /// <summary>
        /// This field stores the display name of the category
        /// </summary>
        private string displayName;

        /// <summary>
        /// This field stores the link to the guide url of the category
        /// </summary>
        private CatalogLink guideUri;

        /// <summary>
        /// Gets or sets ParentCategoryId
        /// </summary>
        public int ParentCategoryId
        {
            get { return this.parentCategoryId; }
            set { this.parentCategoryId = value; }        
        }

        /// <summary>
        /// Gets or sets DisplayName
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        /// <summary>
        /// Gets or sets GuideUri
        /// </summary>
        public CatalogLink GuideUri
        {
            get { return this.guideUri; }
            set { this.guideUri = value; }
        }
    }
}
