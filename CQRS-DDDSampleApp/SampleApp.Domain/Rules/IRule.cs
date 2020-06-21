using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Domain.Rules
{
    public interface IRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
