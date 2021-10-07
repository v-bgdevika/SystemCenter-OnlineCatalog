namespace Mom.Test.UI.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Infra.Frmwrk;
    using MOM.Test.DB.Utilities;
    using Mom.Test.UI.Core.Common;

    public partial class DashboardHarness
    {

        private static Dictionary <string,string> groupCheckPointDBs = new Dictionary <string,string>(2);

        /// <summary>
        /// Backup the DB or DW to the current directory
        /// </summary>
        /// <param name="db">DB or DW</param>
        /// <param name="backupName">used as both the device and backup filename so don't include spaces or special chars</param>
        public static void Backup(string db, string backupName)
        {
            ConnectToDB(db);
            try
            {
                DBUtil.BackupDatabase(DBUtil.MOMDBInstanceName, DBUtil.MOMDBName,
                Directory.GetCurrentDirectory(), backupName, DashboardHarness.Context);
            }
            catch (Exception e)
            {
                if (DashboardHarness.Context is IGroupContext)
                {
                    throw new GroupAbort("Backup Failed", e);
                }
                else
                {
                    throw new VarAbort("Backup Failed", e);
                }
            }
        }

        /// <summary>
        /// Restore DB ore DW
        /// </summary>
        /// <param name="db">DB or DW</param>
        /// <param name="backupName">backup device name, don't include spaces or special chars</param>
        public static void Restore(string db, string backupName)
        {
            ConnectToDB(db);
            try
            {
                DBUtil.RestoreDatabase(DBUtil.MOMDBInstanceName, DBUtil.MOMDBName,
                backupName, DashboardHarness.Context);
            }
            catch (Exception e)
            {
                if (DashboardHarness.Context is IGroupContext)
                {
                    throw new GroupAbort("Restore Failed", e);
                }
                else
                {
                    throw new VarAbort("Restore Failed", e);
                }
            }
        }

        public static void CheckPoint(string db)
        {
            string [] dirs = Directory.GetCurrentDirectory().Split('\\');
            string backupName = dirs[dirs.Length - 1] + "_" + db;
            if (!(DashboardHarness.Context is IGroupContext))
            {
                IVarContext var = ((IVarContext)DashboardHarness.Context);
                backupName = backupName + var.Set.ToString() + "_" + var.Level.ToString() + "_" + var.VarID.ToString();
            }
            DashboardHarness.CheckPoint(db, backupName);
        }

        public static void CheckPoint(string db, string backupName)
        {
            Utilities.LogMessage("CheckPoint: on " + db + " for " + backupName);

            if (DashboardHarness.BackupExists(backupName))
            {
                DashboardHarness.Restore(db, backupName);
            }
            else
            {
                DashboardHarness.Backup(db, backupName);

                if (DashboardHarness.Context is IGroupContext)
                {
                    if (!groupCheckPointDBs.ContainsKey(db))
                    {
                        groupCheckPointDBs.Add(db, backupName);
                        Utilities.LogMessage("adding " + db + " and " + backupName + " to groupCheckPointDBs");
                    }
                }
            }
        }

        private static bool BackupExists(string name)
        {
            Utilities.LogMessage("BackupExists: Checking for " + Directory.GetCurrentDirectory() + "\\" + name);
            return File.Exists(Directory.GetCurrentDirectory() + "\\" + name);
        }
    }
}