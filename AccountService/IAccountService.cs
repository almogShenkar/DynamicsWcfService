using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace AccountService
{
    //AccountService - simple service using the dynmics sdk to demonstrate how we can use the SDK to create get update delete

    [ServiceContract]
    public interface IAccountService
    {

        [OperationContract]
        string CreateAccount(string firstName, string lastname, string email, string phone);

        [OperationContract]
        string GetAccountByEmail(string email);

        [OperationContract]
        string UpdatePhoneByEmail(string email,string phone);

        [OperationContract]
        string DeleteAccountByEmail(string email);

    }
}
