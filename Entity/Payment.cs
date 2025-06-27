using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
        public int ClientId { get; set; }

        public Payment() { }

        public Payment(int paymentId, DateTime paymentDate, double paymentAmount, int clientId)
        {
            PaymentId = paymentId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentAmount;
            ClientId = clientId;
        }

        public override string ToString() => $"{PaymentId}, {PaymentDate.ToShortDateString()}, {PaymentAmount}, {ClientId}";
    }
}
