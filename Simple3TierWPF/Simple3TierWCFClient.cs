using Simple3TierWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Simple3TierWPF
{
    public class Simple3TierWCFClient : ClientBase<IService>
    {

        public static Simple3TierWCFClient Create()
        {
            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IService)));

            endpoint.Binding = new BasicHttpBinding();

            endpoint.Address = new EndpointAddress(@"http://40.122.169.215/Simple3TierWCF/Service.svc");

            return new Simple3TierWCFClient(endpoint);
        }

        private Simple3TierWCFClient(ServiceEndpoint endpoint) : base(endpoint)
        {

        }

        uint count = 0;

        public async Task<string> GetData()
        {
            var result = await base.Channel.GetData(count);
            count++;
            return result;
        }

    }
}
