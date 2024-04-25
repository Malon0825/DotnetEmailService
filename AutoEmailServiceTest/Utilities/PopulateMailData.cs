using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEmailServiceTest.Utilities
{
    public class PopulateMailData()
    {
        private readonly SerializeObject _serializeObject = new();
        public string SetEmailRecipient()
        {
            DataTable emailRecipient = new();
            emailRecipient.TableName = "Email Table";
            emailRecipient.Columns.Add("TO_IND");
            emailRecipient.Columns.Add("EMAIL_ADDRESS");

            emailRecipient.Rows.Add(1, "mark.malon.s.catunao@kccmalls.ph");
            emailRecipient.Rows.Add(0, "mis-no-reply@kccmalls.net");

            var emailRecipientJson = _serializeObject.SerializeDataTable(emailRecipient);
            return emailRecipientJson;
        }
    }
}
