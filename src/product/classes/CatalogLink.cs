//-----------------------------------------------------------------------
// <copyright file="CatalogLink.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used to store Uri links along with their display text.
    /// </summary>
    public class CatalogLink
    {
        /// <summary>
        /// This field stores the link to the uri
        /// </summary>
        private string displayLink;

        /// <summary>
        /// This field stores the display text for the uri
        /// </summary>
        private string displayText;

        /// <summary>
        /// Gets or sets the display link for the uri
        /// </summary>
        public string DisplayLink
        {
            get { return this.displayLink; }
            set { this.displayLink = value; }
        }

        /// <summary>
        /// Gets or sets the display text for the uri
        /// </summary>
        public string DisplayText
        {
            get { return this.displayText; }
            set { this.displayText = value; }
        }
    }
}
