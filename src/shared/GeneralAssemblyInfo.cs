// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:00
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="GeneralAssemblyInfo.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Reflection;
using System.Resources;

#endregion

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("RzR ®")]
[assembly: AssemblyProduct("HFMR Processor")]
[assembly: AssemblyCopyright("Copyright © 2023 RzR All rights reserved.")]
[assembly: AssemblyTrademark("® RzR™")]
[assembly:
    AssemblyDescription(
        "Execute a background processes in out-of-process. As you may have a requirement to implement a document generation (or any other bulk operations) which can cost a lot of time and you don't want to block current UI and allow user to navigate or do something else in your application, here you can see an approch how to implement this stuff.")]

[assembly: AssemblyMetadata("TermsOfService", "")]

[assembly: AssemblyMetadata("ContactUrl", "")]
[assembly: AssemblyMetadata("ContactName", "RzR")]
[assembly: AssemblyMetadata("ContactEmail", "ddpRzR@hotmail.com")]

[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.MainAssembly)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.*")]