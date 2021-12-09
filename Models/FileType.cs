using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocShare.Models
{
    public class FileType
    {
        [Key]
        public int FileTypeID {get;set;}
        public string FileTypeName {get;set;}
    }
}
