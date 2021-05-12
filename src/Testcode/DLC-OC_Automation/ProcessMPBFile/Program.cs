using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Administration.MPDownloadAndInstall.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DLC_OCSync;

namespace ProcessMPBFile
{
    class Program
    {
        static string FilePath;
        static string OutputFilePath;

        static void Main(string[] args)
        {
            if (0 < args.Count())
            {
                FilePath = args[0];

                //if (1 < args.Count())
                //{
                //    OutputFilePath = args[1];
                //}
                //FilePath = "D:\\Microsoft.SQLServer.Visualization.Library.mpb";

                if (!string.IsNullOrEmpty(FilePath) && FilePath.EndsWith(".mpb", StringComparison.OrdinalIgnoreCase))
                {
                    Common.ConnectManagementGroup();
                    Console.WriteLine("Processing MPB File @ " + FilePath);
                    Process();
                }
            }

            //Console.WriteLine("Complete.");
            //Console.ReadKey();
        }

        /// <summary>
        /// Process MPB file to generate xml file.
        /// </summary>
        private static void Process()
        {
            if(string.IsNullOrEmpty(OutputFilePath))
            {
                OutputFilePath = FilePath + ".xml";
            }

            MPBDetails mpbDetails = new MPBDetails(FilePath);
            WriteToXmlFile(mpbDetails);
        }

        /// <summary>
        /// Convert MPBDetails object to xml file.
        /// </summary>
        /// <param name="mpbDetails">MPBDetails</param>
        private static void WriteToXmlFile(MPBDetails mpbDetails)
        {
            Console.WriteLine("Writing object to XML file ..");
            TextWriter writer = null;

            try
            {
                var serializer = new XmlSerializer(typeof(MPBDetails));
                writer = new StreamWriter(OutputFilePath, false);
                serializer.Serialize(writer, mpbDetails);
            }
            finally
            {
                if(null != writer)
                {
                    writer.Close();
                }
            }
        }
    }
}
