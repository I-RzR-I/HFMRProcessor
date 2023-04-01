// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="MediatRDefinition.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.Reflection;
using AppInitDefinitionDecorate;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace WebImplementation.ApplicationDefinition
{
    public class MediatRDefinition : InitDefinitionDecorate
    {
        public MediatRDefinition()
        {
            base.InitializeOrder = 1;
            base.IsDecorationEnable = true;
        }

        /// <inheritdoc />
        public override void ServiceConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }
    }
}