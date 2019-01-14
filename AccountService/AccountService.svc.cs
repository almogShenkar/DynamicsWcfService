using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;


namespace AccountService
{
    public class AccountService : IAccountService
    {
        private OrganizationServiceProxy service = null;

        public string CreateAccount(string firstName, string lastname, string email, string phone)
        {
            try
            {
                using (service = new CrmConn().GetService())
                {

                    Console.WriteLine("Connected to CRM Service - inside CreateAccount");
                    Entity account = new Entity("account");

                    Guid _accountId;
                    account["name"] = firstName + " " + lastname;
                    account["telephone1"] = phone;
                    account["emailaddress1"] = email;

                    _accountId = service.Create(account);
                    return _accountId.ToString();
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "error creating the account";

            }

        }


        public string DeleteAccountByEmail(string email)
        {
            try
            {
                using (service = new CrmConn().GetService())
                {
                    Console.WriteLine("Connected to CRM Service - inside DeleteAccountByEmail");
                    var svcContext = new OrganizationServiceContext(service);
                    var queryEmail = (from account in svcContext.CreateQuery("account")
                                      where (string)account["emailaddress1"] == email
                                      select account).ToArray();
                    if (queryEmail.Length == 0)
                        return "Not Found";
                    return queryEmail[0].Id.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "0 Deleted";

            }
        }

        public string GetAccountByEmail(string email)
        {
            try
            {
                using (service = new CrmConn().GetService())
                {
                    Console.WriteLine("Connected to CRM Service - inside GetAccountByEmail");
                    var svcContext = new OrganizationServiceContext(service);
                    var queryEmail = (from account in svcContext.CreateQuery("account")
                                      where (string)account["emailaddress1"] == email
                                      select account).ToArray();
                    if (queryEmail.Length == 0)
                        return "Not Found";
                    return queryEmail[0].Id.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "Not Found";

            }
        }

        public string UpdatePhoneByEmail(string email, string phone)
        {
            try
            {
                Console.WriteLine("Connected to CRM Service - inside UpdatePhoneByEmail");
                using (service = new CrmConn().GetService())
                {
                    Console.WriteLine("Connected to CRM Service");
                    var svcContext = new OrganizationServiceContext(service);
                    var queryEmail = (from account in svcContext.CreateQuery("account")
                                      where (string)account["emailaddress1"] == email
                                      select account).ToArray();
                    if (queryEmail.Length == 0)
                        return "Not Found";
                    queryEmail[0]["telephone1"] = phone;
                    service.Update(queryEmail[0]);
                    return "updated successfully";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return "failed";

            }
        }
    }
}
