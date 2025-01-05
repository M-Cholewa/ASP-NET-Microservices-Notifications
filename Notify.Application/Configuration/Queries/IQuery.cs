using MediatR;

namespace Notify.Application.Configuration.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}