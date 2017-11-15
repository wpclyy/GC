using goudiw.sdk.entity;
using goudiw.sdk.http;
using goudiw.sdk.client.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.goudiw
{
    public class SyncAPIClient
    {
        private ClientPolicy clientPolicy;

        public SyncAPIClient(ClientPolicy clientPolicy)
        {
            this.clientPolicy = clientPolicy;
        }

        public string send<T>(Request request)
        {
            HttpClient httpClient = new HttpClient(clientPolicy);
            string result = httpClient.request<T>(request, request.RequestPolicyInstance, null);
            return result;
        }

        public string send<T>(Request request, String accessToken)
        {
            HttpClient httpClient = new HttpClient(clientPolicy);
            string result = httpClient.request<T>(request, request.RequestPolicyInstance, accessToken);
            return result;
        }

        public string sendimg<T>(UploadParameterType uploadpara,Request request)
        {
            HttpClient httpClient = new HttpClient(clientPolicy);
            string result = httpClient.Execute(uploadpara,request, request.RequestPolicyInstance);
            return result;
        }
    }
}

