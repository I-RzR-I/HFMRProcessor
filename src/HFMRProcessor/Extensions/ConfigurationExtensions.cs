// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="ConfigurationExtensions.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using AggregatedGenericResultMessage;
using AggregatedGenericResultMessage.Abstractions;
using AggregatedGenericResultMessage.Extensions.Result;
using HFMRProcessor.Enums;
using Microsoft.Extensions.Configuration;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Extensions
{
    /// <summary>
    ///     Application configuration extensions
    /// </summary>
    internal static class ConfigurationExtensions
    {
        /// <summary>
        ///     Get Hand Fire storage type
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        /// <returns></returns>
        internal static IResult<HangFireStorageType> GetHandFireStorageType(this IConfiguration configuration)
        {
            try
            {
                Enum.TryParse(configuration ["HangFireOptions:StorageTypeName"], out HangFireStorageType dbType);

                return Result<HangFireStorageType>.Success(dbType);
            }
            catch (Exception e)
            {
                return Result<HangFireStorageType>
                    .Failure("Internal error on get HangFire storage type!")
                    .WithError(e);
            }
        }

        /// <summary>
        ///     Get Hang Fire storage connection string
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        /// <returns></returns>
        internal static IResult<string> GetHandFireStorageConnectString(this IConfiguration configuration)
        {
            try
            {
                var connection = configuration ["HangFireOptions:StorageConnectionString"];

                return string.IsNullOrEmpty(connection)
                    ? Result<string>.Failure("Check HangFire connection string")
                    : Result<string>.Success(connection);
            }
            catch (Exception e)
            {
                return Result<string>
                    .Failure("Internal error on get HangFire connection string!")
                    .WithError(e);
            }
        }

        /// <summary>
        ///     Get Hang Fire heartbeat interval
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        /// <returns></returns>
        internal static IResult<string> GetHandFireHeartbeatInterval(this IConfiguration configuration)
        {
            try
            {
                return Result<string>.Success(configuration ["HangFireOptions:HeartbeatInterval"]);
            }
            catch (Exception e)
            {
                return Result<string>
                    .Failure("Internal error on get HangFire heartbeat interval!")
                    .WithError(e);
            }
        }

        /// <summary>
        ///     Get Hand Fire server check interval
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        /// <returns></returns>
        internal static IResult<string> GetHandFireServerCheckInterval(this IConfiguration configuration)
        {
            try
            {
                return Result<string>.Success(configuration ["HangFireOptions:ServerCheckInterval"]);
            }
            catch (Exception e)
            {
                return Result<string>
                    .Failure("Internal error on get HangFire server check interval!")
                    .WithError(e);
            }
        }
    }
}