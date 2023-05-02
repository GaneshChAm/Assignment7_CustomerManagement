namespace Assignment7_CustomerManagement
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
    class Management
    {
        List<Customer> list;       
        public Management()
        {
            list = new List<Customer>()
            {
                new Customer{Id = 1111,FirstName ="Chaitanya",LastName ="Priya",Email="chaitu@gmail.com",Age=21,Phone="9988776655",City="NRT"},
                new Customer{Id = 2222,FirstName ="Amurutha",LastName ="Varshini",Email="ammulu@gmail.com",Age=19,Phone="9955667788",City="MCM"}
            };
        }
        public void AddCustomer(Customer customer)
        {
            list.Add(customer);
        }
        public int CustomerId()
        {
            Random rand = new Random();
            int random = rand.Next(1000, 9999);
            return random;
        }
        public Customer GetCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }
        public List<Customer> GetAllCustomers()
        {
            return list;
        }
        public bool DeleteCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    list.Remove(c);
                    return true;
                }
            }
            return false;
           
        }
        public void UpdateCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter Updated Customer FirstName");
                    c.FirstName = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Updated Customer LastName");
                    c.LastName = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Updated Customer email");
                    c.Email = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Updated Customer age");
                    c.Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Updated Customer Phone Number");
                    c.Phone = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter Customer updated city");
                    c.City = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Customer Details Updated Successfully");
                }

            }
        }
           
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management obj = new Management();
            string ret = "y";
            do
            {
                Console.WriteLine("Welcome to Customer Management Application Service");
                Console.WriteLine("1. Add New Customer Details");
                Console.WriteLine("2. Get Customer Details by Id");
                Console.WriteLine("3. Get all Customers Details");
                Console.WriteLine("4. Delete  aCustomer by Id");
                Console.WriteLine("5. Update a Customer by Id");
                
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the Customer First Name");
                            string fn = Console.ReadLine();
                            Console.WriteLine("Enter the Customer Last Name");
                            string ln = Console.ReadLine();
                            Console.WriteLine("Enter the Customer Email Id");
                            string ei = Console.ReadLine();
                            Console.WriteLine("Enter the Customer Age");
                            int age = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Enter the Customer Phone Number");
                            string phn = Console.ReadLine();
                            Console.WriteLine("Enter the Customer City");
                            string city = Console.ReadLine();
                            int cid = obj.CustomerId();
                            Console.WriteLine($"Your Customer ID is {cid}");
                            obj.AddCustomer(new Customer() { Id = cid, FirstName = fn, LastName = ln, Email = ei, Age = age, Phone = phn, City = city });                          
                            Console.WriteLine("Customer Added Successfully");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? c = obj.GetCustomer(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer ID does not exists!");
                            }
                            else
                            {
                                Console.WriteLine($"Customer Details of Id-{c.Id} :");
                                Console.WriteLine($"First Name: {c.FirstName}\nLast Name: {c.LastName}\nEmail: {c.Email}\nAge: {c.Age}\nPhone Number: {c.Phone}\nCity: {c.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ID\tFirst Name\tLast Name\tEmail ID\tAge\tPhone Number\tCity");
                            foreach (var c in obj.GetAllCustomers())
                            {
                                Console.WriteLine($"{c.Id} \t{c.FirstName} \t{c.LastName}  \t{c.Email}  \t{c.Age} \t{c.Phone} \t{c.City}");

                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer not exist");
                            }
                            break;
                        }
                     case 5:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            obj.UpdateCustomer(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }

                }
             Console.WriteLine("Do you wish to continue? [y/n] ");
             ret = Console.ReadLine();
            }while (ret.ToLower() == "y");
        }
    }
    
}