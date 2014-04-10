using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Analytics.v3;

namespace Google_Analytics_ManagementAPI.net
{
    class GAManagement
    {
        /// <summary>
        /// retrieves a list of the Google Analtyics accounts for the curently autenticated user.
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <returns></returns>
        public static Accounts Accountlist(AnalyticsService service)
        {

            ManagementResource.AccountsResource.ListRequest request = service.Management.Accounts.List();
            Accounts result = request.Execute();
            return result;
        }

        /// <summary>
        /// retrieves a list of the Google Analtyics accounts for the curently autenticated user.
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <param name="pAccount">The account we would like to request propertys for</param>
        /// <returns></returns>
        public static Webproperties Propertieslist(AnalyticsService service, string pAccount)
        {
            ManagementResource.WebpropertiesResource.ListRequest request = service.Management.Webproperties.List(pAccount);

            try
            {
                Webproperties result = request.Execute();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Retrieve a list of profiles 
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <param name="pAccount">The account we would like to request propertys for</param>
        /// <param name="pWebProperty">Webproprty we are selecting for</param>
        /// <returns></returns>
        public static Profiles ProfilesList(AnalyticsService service, string pAccount, string pWebProperty)
        {
            ManagementResource.ProfilesResource.ListRequest request = service.Management.Profiles.List(pAccount, pWebProperty);
            try
            {
                Profiles result = request.Execute();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retrives a full list of Accounts, Web Properties and Views for a Autenticated user.
        /// </summary>
        /// <param name="service">Analtyics service</param>
        /// <returns></returns>
        public static AccountSummaries AccountSummaryList(AnalyticsService service)
        {
            ManagementResource.AccountSummariesResource.ListRequest request = service.Management.AccountSummaries.List();
            try
            {
                AccountSummaries result = request.Execute();
                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        /// <summary>
        /// retrieves a list of the Google Analtyics Goals
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <param name="pAccount">The account we would like to request propertys for</param>
        /// <param name="pWebProperty">Webproprty we are selecting for </param>
        /// <param name="pProfile"> profile we are selecting for </param>
        /// <returns></returns>
        public static Goals GoalList(AnalyticsService service, string pAccount, string pWebProperty, string pProfile)
        {
            ManagementResource.GoalsResource.ListRequest request = service.Management.Goals.List(pAccount, pWebProperty, pProfile);
            try
            {
                Goals result = request.Execute();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// retrieves a list of the Google Analtyics Segment
        /// </summary>
        /// <param name="service">AnalyticsService</param>
        /// <returns></returns>
        public static Segments SegmentList(AnalyticsService service)
        {
            ManagementResource.SegmentsResource.ListRequest request = service.Management.Segments.List();
            try
            {
                Segments result = request.Execute();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}