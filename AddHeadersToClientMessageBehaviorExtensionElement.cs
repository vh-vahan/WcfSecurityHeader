using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateClient.Infrastructure
{


    public class AddHeadersToClientMessageBehaviorExtensionElement : BehaviorExtensionElement
    {
        const string UsernameProperty = "username";
        const string UserpasswordProperty = "userpassword";

        protected override object CreateBehavior()
        {
            return new AddHeadersToClientMessageBehavior(new AddHeadersToClientMessageInspector(new SecurityHeader("SomeName", Username, Userpassword)));
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(AddHeadersToClientMessageBehavior);
            }
        }


        [ConfigurationProperty(UsernameProperty)]
        public string Username
        {
            get
            {
                return (string)base[UsernameProperty];
            }
            set
            {
                base[UsernameProperty] = value;
            }
        }

        [ConfigurationProperty(UserpasswordProperty)]
        public string Userpassword
        {
            get
            {
                return (string)base[UserpasswordProperty];
            }
            set
            {
                base[UserpasswordProperty] = value;
            }
        }
    }

    

    
}
