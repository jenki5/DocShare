using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace DocShare.Models
{
    public class CompanyCase
    {
        public int PatientCaseID { get; set; }
        public PatientCase PatientCase {get;set;}
        public int CompanyID { get; set; }
        public bool CaseSubmitted { get; set; }
    }
}
