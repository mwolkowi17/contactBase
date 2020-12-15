using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBase.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ContactId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public string AditionalInfo { get; set; }
        public string PhoneNr { get; set; }
        public string Email { get; set; }
    }
}
