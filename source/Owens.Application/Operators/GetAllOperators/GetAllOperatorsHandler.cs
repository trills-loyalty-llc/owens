// <copyright file="GetAllOperatorsHandler.cs" company="Trills Loyalty LLC">
// Copyright (c) Trills Loyalty LLC. All rights reserved.
// </copyright>

using FactoryFoundation;
using Owens.Application.Common.Mediation;
using Owens.Application.Operators.Common;
using Owens.Domain.Operators;

namespace Owens.Application.Operators.GetAllOperators
{
    /// <inheritdoc />
    public class GetAllOperatorsHandler : EnvelopeHandler<GetAllOperatorsRequest, GetAllOperatorsResponse>
    {
        private readonly ITranslator _translator;
        private readonly IOperatorRepository _operatorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllOperatorsHandler"/> class.
        /// </summary>
        /// <param name="translator">An instance of the <see cref="ITranslator"/> interface.</param>
        /// <param name="operatorRepository">An instance of the <see cref="IOperatorRepository"/> interface.</param>
        public GetAllOperatorsHandler(ITranslator translator, IOperatorRepository operatorRepository)
        {
            _translator = translator;
            _operatorRepository = operatorRepository;
        }

        /// <inheritdoc/>
        public override async Task<Envelope<GetAllOperatorsResponse>> Handle(GetAllOperatorsRequest payload, CancellationToken cancellationToken)
        {
            var resortOperators = await _operatorRepository.GetAllObjects(cancellationToken);

            var operatorResponses = _translator.Translate<IEnumerable<ResortOperator>, IEnumerable<OperatorResponse>>(resortOperators);

            return Success(new GetAllOperatorsResponse(operatorResponses));
        }
    }
}
