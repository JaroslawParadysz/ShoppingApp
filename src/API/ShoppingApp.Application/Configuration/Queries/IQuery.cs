using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp.Application.Configuration.Queries
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }
}
