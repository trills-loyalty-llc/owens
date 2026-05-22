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
    public class Attraction : AggregateRoot, IDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="externalId">The external identifier of the attraction.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        public Attraction(int externalId, string description, AttractionType attractionType)
        {
            ExternalId = externalId;
            Description = description;
            AttractionType = attractionType;
            Status = new List<QueueStatus>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="externalId">The external identifier of the attraction.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        public Attraction(Guid id, int externalId, string description, AttractionType attractionType)
            : base(id)
        {
            ExternalId = externalId;
            Description = description;
            AttractionType = attractionType;
            Status = new List<QueueStatus>();
        }

        /// <summary>
        /// Gets the external identifier. This is used to join for certain external client properties.
        /// </summary>
        public int ExternalId { get; }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets the type of the attraction.
        /// </summary>
        public AttractionType AttractionType { get; }

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
