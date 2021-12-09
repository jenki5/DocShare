using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocShare.Models
{
    public class CasePhase
    {
        [Key]
        public int CasePhaseID {get;set;}
        public string Description {get;set;}
    }
}
