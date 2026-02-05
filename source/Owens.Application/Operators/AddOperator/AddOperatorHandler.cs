// <copyright file="AddOperatorHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Common.Mediation;
using Owens.Application.Operators.Common;
using Owens.Domain.Operators;

namespace Owens.Application.Operators.AddOperator
{
    /// <inheritdoc />
    public class AddOperatorHandler : EnvelopeHandler<AddOperatorRequest, AddOperatorResponse>
    {
        private readonly ITranslator _translator;
        private readonly IOperatorRepository _operatorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddOperatorHandler"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="operatorRepository">An instance of the <see cref="IOperatorRepository"/> interface.</param>
        public AddOperatorHandler(ITranslator translator, IOperatorRepository operatorRepository)
        {
            _translator = translator;
            _operatorRepository = operatorRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<AddOperatorResponse>> Handle(AddOperatorRequest payload, CancellationToken cancellationToken)
        {
            var envelope = _translator.Translate<AddOperatorRequest, ValidationEnvelope<ResortOperator>>(payload);

            if (envelope.IsInvalid)
            {
                return ValidationFailed();
            }

            var result = await _operatorRepository.AddObject(envelope.Entity, cancellationToken);

            if (result.Failed)
            {
                return OperationFailed();
            }

            var response = _translator.Translate<ResortOperator, AddOperatorResponse>(envelope.Entity);

            return Success(response);
        }
    }
}
