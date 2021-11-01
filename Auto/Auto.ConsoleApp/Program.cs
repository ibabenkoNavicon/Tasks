using Auto.Common.Entitis;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using NLog;
using System;
using System.Linq;
using System.Net;

namespace Auto.ConsoleApp
{
    class Program
    {
        private static Logger Log { get; set; }

        static void Main(string[] args)
        {
            Log = LogManager.GetCurrentClassLogger();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var connectionString = "AuthType=OAuth; Url=https://orgbf2f0f19.api.crm4.dynamics.com/; " +
                "Username=admin@igorbabenko.onmicrosoft.com; " +
                "Password=6gN6xd57; " +
                "RequireNewInstance=true; " +
                "AppId=51f81489-12ee-4a9e-aaae-a2591f45987d; " +
                "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97";

            CrmServiceClient client = new CrmServiceClient(connectionString);

            if (client.LastCrmException != null)
            {
                Log.Error(ex.Message);
            }

            var service = (IOrganizationService)client;

            try
            {
                UpdateContacts(service);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            Console.Read();
        }

        private static void UpdateContacts(IOrganizationService service)
        {
//            QueryExpression query = new QueryExpression(nav_communication.EntityLogicalName);
//            query.ColumnSet = new ColumnSet(
//                nav_communication.Fields.nav_type,
//                nav_communication.Fields.nav_phone,
//                nav_communication.Fields.nav_email,
//                nav_communication.Fields.nav_contactid);

//            query.NoLock = true;
//            query.Criteria.AddCondition(nav_communication.Fields.nav_main, ConditionOperator.Equal, true);

//            var link = query.AddLink(Contact.EntityLogicalName, nav_communication.Fields.nav_contactid, Contact.Fields.ContactId);
//            link.EntityAlias = "co";
//            link.Columns = new ColumnSet(Contact.Fields.Telephone1, Contact.Fields.EMailAddress1, Contact.Fields.ContactId);

//            var result = service.RetrieveMultiple(query);
//;
//            foreach (var entity in result.Entities.Select(e => e.ToEntity<nav_communication>()))
//            {
//                var contactEmail = (string)entity.GetAttributeValue<AliasedValue>($"{link.EntityAlias}.{Contact.Fields.EMailAddress1}")?.Value;
//                var contactPhone = (string)entity.GetAttributeValue<AliasedValue>($"{link.EntityAlias}.{Contact.Fields.Telephone1}")?.Value;
//                var id = (Guid)entity.GetAttributeValue<AliasedValue>($"{link.EntityAlias}.{Contact.Fields.ContactId}")?.Value;

//                Contact contact = new Contact();
//                contact.Id = id;
//                contact.ContactId = id;

//                if (entity.nav_type == nav_communication_nav_type.Telefon && entity.nav_phone != null && contactPhone == null)
//                {
//                    contact.Telephone1 = entity.nav_phone;

//                    Log.Info($"Обновление телефона у контакта Id = {contact.Id}");
//                    service.Update(contact);
//                    Log.Info($"Контакт Id = {contact.Id} успешно обновлен");
//                }
//                else if (entity.nav_type == nav_communication_nav_type.E_mail && entity.nav_email != null && contactEmail == null)
//                {
//                    Log.Info($"Обновление email у контакта Id = {contact.Id}");

//                    contact.EMailAddress1 = entity.nav_email;
//                    service.Update(contact);

//                    Log.Info($"Контакт Id = {contact.Id} успешно обновлен");
//                }
//            }

//            Log.Info("Все контакты успешно обновлены");
//        }
    }
}
