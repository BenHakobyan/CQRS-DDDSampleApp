using MediatR;

namespace SampleApp.Application.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
