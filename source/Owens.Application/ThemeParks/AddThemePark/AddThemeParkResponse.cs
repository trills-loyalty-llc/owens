// <copyright file="AddThemeParkResponse.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.Contracts;

namespace Owens.Application.ThemeParks.AddThemePark
{
    /// <inheritdoc />
    public class AddThemeParkResponse : EntityResponse
    {
        /// <inheritdoc />
        public AddThemeParkResponse(Guid id)
            : base(id)
        {
        }
    }
}
