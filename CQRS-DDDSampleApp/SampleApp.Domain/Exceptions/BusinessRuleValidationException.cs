using SampleApp.Domain.Rules;
using System;

namespace SampleApp.Domain.Exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public IBusinessRule BrokenRule { get; }

        public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
        }
    }
}
