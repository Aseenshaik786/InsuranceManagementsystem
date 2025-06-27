using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using InsuranceManagementSystem.Entity;

namespace InsuranceManagementSystem.DAO
{
    public interface IPolicyService
    {
        bool CreatePolicy(Client client);
        Client GetPolicy(int clientId);
        List<Client> GetAllPolicies();
        bool UpdatePolicy(Client client);
        bool DeletePolicy(int clientId);
    }
}