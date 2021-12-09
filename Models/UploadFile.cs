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
    public class UploadFile
    {
        [Key]
        public int UploadFileID { get; set; }
        public string UploadFilePath { get; set; }
        public string UploadFileName { get; set; }
        public int? PatientCaseID { get; set; }
        public int FileTypeID { get; set; }
        public bool Downloaded { get; set; }

        [NotMapped]
        public IFormFile UploadFileFile { get; set; }
        [NotMapped]
        public List<IFormFile> UploadFileFiles { get; set; }
    }
}
