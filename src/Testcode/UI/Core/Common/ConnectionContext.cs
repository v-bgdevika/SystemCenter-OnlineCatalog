//-------------------------------------------------------------------
// <copyright file="ConnectionContext.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//  Reference to the IConnectionContext session used to connect to the server.
// </summary>
//  <history>
//  [a-joelj] 29JUNE10 :  Created
//  </history>
//-------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EnterpriseManagement.Presentation.Security;

namespace Mom.Test.UI.Core.Common
{
    public class ConnectionContext : IConnectionContext
    {

        private IConnectionSession session;

        /// <summary>
        /// Initializes a new instance of the TestConnectionContext class.
        /// </summary>
        public ConnectionContext()
        {
        }

        #region IConnectionContext Members


        /// <summary>
        /// Gets or sets the current connection session
        /// </summary>
        public IConnectionSession Session
        {
            get
            {
                return this.session;
            }

            set
            {
                if (this.session != value)
                {
                    this.session = value;
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
