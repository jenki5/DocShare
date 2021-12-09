using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocShare.Models
{
    public class FriendCompany
    {
        public int CompanyID {get;set;}
        public Company Company {get;set;}
        public int FriendCompanyID {get;set;}
        public Company CompanyFriend {get;set;}
    }
}
