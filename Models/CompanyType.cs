using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocShare.Models
{
    public class CompanyType
    {
        [Key]
        public int CompanyTypeID {get;set;}
        public string CompanyTypeName {get;set;}
    }
}