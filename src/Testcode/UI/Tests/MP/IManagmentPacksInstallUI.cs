//  -----------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ManagmentPacksInstallUI.itf.cs">
//     Copyright © Microsoft 2005
// </copyright>
// <project>
//     $safeprojectname$
// </project>
// <summary>
//     Summary description for this file
// </summary>
// <history>
//      [barryw] 14Jul2005 Created
// </history>
//  -----------------------------------------------------------------------

// Note: do not surround with the project's namespace.

#region Using directives

using Infra.Frmwrk;

#endregion

#region Interface Definition - IManagmentPacksInstallUI

/// -----------------------------------------------------------------------------
/// <summary>
/// Interface definition, IManagmentPacksInstallUI, for 
///     ManagmentPacksInstallUI.
/// Defines methods for accessing the test var functions, as
///     well as the default functions, such as, Setup and Cleanup.
/// </summary>
/// <history>
/// 	[barryw] 7/15/2005 Created
/// </history>
/// -----------------------------------------------------------------------------
public interface IManagmentPacksInstallUI
{
    void VerifyAddManagementPack(IContext context);

    void InstallManagementPacks(IContext context);

    void DeleteInstallManagementPack(IContext context);
}

#endregion
