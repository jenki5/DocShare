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
    public class PatientCase
    {
        [Key]
        public int PatientCaseID { get; set; }
        public int CompanyID { get; set; }
        [NotMapped]
        public int LabID { get; set; }
        public int CasePhaseID { get; set; }
        public string CaseName {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public bool Hold {get;set;}
        public List<CompanyCase> CompanyCases {get;set;} = new List<CompanyCase>();
        public List<CaseLog> CaseLogs {get;set;} = new List<CaseLog>();
        public List<UploadFile> UploadFiles {get;set;} = new List<UploadFile>();
        public List<CaseNote> CaseNotes {get;set;} = new List<CaseNote>();

        public void ReadNotes(int ReaderCompanyID)
        {
            for(int i = 0; i < CaseNotes.Count(); i++)
            {
                if(ReaderCompanyID != CaseNotes[i].CompanyID)
                {
                    CaseNotes[i].NoteRead = true;
                }
            }
        }

        public void SetLabIds(int id)
        {
            LabID = id;
        }

        public void SetLogsActionNames()
        {
            for(int i = 0; i < CaseLogs.Count(); i++)
            {
                CaseLogs[i].SetActionName();
            }
        }

        public void LogDesignerUploadFile(UploadFile UF, int? UserID = null)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = UF.UploadFileID,
                UserID = (int)UserID,
                Message = "uploaded a new zip file to the case",
                CreatedAt = DateTime.Now
            };

            CaseLogs.Add(log);
        }

        public void LogDesignerDownloadFile(UploadFile UF, int? UserID = null)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = UF.UploadFileID,
                UserID = (int)UserID,
                Message = "downloaded the zip file",
                CreatedAt = DateTime.Now
            };

            CaseLogs.Add(log);
        }
        

        public void LogNewCaseUpload(UploadFile UF, int? UserID = null)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = UF.UploadFileID,
                UserID = (int)UserID,
                Message = "uploaded a new zip file and created the case",
                CreatedAt = DateTime.Now
            };

            CaseLogs.Add(log);
        }

        public void LogCaseHold(int? UserID)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = null,
                UserID = (int)UserID,
                Message = "Case placed on hold",
                CreatedAt = DateTime.Now
            };

            if(CaseLogs == null)
            {
                CaseLogs = new List<CaseLog>();
            }

            CaseLogs.Add(log);
        }

        public void LogCaseRemoveHold(int? UserID)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = null,
                UserID = (int)UserID,
                Message = "Case hold removed",
                CreatedAt = DateTime.Now
            };

            if(CaseLogs == null)
            {
                CaseLogs = new List<CaseLog>();
            }

            CaseLogs.Add(log);
        }

        public void LogNewImageUpload(UploadFile UF, int? UserID = null)
        {
            CaseLog log = new CaseLog()
            {
                UploadFileID = UF.UploadFileID,
                UserID = (int)UserID,
                Message = "uploaded a new image",
                CreatedAt = DateTime.Now
            };

            if(CaseLogs == null)
            {
                CaseLogs = new List<CaseLog>();
            }

            CaseLogs.Add(log);
        }
    }
}
