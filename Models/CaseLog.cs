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
    public class CaseLog
    {
        [Key]
        public int CaseLogID { get; set; }
        public int PatientCaseID { get; set; }
        public int? UploadFileID {get;set;}
        public UploadFile UploadFile {get;set;}
        public int UserID {get;set;}
        public User User {get;set;}
        public string Message {get;set;}
        [NotMapped]
        public string ActionName {get;set;}
        public DateTime CreatedAt {get;set;}

        public void SetActionName()
        {
            ActionName = $"{User.FirstName} {User.LastName} at {User.Company.CompanyName}";
        }
    }
}
