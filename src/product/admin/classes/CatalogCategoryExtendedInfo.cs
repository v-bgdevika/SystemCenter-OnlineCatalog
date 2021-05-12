//-----------------------------------------------------------------------
// <copyright file="CatalogCategoryExtendedInfo.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the category extended info.
    /// </summary>
    public class CatalogCategoryExtendedInfo
    {
        /// <summary>
        /// This field stores the category id
        /// </summary>
        private int categoryId;

        /// <summary>
        /// This field stores description
        /// </summary>
        private string description;

        /// <summary>
        /// Gets or sets category id
        /// </summary>
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}
