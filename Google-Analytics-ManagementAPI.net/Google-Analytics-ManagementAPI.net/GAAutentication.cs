using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Analytics.v3;
using Google.Apis.Util.Store;
using System.Threading;
using Google.Apis.Services;

namespace Google_Analytics_ManagementAPI.net
{
    class GAAutentication
    {
        public AnalyticsService service;
        public UserCredential credential;

        public void initAnaltyics(string _client_id, string _client_secret)
        {


            try
            {
                this.credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = _client_id, ClientSecret = _client_secret },
                                                                         new[] { AnalyticsService.Scope.AnalyticsReadonly, AnalyticsService.Scope.AnalyticsManageUsers },
                                                                         "Userx",
                                                                         CancellationToken.None,
                                                                         new FileDataStore("Analytics.Auth.Store")).Result;
            }
            catch (Exception ex)
            {


            }

            if (this.credential != null)
            {
                // This is how we connect to Google Analytics. Everthing you will be requesting will now go though the Service var.
                this.service = new AnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Analytics API Sample",
                });
            }


        }
    }
}
