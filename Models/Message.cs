using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DocShare.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MessageContent { get; set; }
    }
}
