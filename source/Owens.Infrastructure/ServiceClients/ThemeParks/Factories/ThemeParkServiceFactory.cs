// <copyright file="ThemeParkServiceFactory.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Services.ThemeParks.Models;
using Owens.Infrastructure.ServiceClients.ThemeParks.Models;

namespace Owens.Infrastructure.ServiceClients.ThemeParks.Factories
{
    /// <summary>
    /// Factory for the theme park service client.
    /// </summary>
    public class ThemeParkServiceFactory :
        ICanTranslate<DestinationsResponseWrapper, List<Destination>>,
        ICanTranslate<ParkDetailsResponse, ParkDetails>,
        ICanTranslate<ParkChildrenResponseWrapper, List<ParkChildren>>
    {
        /// <inheritdoc/>
        public List<Destination> TranslateTo(DestinationsResponseWrapper initial)
        {
            return initial.Destinations.Select(destinationResponse =>
            {
                return new Destination
                {
                    Id = destinationResponse.Id,
                    Description = destinationResponse.Description,
                    Parks = destinationResponse.Parks.Select(parkResponse => new DestinationPark
                    {
                        Id = parkResponse.Id,
                        Description = parkResponse.Description,
                    }),
                };
            }).ToList();
        }

        /// <inheritdoc/>
        public ParkDetails TranslateTo(ParkDetailsResponse initial)
        {
            return new ParkDetails
            {
                Id = initial.Id,
                Description = initial.Description,
                TimeZone = initial.TimeZone,
                Location = new ParkLocation
                {
                    Latitude = initial.Location.Latitude,
                    Longitude = initial.Location.Longitude,
                },
            };
        }

        /// <inheritdoc/>
        public List<ParkChildren> TranslateTo(ParkChildrenResponseWrapper initial)
        {
            return initial.Children
                .Select(childResponse => new ParkChildren
                {
                    Id = childResponse.Id,
                    Description = childResponse.Description,
                }).ToList();
        }
    }
}
