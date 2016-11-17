using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateClient.Infrastructure
{
    /// <summary>
    /// provides an Endpoint behavior for ClientMessageInspector implementation
    /// </summary>
    public class AddHeadersToClientMessageBehavior : IEndpointBehavior
    {
        public AddHeadersToClientMessageInspector ClientInspector { get; set; }
        public AddHeadersToClientMessageBehavior(AddHeadersToClientMessageInspector clientInspector)
        {
            ClientInspector = clientInspector;
        }
        public void Validate(ServiceEndpoint endpoint)
        {
        }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            if (this.ClientInspector == null)
                throw new InvalidOperationException("Caller must supply ClientInspector.");
            clientRuntime.MessageInspectors.Add(ClientInspector);
        }
    }
}
