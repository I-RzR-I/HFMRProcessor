// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-04-01 18:49
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-01 18:50
// ***********************************************************************
//  <copyright file="TestCommandHandler.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

#endregion

namespace WebImplementation.Application.Commands.SimpleCommands.TestCommand
{
    public class TestCommandHandler : IRequestHandler<TestCommandCommand>
    {
        /// <inheritdoc />
        public async Task<Unit> Handle(TestCommandCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("This is a test reference");

            return await Task.FromResult(Unit.Value);
        }
    }
}