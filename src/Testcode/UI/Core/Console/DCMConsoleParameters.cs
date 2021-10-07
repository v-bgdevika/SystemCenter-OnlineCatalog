namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    using System;
    using Maui.Core;
    #endregion

    /// <summary>
    /// Parameters class for DCMConsole constructors.
    /// </summary>
    /// <history>
    /// [BillHodg] 20OCT09 Created
    /// </history>
    public class DCMConsoleAppParameters : AppParameters
    {
        #region Private Members

        /// <summary>
        /// port is the port of the DCM server to connect the console to
        /// this is optional
        /// </summary>
        private string port = "";

        /// <summary>
        /// serverName is the DCM server to connect to
        /// </summary>
        private string serverName = "";

        /// <summary>
        /// loginDomainName: optional login domain name
        /// </summary>
        private string loginDomainName = "";

        /// <summary>
        /// loginUserName: optional login user name
        /// </summary>
        private string loginUserName = "";

        /// <summary>
        /// loginPassword: optional login password
        /// </summary>
        private string loginPassword = "";

        /// <summary>
        /// AppID for this console
        /// </summary>
        private string dcmConsoleAppId = "";

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor - no need in ExePath etc. Inherited classes
        /// from Console set all required properties on parameter objects.
        /// </summary>
        public DCMConsoleAppParameters()
        {
        }

        /// <summary>
        /// Constructor for process ID of existing Console Process
        /// </summary>
        /// <param name="processId">Process Id</param>
        public DCMConsoleAppParameters(int processId)
        {
            this.ProcId = processId;
        }
        
        /// <summary>
        /// Constructor to pass in command-line arguments
        /// </summary>
        /// <param name="arguments">String of Arguments</param>
        public DCMConsoleAppParameters(string arguments)
        {
            this.Arguments = arguments;
        }
        #endregion

        #region Properties

        /// <summary>
        /// ServerName defaults to local server if not set
        /// </summary>
        public string ServerName
        {
            get
            {
                if (this.serverName == "")
                    this.serverName = System.Environment.MachineName;

                return this.serverName;
            }
            set
            {
                this.serverName = value;
            }
        }


        /// <summary>
        /// port defaults to blank string
        /// </summary>
        public string Port
        {
            get
            {
                return this.port;
            }
            set
            {
                this.port = value;
            }
        }

        /// <summary>
        /// the login password will be automatically set for the user name if blank or not set.
        /// </summary>
        public string LoginPassword
        {
            get
            {
                //if there is a user, but no password, get the password
                if (this.loginUserName != "" && this.loginPassword == "")
                    this.loginPassword = Mom.Test.Infrastructure.PasswordManager.GetPassword(loginUserName);

                return this.loginPassword;
            }
            set { this.loginPassword = value; }
        }

        /// <summary>
        /// the login user will default to the current user if blank or not set.
        /// </summary>
        public string LoginUserName
        {
            get
            {
                //if the user isn't set, use the current user
                if (this.loginUserName == "")
                    this.loginUserName = System.Environment.UserName;

                return this.loginUserName;
            }
            set { this.loginUserName = value; }
        }

        /// <summary>
        /// the login domain will default to the current logged in user if blank or not set.
        /// </summary>
        public string LoginDomainName
        {
            get
            {
                if (this.loginDomainName == "")
                    this.loginDomainName = System.Environment.UserDomainName;
                return this.loginDomainName;
            }
            set { this.loginDomainName = value; }
        }

        
        /// <summary>
        /// AppId to use for the DCMConsole. Uses default if not set.
        /// </summary>
        public string DCMConsoleAppId
        {
            get 
            {
                if (this.dcmConsoleAppId == "")
                    this.dcmConsoleAppId = DCMConsole.DefaultDcmConsoleAppId;
                return this.dcmConsoleAppId; 
            }
            set { this.dcmConsoleAppId = value; } 
        }

        #endregion
    }
}