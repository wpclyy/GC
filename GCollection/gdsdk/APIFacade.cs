using com.goudiw;
using goudiw.sdk.entity;
using goudiw.sdk.client.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSdkClient.sdk
{
    public class APIFacade
    {
        private ClientPolicy clientPolicy;

        public APIFacade(ClientPolicy clientPolicy)
        {
            this.clientPolicy = clientPolicy;
        }


        private SyncAPIClient getAPIClient()
        {
            return new SyncAPIClient(clientPolicy);
        }
    }
}
