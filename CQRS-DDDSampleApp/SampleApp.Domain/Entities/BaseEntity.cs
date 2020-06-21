using SampleApp.Domain.Exceptions;
using SampleApp.Domain.Rules;

namespace SampleApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        protected static void CheckRule(IModelStateRule rule)
        {
            if (rule.IsBroken())
            {
                throw new ModelStateValidationException(rule);
            }
        }
    }
}
