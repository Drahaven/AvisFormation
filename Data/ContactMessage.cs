using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class ContactMessage
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
