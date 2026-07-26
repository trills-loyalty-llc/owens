// <copyright file="Attraction.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Owens.Domain.Common;

namespace Owens.Domain.Attractions
{
    /// <summary>
    /// Defines either a ride, entertainment, or undefined attraction.
    /// </summary>
    public class Attraction : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="externalId">The external identifier of the attraction.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="heightRequirementInInches">The height requirement in inches.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        /// <param name="location">The location of the attraction.</param>
        /// <param name="dateTimeRange">The lifecycle of the attraction.</param>
        public Attraction(int externalId, string description, int heightRequirementInInches, AttractionType attractionType, Location location, DateTimeRange dateTimeRange)
        {
            ExternalId = externalId;
            Description = description;
            AttractionType = attractionType;
            Location = location;
            DateTimeRange = dateTimeRange;
            HeightRequirementInInches = heightRequirementInInches;
            Status = new List<QueueStatus>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="externalId">The external identifier of the attraction.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="heightRequirementInInches">The height requirement in inches.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        public Attraction(Guid id, int externalId, string description, int heightRequirementInInches, AttractionType attractionType)
            : base(id)
        {
            ExternalId = externalId;
            Description = description;
            AttractionType = attractionType;
            HeightRequirementInInches = heightRequirementInInches;
            Location = Location.Empty();
            DateTimeRange = DateTimeRange.Empty();
            Status = new List<QueueStatus>();
        }

        /// <summary>
        /// Gets the external identifier. This is used to join for certain external client properties.
        /// </summary>
        public int ExternalId { get; }

        /// <summary>
        /// Gets the attraction description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the height requirement of the attraction in inches.
        /// </summary>
        public int HeightRequirementInInches { get; }

        /// <summary>
        /// Gets the type of the attraction.
        /// </summary>
        public AttractionType AttractionType { get; }

        /// <summary>
        /// Gets the attraction location.
        /// </summary>
        public Location Location { get; }

        /// <summary>
        /// Gets the life cycle of the attraction.
        /// </summary>
        public DateTimeRange DateTimeRange { get; }

        /// <summary>
        /// Gets a series of status updates.
        /// </summary>
        public ICollection<QueueStatus> Status { get; }

        /// <summary>
        /// Appends a new status to the attraction.
        /// </summary>
        /// <param name="status">A <see cref="QueueStatus"/> to append.</param>
        public void AppendStatus(QueueStatus status)
        {
            Status.Add(status);
        }
    }
}
