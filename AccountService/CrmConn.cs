using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Web;

namespace AccountService
{

    //Manage the CRM service 
    public class CrmConn
    {

        private string myOrgUri;
        private ClientCredentials credentials;


        //init configuratuin to my org crm
        public CrmConn()
        {

            credentials = new ClientCredentials();
            credentials.UserName.UserName = "almog@akunamatata.onmicrosoft.com";
            credentials.UserName.Password = "Kb241014*";
            myOrgUri = "https://akunamatata.api.crm4.dynamics.com/XRMServices/2011/Organization.svc";
        }

        //get service refrence
        public OrganizationServiceProxy GetService()
        {
            return new OrganizationServiceProxy(new Uri(myOrgUri), null, credentials, null);

        }

    }
}