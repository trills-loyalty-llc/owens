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
        /// <param name="description">The description for the attraction.</param>
        /// <param name="externalId">The external identifier.</param>
        public Attraction(string description, int externalId)
        {
            Description = description;
            ExternalId = externalId;
            Status = new List<AttractionStatus>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="externalId">The external identifier.</param>
        public Attraction(Guid id, string description, int externalId)
            : base(id)
        {
            Description = description;
            ExternalId = externalId;
            Status = new List<AttractionStatus>();
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets the external identifier.
        /// </summary>
        public int ExternalId { get; }

        /// <summary>
        /// Gets a series of status updates.
        /// </summary>
        public ICollection<AttractionStatus> Status { get; }

        /// <summary>
        /// Appends a new status to the attraction.
        /// </summary>
        /// <param name="status">A <see cref="AttractionStatus"/> to append.</param>
        public void AppendStatus(AttractionStatus status)
        {
            Status.Add(status);
        }
    }
}
