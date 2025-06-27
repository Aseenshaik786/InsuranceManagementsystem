using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InsuranceManagementSystem.Entity;
using InsuranceManagementSystem.Exceptions;
using InsuranceManagementSystem.Util;

namespace InsuranceManagementSystem.DAO
{
    public class InsuranceServiceImpl : IPolicyService
    {
        private readonly SqlConnection conn = DBConnUtil.GetConnection("config");

        public bool CreatePolicy(Client client)
        {
            string query = "INSERT INTO Client VALUES (@id, @name, @contact, @policy)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", client.ClientId);
            cmd.Parameters.AddWithValue("@name", client.ClientName);
            cmd.Parameters.AddWithValue("@contact", client.ContactInfo);
            cmd.Parameters.AddWithValue("@policy", client.Policy);
            return cmd.ExecuteNonQuery() > 0;
        }

        public Client GetPolicy(int clientId)
        {
            string query = "SELECT * FROM Client WHERE ClientId = @id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", clientId);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Client(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                );
            }
            throw new PolicyNotFoundException($"Client with ID {clientId} not found.");
        }

        public List<Client> GetAllPolicies()
        {
            string query = "SELECT * FROM Client";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            List<Client> list = new List<Client>();
            while (reader.Read())
            {
                list.Add(new Client(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)));
            }
            return list;
        }

        public bool UpdatePolicy(Client client)
        {
            string query = "UPDATE Client SET ClientName=@name, ContactInfo=@contact, Policy=@policy WHERE ClientId=@id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", client.ClientId);
            cmd.Parameters.AddWithValue("@name", client.ClientName);
            cmd.Parameters.AddWithValue("@contact", client.ContactInfo);
            cmd.Parameters.AddWithValue("@policy", client.Policy);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DeletePolicy(int clientId)
        {
            string query = "DELETE FROM Client WHERE ClientId=@id";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", clientId);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
