﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public class Mediator : IMediator
    {
        private Dictionary<Type, Type> requestHandlers;

        public Mediator(Dictionary<Type, Type> requestHandlers)
        {
            this.requestHandlers = requestHandlers;
        }

        public object Send(IRequest request)
        {
            var requestHandlerType = requestHandlers[request.GetType()];
            var requestHandler = Activator.CreateInstance(requestHandlerType);
            return requestHandlerType.GetMethod("Execute").Invoke(requestHandler, new object[] { request });
        }
    }
}
