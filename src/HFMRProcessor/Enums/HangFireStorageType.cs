// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="HangFireStorageType.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;

// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

#endregion

namespace HFMRProcessor.Enums
{
    /// <summary>
    ///     HangFire storage type
    /// </summary>
    public enum HangFireStorageType
    {
        /// <summary>
        ///     Microsoft SQL Server
        /// </summary>
        MsSql,

        /// <summary>
        ///     PostgreSQL Server
        /// </summary>
        PostgreSql
    }

    /// <summary>
    ///     Name of storage provider
    /// </summary>
    public static class SqlDbTypeName
    {
        /// <summary>
        ///     Microsoft SQL Server
        /// </summary>
        public const string MsSql = "MsSql";

        /// <summary>
        ///     PostgreSQL Server
        /// </summary>
        public const string PostgreSql = "PostgreSql";

        /// <summary>
        ///     Get name of storage provider
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(HangFireStorageType type) => Enum.GetName(typeof(HangFireStorageType), type);
    }
}