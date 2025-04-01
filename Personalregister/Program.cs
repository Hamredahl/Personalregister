namespace Personalregister
{
    internal class Program
    {  
        static List<object> register = new List<object> ();
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till ett simpelt personalregister! \n\nFör att lägga till personal, skriv: add:'fullständigt namn':'lön' \nFör att skriva ut personalregister, skriv: print \nFör att avsluta programmet, skriv: exit\n" );
            bool running = true;
            while (running) 
            {
                string[] input = Console.ReadLine().Split(':');
                switch (input[0])
                {
                    case "add":
                        try
                        {
                            addEmployee(input[1], Convert.ToInt32(input[2]));
                        } catch
                        {
                            Console.WriteLine("Kunde inte skapa personal.");
                        }
                        break;
                    case "print":
                        printRegister();
                        break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Okänt kommando, försök igen.");
                        break;
                }
            }
        }

        public static void addEmployee(string name, int salary)
        {
            Employee employee = new Employee(name, salary); 
            register.Add(employee);
            Console.WriteLine(employee.name + " tillagd i registret med " + employee.salary + " i lön. \n");
        }

        public static void printRegister()
        {
            Console.WriteLine("\nPersonalregister:");
            foreach (Employee employee in register)
            {
                Console.WriteLine(employee.name + ", " + employee.salary);
            }
            Console.WriteLine("");
        }
    }

    internal class Employee
    {
        public string name;
        public int salary;
        public Employee (string n, int s)
        {
            name = n;
            salary = s;
        }
    }
}
