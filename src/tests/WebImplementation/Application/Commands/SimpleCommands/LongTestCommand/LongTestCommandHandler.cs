// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-04-01 18:49
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-01 18:50
// ***********************************************************************
//  <copyright file="LongTestCommandHandler.cs" company="">
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

namespace WebImplementation.Application.Commands.SimpleCommands.LongTestCommand
{
    public class TestCommandHandler : IRequestHandler<LongTestCommandCommand>
    {
        /// <inheritdoc />
        public async Task<Unit> Handle(LongTestCommandCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("This is a test reference with long execution");
            await Task.Delay(1000 * 60, cancellationToken);

            return await Task.FromResult(Unit.Value);
        }
    }
}