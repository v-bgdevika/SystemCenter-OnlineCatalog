namespace Mom.Test.UI.Core.Console.SharePoint
{

    /// <summary>
    /// Name, req
    /// HostUri, req
    /// HostEncryptionKey
    /// Source (ClientBin/DashboardViewer.xap)
    /// ManagementServer, req
    /// </summary>
    public class WebPartConfigurationParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public WebPartConfigurationParameters()
        {

        }

        public string Title
        {
            get;
            set;
        }

        public string HostUri
        {
            get;
            set;
        }

        public string ManagementServer
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public string HostErrorTimeout
        {
            get;
            set;
        }

        public string SilverlightUrl
        {
            get;
            set;
        }

        public string DashboardParameters
        {
            get;
            set;
        }

        public string TargetApplicationID
        {
            get;
            set;
        }

        public string EncryptionAlgorithm
        {
            get;
            set;
        }

        public string EncryptionAlgorithmKey
        {
            get;
            set;
        }

        public string EncryptionValidationAlgorithm
        {
            get;
            set;
        }

        public string EncryptionValidationAlgorithmKey
        {
            get;
            set;
        }

        public string IVGenerationAlgorithm
        {
            get;
            set;
        }
    }
}
