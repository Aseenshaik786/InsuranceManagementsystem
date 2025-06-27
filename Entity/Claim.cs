using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public double ClaimAmount { get; set; }
        public string Status { get; set; }
        public string Policy { get; set; }
        public int ClientId { get; set; }

        public Claim() { }

        public Claim(int claimId, string claimNumber, DateTime dateFiled, double claimAmount, string status, string policy, int clientId)
        {
            ClaimId = claimId;
            ClaimNumber = claimNumber;
            DateFiled = dateFiled;
            ClaimAmount = claimAmount;
            Status = status;
            Policy = policy;
            ClientId = clientId;
        }

        public override string ToString() => $"{ClaimId}, {ClaimNumber}, {DateFiled.ToShortDateString()}, {ClaimAmount}, {Status}, {Policy}, {ClientId}";
    }
}