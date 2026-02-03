// <copyright file="MemberController.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;
using NMediation.Abstractions;
using Owens.API.Common;

namespace Owens.API.Controllers.Members
{
    /// <inheritdoc />
    [ApiController]
    [Route("member")]
    public class MemberController : BaseController
    {
        /// <inheritdoc />
        public MemberController(IMediation mediation)
            : base(mediation)
        {
        }
    }
}
