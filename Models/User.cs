using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DocShare.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        [NotMapped]
        public string ConfirmPassword {get;set;}
        public string PhoneNumber {get;set;}
        public int CompanyID {get;set;}
        public Company Company {get;set;}
        public int AdminLevelID {get;set;}
        public AdminLevel AdminLevel {get;set;}
        public DateTime? CreatedAt {get;set;}
        public DateTime? UpdatedAt {get;set;}
        public string ActivationCode {get;set;}
        [NotMapped]
        public List<AdminLevel> AdminLevels {get;set;}
        [NotMapped]
        public List<CompanyType> CompanyTypes {get;set;}

        public void GenerateActivationCode()
        {
            ActivationCode = "";

            for(int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                char Character = (char)rand.Next(65, 90);
                ActivationCode += Character;
            }
        }

        public void SendAccountActivationEmail()
        {
            Message msg = new Message()
            {
                Subject = "Contact Invitation",
                MessageContent = $"You have been invited to join Contact. Please follow the link to set up your account: https:/contactcontactdentaldev.azurewebsites.net/register/{ActivationCode}"
            };

            Emailer email = new Emailer();
            email.SendEmail(msg, Email);
        }

        public void SetNewUser()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Company.PhoneNumber = PhoneNumber;
            Company.CreatedAt = DateTime.Now;
            Company.UpdatedAt = DateTime.Now;
        }

        public bool RegistrationSuccess()
        {
            if(Password != ConfirmPassword && Password != "")
            {
                return false;
            }
            // else if(RegistrationCode != "1234") 
            // {
            //     return false;
            // }
            else if(Company.CompanyTypeID == 0) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RemoveLoops()
        {
            for(int i = 0; i < Company.PatientCases.Count(); i++)
            {
                //remove loops in case logs
                for(int x = 0; x < Company.PatientCases[i].CaseLogs.Count(); x++)
                {
                    Company.PatientCases[i].CaseLogs[x].SetActionName();
                    Company.PatientCases[i].CaseLogs[x].User = null;
                }
                //remove loops in notes and pull needed data
                for(int x = 0; x < Company.PatientCases[i].CaseNotes.Count(); x++)
                {
                    Company.PatientCases[i].CaseNotes[x].SenderName = $"{Company.PatientCases[i].CaseNotes[x].User.FirstName} {Company.PatientCases[i].CaseNotes[x].User.LastName}";
                    Company.PatientCases[i].CaseNotes[x].CompanyTypeID = (int)Company.PatientCases[i].CaseNotes[x].User.Company.CompanyTypeID;
                    Company.PatientCases[i].CaseNotes[x].User = null;
                }
            }
        }
    }    
}