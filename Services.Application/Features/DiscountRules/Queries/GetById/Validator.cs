﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain.Abstraction;
using Services.Shared.ValidationMessages;

namespace Services.Application.Features.DiscountRules.Queries.GetById
{
    public sealed class GetDiscountRuleByIdValidator : AbstractValidator<GetDiscountRuleQuery>
    {
        private readonly IServiceProvider _serviceProvider;

        public GetDiscountRuleByIdValidator(IServiceProvider serviceProvider)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;
            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            ValidateRequest(scope.ServiceProvider.GetRequiredService<IDiscountRuleRepository>());
        }

        private void ValidateRequest(IDiscountRuleRepository discountRuleRepository)
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .WithMessage(ValidationMessages.DiscountRule.DiscountIdIsRequired)
                .NotNull()
                .WithMessage(ValidationMessages.DiscountRule.DiscountIdIsRequired)
                .MustAsync(
                    async (id, CancellationToken) =>
                        await discountRuleRepository.IsAnyExistAsync(d => d.Id == id)
                )
                .WithMessage(ValidationMessages.DiscountRule.IdIsNotIsExist);
        }
    }
}
