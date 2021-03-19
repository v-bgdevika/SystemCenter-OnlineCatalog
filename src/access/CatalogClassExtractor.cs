//-----------------------------------------------------------------------
// <copyright file="CatalogClassExtractor.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class is used to extract Catalog Management Pack objects from SqlDataReader objects
    /// </summary>
    internal abstract class CatalogClassExtractor
    {
        /// <summary>
        /// The abstract method to extract catalog classes out from sql data reader
        /// </summary>
        /// <param name="reader">Used to pass DB result</param>
        public abstract void Extract(SqlDataReader reader);
    }
}
