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
        /// <param name="queueTimesExternalId">The external identifier for queue times.</param>
        /// <param name="schedulingExternalId">The external identifier for scheduling.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        public Attraction(string description, int queueTimesExternalId, Guid schedulingExternalId, AttractionType attractionType)
        {
            Description = description;
            QueueTimesExternalId = queueTimesExternalId;
            SchedulingExternalId = schedulingExternalId;
            AttractionType = attractionType;
            Status = new List<QueueStatus>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attraction"/> class.
        /// </summary>
        /// <param name="id">The identifier of the root.</param>
        /// <param name="description">The description for the attraction.</param>
        /// <param name="queueTimesExternalId">The external identifier for queue times.</param>
        /// <param name="schedulingExternalId">The external identifier for scheduling.</param>
        /// <param name="attractionType">The type of the attraction.</param>
        public Attraction(Guid id, string description, int queueTimesExternalId, Guid schedulingExternalId, AttractionType attractionType)
            : base(id)
        {
            Description = description;
            QueueTimesExternalId = queueTimesExternalId;
            SchedulingExternalId = schedulingExternalId;
            AttractionType = attractionType;
            Status = new List<QueueStatus>();
        }

        /// <inheritdoc/>
        public string Description { get; }

        /// <summary>
        /// Gets the external identifier for queue times.
        /// </summary>
        public int QueueTimesExternalId { get; }

        /// <summary>
        /// Gets the external identifier for scheduling.
        /// </summary>
        public Guid SchedulingExternalId { get; }

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
