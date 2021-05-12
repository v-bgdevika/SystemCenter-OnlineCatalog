//-----------------------------------------------------------------------
// <copyright file="CatalogManagementPackExtendedInfo.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Admin.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class represents the management pack extended info.
    /// </summary>
    public class CatalogManagementPackExtendedInfo
    {
        /// <summary>
        /// This field stores the management pack id
        /// </summary>
        private int managementPackId;

        /// <summary>
        /// This field stores description
        /// </summary>
        private string description;

        /// <summary>
        /// This field stores the knowledge
        /// </summary>
        private string knowledge;

        /// <summary>
        /// This field stores the special EULA.
        /// </summary>
        private string eula;

        /// <summary>
        /// Gets or sets management pack id
        /// </summary>
        public int ManagmentPackId
        {
            get { return this.managementPackId; }
            set { this.managementPackId = value; }
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the knowledge
        /// </summary>
        public string Knowledge
        {
            get { return this.knowledge; }
            set { this.knowledge = value; }
        }

        /// <summary>
        /// Gets or sets the eula
        /// </summary>
        public string Eula
        {
            get { return this.eula; }
            set { this.eula = value; }
        }
    }
}
