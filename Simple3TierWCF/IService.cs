using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Simple3TierWCF
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        Task<string> GetData(uint value);

    }


}
