using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InsClaims.data
{
    public class ClaimFiled
    {
        public ClaimFiled()
        {
            DateOfIncident = DateTime.Now;
        }

        public ClaimFiled(ClaimType claimType, string claimDescription, decimal claimAmount, bool IsValid)
        {

            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = DateTime.Now;
        }

        public ClaimType ClaimType { get; set; } // enum
        public int OrderId { get; set; }

        public string ClaimDescription { get; set; } = string.Empty; // what the user will input
        public decimal ClaimAmount { get; set; }

        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan gracePeriod = DateOfClaim - DateOfIncident;
                if (gracePeriod.Days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Based on the date of claim and date of incident (within 30 days after an incident took place, anything passed that is not valid)

        public override string ToString()
        {
            string str = $"Claim Type: {ClaimType} \n" +
                        $"Order Id: {OrderId}\n" +
                        $"Claim Description: {ClaimDescription}\n" +
                        $"Claim Amount: {ClaimAmount}\n" +
                        $"Date of Incident: {DateOfClaim} \n"+
                        $"Date of Claim: {DateOfClaim} \n"+
                        $"Is Claim Valid? {IsValid}\n";
            return str;
        }
    }
}