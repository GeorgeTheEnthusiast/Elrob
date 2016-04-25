using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.MessageInspectors
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using NLog;

    public class TrafficLoggerMessageInspector : IDispatchMessageInspector
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //_logger.Debug("REQUEST:" + request);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            _logger.Debug("RESPONSE:" + reply);
        }
    }
}