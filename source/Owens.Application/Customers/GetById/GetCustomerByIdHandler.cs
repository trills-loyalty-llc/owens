// <copyright file="GetCustomerByIdHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using MediatR;
using Owens.Contracts.Customers;
using Owens.Contracts.Customers.Common;
using Owens.Domain.Customers;

namespace Owens.Application.Customers.GetById
{
    /// <inheritdoc />
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, CustomerResponse>
    {
        /// <inheritdoc />
        public Task<CustomerResponse> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer();

            return Task.FromResult(new CustomerResponse(customer.Id));
        }
    }
}
