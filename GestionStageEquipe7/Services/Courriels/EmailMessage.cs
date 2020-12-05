using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Services.Courriels
{
    public class EmailMessage
    {
        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public string NomPieceJointe { get; set; }

        //public MemoryStream PieceJointe { get; set; }

        //public IFormFile Attachment { get; set; }

        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }
    }
}
