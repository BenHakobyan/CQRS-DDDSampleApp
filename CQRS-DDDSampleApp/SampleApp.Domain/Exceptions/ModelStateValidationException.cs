using SampleApp.Domain.Rules;
using System;

namespace SampleApp.Domain.Exceptions
{
    public class ModelStateValidationException : Exception
    {
        public IModelStateRule BrokenRule { get; }

        public ModelStateValidationException(IModelStateRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
        }
    }
}
