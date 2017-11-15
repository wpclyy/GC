using com.goudiw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goudiw.sdk.client.policy;

namespace goudiw.sdk.entity
{
    public class RefreshTokenRequest : Request
    {
        public RefreshTokenRequest()
        {
            OceanApiId=new APIId();
            OceanApiId.Name = "getToken";
            OceanApiId.NamespaceValue = "system.oauth2";
            OceanApiId.Version = 1;

            RequestPolicyInstance = new RequestPolicy();
            RequestPolicyInstance.UseHttps = true;
        }

        private String refreshToken;

        public void setRefreshToken(String refreshToken)
        {
            this.refreshToken = refreshToken;
        }
        public String getRefreshToken()
        {
            return this.refreshToken;
        }
        private String grant_type;

        public void setGrant_type(String grant_type)
        {
            this.grant_type = grant_type;
        }
        public String getGrant_type()
        {
            return this.grant_type;
        }

        private String client_id;

        public void setClient_id(String client_id)
        {
            this.client_id = client_id;
        }
        public String getClient_id()
        {
            return this.client_id;
        }
        private String client_secret;

        public void setClient_secret(String client_secret)
        {
            this.client_secret = client_secret;
        }
        public String getClient_secret()
        {
            return this.client_secret;
        }
           
    }
}
