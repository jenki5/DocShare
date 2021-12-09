using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace DocShare.Models
{
    public class CaseNote
    {
        [Key]
        public int CaseNoteID {get;set;}
        public int CompanyID {get;set;}
        public int UserID {get;set;}
        public User User {get;set;}
        public int PatientCaseID {get;set;}
        public string NoteText {get;set;}
        public bool NoteRead {get;set;}
        public DateTime CreatedAt {get;set;}
        [NotMapped]
        public string SenderName {get;set;}
        [NotMapped]
        public int CompanyTypeID {get;set;}
    }    
}