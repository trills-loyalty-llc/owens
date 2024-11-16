// <copyright file="GetCustomerByIdRequest.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Contracts.Customers.Common;

namespace Owens.Contracts.Customers
{
    /// <inheritdoc />
    public class GetCustomerByIdRequest : IRequest<CustomerResponse>
    {
    }
}
