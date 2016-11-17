using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateClient.Infrastructure
{
    /// <summary>
    /// Inspects message, and adds message headers
    /// </summary>
    public class AddHeadersToClientMessageInspector : IClientMessageInspector
    {
        public MessageHeader[] Headers { get; set; }
        public AddHeadersToClientMessageInspector(params MessageHeader[] headers)
        {
            Headers = headers;
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (Headers != null)
            {
                for (int i = Headers.Length - 1; i >= 0; i--)
                    request.Headers.Insert(0, Headers[i]);
            }
            return request;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
