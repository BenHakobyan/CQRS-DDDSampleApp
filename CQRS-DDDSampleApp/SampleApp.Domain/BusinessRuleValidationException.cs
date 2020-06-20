﻿using System;

namespace SampleApp.Domain
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
