// <copyright file="IAttractionRepository.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using Owens.Application.Common.DataAccess;
using Owens.Domain.Attractions;

namespace Owens.Application.Attractions.Common
{
    /// <summary>
    /// Interface for interacting with <see cref="Attraction"/> persistence.
    /// </summary>
    public interface IAttractionRepository :
        IAddObject<Attraction>,
        IUpdateObject<Attraction>,
        IGetObjectById<Attraction>
    {
    }
}
