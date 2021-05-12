using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MSIFile
    {
        public string ProductId { get; set; }
        public string MsiUrl { get; set; }
        private string msiFilePath;
        private string targetInstallDirectory;
        private MPorMPBDetailsInDLC mpOrMPBDetailsInDLC;

        /// <summary>
        /// Dictionary to store each mp file and indicator if it exists in DLC
        /// </summary>
        public Dictionary<MPorMPBDetails, bool> MpOrMpbFiles { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mpOrMPBDetailsInDLC">MPorMPBDetailsInDLC</param>
        private MSIFile(MPorMPBDetailsInDLC mpOrMPBDetailsInDLC)
        {
            this.mpOrMPBDetailsInDLC = mpOrMPBDetailsInDLC;
            this.targetInstallDirectory = Path.GetTempPath() + Path.GetRandomFileName();
            Directory.CreateDirectory(this.targetInstallDirectory);
            this.MpOrMpbFiles = new Dictionary<MPorMPBDetails, bool>();
        }

        /// <summary>
        /// Constructor with msi file path as argument
        /// </summary>
        /// <param name="mpOrMPBDetailsInDLC">MPorMPBDetailsInDLC</param>
        /// <param name="msiUrl">string</param>
        public MSIFile(MPorMPBDetailsInDLC mpOrMPBDetailsInDLC, string msiUrl, string productId):this(mpOrMPBDetailsInDLC)
        {
            this.ProductId = productId;
            this.MsiUrl = msiUrl;
            ProcessMSI();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~MSIFile()
        {
            try
            {
                ClearDirectory(this.targetInstallDirectory);
                Directory.Delete(this.targetInstallDirectory);
            }
            catch(Exception e)
            {
                Common.Exception("Unable to delete MSI directory " + this.targetInstallDirectory);
            }
        }

        /// <summary>
        /// Process MSI file path
        /// </summary>
        private void ProcessMSI()
        {
            DownloadFile downloadFile = new DownloadFile(this.MsiUrl);
            if(DownloadStatus.Failure == downloadFile.Status)
            {
                Common.Exception("Failed to download url " + this.MsiUrl);
                return;
            }

            this.msiFilePath = downloadFile.LocalPath;
            UnInstallMSI();
            InstallMSI();
            ParseDirectory(this.targetInstallDirectory);
            UnInstallMSI();
        }

        /// <summary>
        /// Install MSI file
        /// </summary>
        private void InstallMSI()
        {
            string arguments = string.Format("/c msiexec.exe /a \"" + this.msiFilePath + "\" /qn TARGETDIR=" + this.targetInstallDirectory);
            string error = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            try
            {
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = arguments;
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process p = Process.Start(startInfo);
                p.WaitForExit();
            }
            catch (Exception)
            {
                Common.Exception("Error in installing MSI file " + this.msiFilePath);
            }
        }

        /// <summary>
        /// Uninstalls MSI file
        /// </summary>
        private void UnInstallMSI()
        {
            string arguments = string.Format("/c msiexec.exe /x \"" + this.msiFilePath + "\" /qn");
            string error = string.Empty;
            ProcessStartInfo startInfo = new ProcessStartInfo();
            try
            {
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = arguments;
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process p = Process.Start(startInfo);
                p.WaitForExit();
            }
            catch (Exception)
            {
                Common.Exception("Error in uninstalling MSI file " + this.msiFilePath);
            }
        }

        /// <summary>
        /// Clears directory deleting all files and folders inside it
        /// </summary>
        /// <param name="path">string</param>
        private void ClearDirectory(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            foreach(FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            foreach(DirectoryInfo subDirectory in directory.GetDirectories())
            {
                ClearDirectory(subDirectory.FullName);
                subDirectory.Delete();
            }
        }

        /// <summary>
        /// Process directory for MP and MPB files
        /// </summary>
        /// <param name="directory">string</param>
        private void ParseDirectory(string directory)
        {
            DiskMpBase mpBase = null;
            MPorMPBDetails mpOrMPBDetails = null;

            foreach (string file in Directory.GetFiles(directory))
            {
                if(file.EndsWith(".mp", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".mpb", StringComparison.OrdinalIgnoreCase))
                {
                    mpOrMPBDetails = new MPorMPBDetails(file);
                    MpOrMpbFiles.Add(mpOrMPBDetails, ExistsInDLC(mpOrMPBDetails));
                }
            }

            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                ParseDirectory(subDirectory);
            }
        }

        /// <summary>
        /// Checks MP existence in DLC
        /// </summary>
        /// <param name="mpOrMPBDetails">MPorMPBDetails</param>
        /// <returns>bool</returns>
        private bool ExistsInDLC(MPorMPBDetails mpOrMPBDetails)
        {
            return this.mpOrMPBDetailsInDLC.Contains(mpOrMPBDetails);
        }

        /// <summary>
        /// Checks all MPs in MSI exists in DLC
        /// </summary>
        /// <returns></returns>
        public bool ExistsInDLC()
        {
            return !(this.MpOrMpbFiles.Values.Contains(false));
        }

        /// <summary>
        /// List of MP/MPB not present in DLC
        /// </summary>
        /// <returns>List<MPorMPBDetails></returns>
        public List<MPorMPBDetails> GetMPorMPBDetailsNotInDLC()
        {
            List<MPorMPBDetails> mpOrMPBDetailsNotInDLC = new List<MPorMPBDetails>();

            foreach (MPorMPBDetails mpOrMPBDetails in this.MpOrMpbFiles.Keys)
            {
                if(!this.MpOrMpbFiles[mpOrMPBDetails])
                {
                    mpOrMPBDetailsNotInDLC.Add(mpOrMPBDetails);
                }
            }

            return mpOrMPBDetailsNotInDLC;
        }


        /// <summary>
        /// List of MP/MPB present in DLC
        /// </summary>
        /// <returns>List<MPorMPBDetails></returns>
        public List<MPorMPBDetails> GetMPorMPBDetailsInDLC()
        {
            List<MPorMPBDetails> mpOrMPBDetailsInDLC = new List<MPorMPBDetails>();

            foreach (MPorMPBDetails mpOrMPBDetails in this.MpOrMpbFiles.Keys)
            {
                if (this.MpOrMpbFiles[mpOrMPBDetails])
                {
                    mpOrMPBDetailsInDLC.Add(mpOrMPBDetails);
                }
            }

            return mpOrMPBDetailsInDLC;
        }
    }
}
