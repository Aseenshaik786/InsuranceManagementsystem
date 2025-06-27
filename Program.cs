using InsuranceManagementSystem.DAO;
using InsuranceManagementSystem.Entity;
using InsuranceManagementSystem.Exceptions;

namespace InsuranceManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPolicyService service = new InsuranceServiceImpl();

            while (true)
            {
                Console.WriteLine("\n--- Insurance Management System Menu ---");
                Console.WriteLine("1. Add Client Policy");
                Console.WriteLine("2. View Policy by Client ID");
                Console.WriteLine("3. View All Policies");
                Console.WriteLine("4. Update Client Policy");
                Console.WriteLine("5. Delete Client Policy");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Client ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Contact Info: ");
                            string contact = Console.ReadLine();
                            Console.Write("Enter Policy: ");
                            string policy = Console.ReadLine();
                            Client client = new Client(id, name, contact, policy);
                            Console.WriteLine(service.CreatePolicy(client) ? "Client added successfully" : "Failed to add client");
                            break;

                        case 2:
                            Console.Write("Enter Client ID to View: ");
                            int viewId = int.Parse(Console.ReadLine());
                            Client found = service.GetPolicy(viewId);
                            Console.WriteLine("Client Details: " + found);
                            break;

                        case 3:
                            var list = service.GetAllPolicies();
                            foreach (var c in list)
                                Console.WriteLine(c);
                            break;

                        case 4:
                            Console.Write("Enter Client ID to Update: ");
                            int upId = int.Parse(Console.ReadLine());
                            Console.Write("Enter New Name: ");
                            string upName = Console.ReadLine();
                            Console.Write("Enter New Contact: ");
                            string upContact = Console.ReadLine();
                            Console.Write("Enter New Policy: ");
                            string upPolicy = Console.ReadLine();
                            Client updateClient = new Client(upId, upName, upContact, upPolicy);
                            Console.WriteLine(service.UpdatePolicy(updateClient) ? "Updated successfully" : "Update failed");
                            break;

                        case 5:
                            Console.Write("Enter Client ID to Delete: ");
                            int delId = int.Parse(Console.ReadLine());
                            Console.WriteLine(service.DeletePolicy(delId) ? "Deleted successfully" : "Delete failed");
                            break;

                        case 6:
                            Console.WriteLine("Exiting application.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error: " + ex.Message);
                }
            }
        }
    }
}
