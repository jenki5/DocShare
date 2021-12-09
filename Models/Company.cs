using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace DocShare.Models
{
    public class Company
    {
        [Key]
        public int CompanyID {get;set;}
        public string CompanyName {get;set;}
        public string StreetAddress1 {get;set;}
        public string StreetAddress2 {get;set;}
        public string City {get;set;}
        public string State {get;set;}
        public int? Zip {get;set;}
        public string PhoneNumber {get;set;}
        public int? CompanyTypeID {get;set;}
        public CompanyType CompanyType {get;set;}
        public List<PatientCase> PatientCases {get;set;} = new List<PatientCase>();
        public List<CompanyCase> CompanyCases {get;set;} = new List<CompanyCase>();
        public DateTime? CreatedAt {get;set;}
        public DateTime? UpdatedAt {get;set;}
        [NotMapped]
        public User User {get;set;}
        public List<FriendCompany> Companies {get;set;} = new List<FriendCompany>();
        public List<FriendCompany> FriendCompanies {get;set;} = new List<FriendCompany>();
        [NotMapped]
        public List<Company> Friends {get;set;}


        public void SetLabPatientCases()
        {
            if(CompanyTypeID == 1)
            {
                RemovePatientCaseLoop();
            }
            else if(CompanyTypeID == 2)
            {
                for(int i = 0; i < CompanyCases.Count(); i++)
                {
                    CompanyCases[i].PatientCase.CompanyCases = null;
                    CompanyCases[i].PatientCase.SetLogsActionNames();
                    CompanyCases[i].PatientCase.SetLabIds(CompanyCases[i].CompanyID);
                    if(CompanyCases[i].CaseSubmitted)
                    {
                        PatientCases.Add(CompanyCases[i].PatientCase);
                    }
                }
                CompanyCases = new List<CompanyCase>();
            }
        }

        public void RemovePatientCaseLoop()
        {
            for(int i = 0; i < PatientCases.Count(); i++)
            {
                try
                {
                    if(PatientCases[i].CompanyCases != null)
                    {
                        PatientCases[i].SetLabIds(PatientCases[i].CompanyCases[0].CompanyID);
                    }
                }catch{}
                PatientCases[i].CompanyCases = null;
                CompanyCases = null;

            }
        }

        public void RemoveUnregisteredFriends()
        {
            for(int i = 0; i < Friends.Count(); i++)
            {
                if(Friends[i].CompanyName == null)
                {
                    Friends.Remove(Friends[i]);
                    i--;
                }
            }
        }
        public void SetCompanyFriends()
        {
            Friends = new List<Company>();
            if(Companies != null)
            {
                for(int i = 0; i < Companies.Count(); i++)
                {
                    if(Companies[i].Company.CompanyID != CompanyID)
                    {
                        Friends.Add(Companies[i].Company);
                    }
                    else
                    {
                        Friends.Add(Companies[i].CompanyFriend);
                    }
                }
                for(int i = 0; i < FriendCompanies.Count(); i++)
                {
                    if(FriendCompanies[i].Company.CompanyID != CompanyID)
                    {
                        Friends.Add(FriendCompanies[i].Company);                        
                    }
                    else
                    {
                        Friends.Add(FriendCompanies[i].CompanyFriend);
                    }
                }
            }
            Friends = Friends.GroupBy(c => c.CompanyID).Select(c => c.First()).ToList();
            for(int i = 0; i < Friends.Count(); i++)
            {
                Friends[i].Companies = null;
                Friends[i].FriendCompanies = null;
                Friends[i].PatientCases = null;
            }
            Companies = null;
            FriendCompanies = null;
            RemoveUnregisteredFriends();
        }
    }    
}