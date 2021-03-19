//-----------------------------------------------------------------------
// <copyright file="CatalogCategory.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the category.
    /// </summary>
    public class CatalogCategory
    {
        /// <summary>
        /// This field stores the category id
        /// </summary>
        private int categoryId;


        /// <summary>
        /// This field stores display name
        /// </summary>
        private string displayName;

        /// <summary>
        /// This field stores guide uri text
        /// </summary>
        private string guideUriText;

        /// <summary>
        /// This field stores guide uri link
        /// </summary>
        private string guideUriLink;

        /// <summary>
        /// This field stores parent category id.
        /// </summary>
        private int parentCategoryId;

        /// <summary>
        /// This field stores the published indicator.
        /// </summary>
        private bool publishedInd;

        /// <summary>
        /// Gets or sets category id
        /// </summary>
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; }
        }

        /// <summary>
        /// Gets or sets the guide uri text
        /// </summary>
        public string GuideUriText
        {
            get { return this.guideUriText; }
            set { this.guideUriText = value; }
        }
        
        /// <summary>
        /// Gets or sets the guide uri link
        /// </summary>
        public string GuideUriLink
        {
            get { return this.guideUriLink; }
            set { this.guideUriLink = value; }
        }

        /// <summary>
        /// Gets or sets the parent category id
        /// </summary>
        public int ParentCategoryId
        {
            get { return this.parentCategoryId; }
            set { this.parentCategoryId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether category is published or not
        /// </summary>
        public bool PublishedInd
        {
            get { return this.publishedInd; }
            set { this.publishedInd = value; }
        }
    }
}
