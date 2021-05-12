//-----------------------------------------------------------------------
// <copyright file="CatalogOperation.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------


namespace Microsoft.ManagementPackCatalog.Access
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// This class is the base class for all CatalogOperations. It contains functions to connect to the SqlServer and execute stored procedures.
    /// </summary>
    public abstract class CatalogOperation
    {
        /// <summary>
        /// The array of stored proc parameters.
        /// </summary>
        private Collection<SqlParameter> storedProcParameters;

        /// <summary>
        /// This field stores the catalog class extractor, used to create catalog management pack items.
        /// </summary>
        private string storedProcName;

        /// <summary>
        /// Initializes a new instance of the CatalogOperation class.
        /// </summary>
        /// <param name="storedProcName">The name of the stored procedure this class would invoke.</param>
        protected CatalogOperation(string storedProcName)
        {
            this.storedProcName = storedProcName;
            this.storedProcParameters = new Collection<SqlParameter>();
        }

        /// <summary>
        /// Gets the stored procedure parameters.
        /// </summary>
        protected Collection<SqlParameter> StoredProcParameters
        {
            get { return this.storedProcParameters; }
        }

        /// <summary>
        /// This method executes the stored procedure and returns the result
        /// </summary>
        public void Execute()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["csMain"].ToString()))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = this.storedProcName;
                    foreach (SqlParameter storedProcParameter in this.storedProcParameters)
                    {
                        command.Parameters.Add(storedProcParameter);
                    }

                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        this.ParseResult(reader);
                    }
                }
            }
        }

        /// <summary>
        /// This method parses the data out of SqlDataReader to the desired classes.
        /// </summary>
        /// <param name="reader">SqlDataReader result from execute command</param>
        protected abstract void ParseResult(SqlDataReader reader);
    }
}
