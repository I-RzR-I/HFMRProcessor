// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-04-01 23:18
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="HangFireStorageInitializeExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.SqlServer;
using HFMRProcessor.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Extensions
{
    /// <summary>
    ///     Storage initialize
    /// </summary>
    /// <remarks></remarks>
    internal static class HangFireStorageInitializeExtensions
    {
        /// <summary>
        ///     Initialize HangFire storage
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <remarks></remarks>
        internal static void InitializeHangFireService(this IServiceCollection services, IConfiguration configuration)
        {
            var storageConnection = configuration.GetHandFireStorageConnectString();
            var storageType = configuration.GetHandFireStorageType();

            if (!storageConnection.IsSuccess)
                throw new ArgumentOutOfRangeException(storageConnection.GetFirstMessage());
            if (!storageType.IsSuccess)
                throw new ArgumentOutOfRangeException(storageType.GetFirstMessage());

            switch (storageType.Response)
            {
                case HangFireStorageType.MsSql:
                    services.AddHangfire(hangFireConfiguration =>
                    {
                        hangFireConfiguration.UseSqlServerStorage(storageConnection.Response);
#pragma warning disable SCS0028 // TypeNameHandling is set to the other value than 'None'. It may lead to deserialization vulnerability.
                        hangFireConfiguration.UseSerializerSettings(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
#pragma warning restore SCS0028 // TypeNameHandling is set to the other value than 'None'. It may lead to deserialization vulnerability.
                    });

                    JobStorage.Current = new SqlServerStorage(storageConnection.Response);

                    break;
                case HangFireStorageType.PostgreSql:
                    services.AddHangfire(hangFireConfiguration =>
                    {
                        hangFireConfiguration.UsePostgreSqlStorage(storageConnection.Response);
#pragma warning disable SCS0028 // TypeNameHandling is set to the other value than 'None'. It may lead to deserialization vulnerability.
                        hangFireConfiguration.UseSerializerSettings(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
#pragma warning restore SCS0028 // TypeNameHandling is set to the other value than 'None'. It may lead to deserialization vulnerability.
                    });

                    JobStorage.Current = new PostgreSqlStorage(storageConnection.Response);

                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Invalid storage type {storageType.Response}");
            }
        }
    }
}