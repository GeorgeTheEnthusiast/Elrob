using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.MessageInspectors
{
    using System.ServiceModel.Configuration;

    public class TrafficLoggerBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new TrafficLoggerBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(TrafficLoggerBehavior);
            }
        }
    }
}