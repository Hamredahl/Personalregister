namespace Personalregister
{
    internal class Program
    {  
        static List<object> register = new List<object> ();
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till ett simpelt personalregister! \nSkriv help för en lista med kommandon.\n" );
            bool running = true;
            while (running) 
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "help":
                        Console.WriteLine("\nKommandolista:\nadd\n   Lägg till ny personal.\nprint\n   Skriv ut personalregistret.\nclear\n   Rensa konsolen på tidigare text.\nexit\n   Avsluta programmet.\n");
                        break;
                    case "add":
                            Console.Write("Personens namn: ");
                            string name = Console.ReadLine();
                            Console.Write("Personens lön: ");
                            string salary = Console.ReadLine();
                            addEmployee(name, salary);
                        break;
                    case "print":
                        printRegister();
                        break;
                    case "clear":
                        Console.Clear();
                        Console.WriteLine("Välkommen till ett simpelt personalregister! \nSkriv help för en lista med kommandon.\n");
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

        public static void addEmployee(string name, string salary)
        {
            try
            {
                if (name.Length < 1) {throw new ArgumentOutOfRangeException(nameof(name));}
                Employee employee = new Employee(name, Convert.ToInt32(salary));
                register.Add(employee);
                Console.WriteLine(employee.name + " tillagd i registret med " + employee.salary + " i lön. \n");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Kunde ej skapa personal:\n   Namn får ej vara tomt.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Kunde ej skapa personal:\n   Lön måste vara ett heltal.");
            }
        }

        public static void printRegister()
        {
            if (register.Count == 0) 
            { 
                Console.WriteLine("Det finns ingen personal i registret ännu."); 
            }
            else
            {
                Console.WriteLine("\nPersonalregister:");
                foreach (Employee employee in register)
                {
                    Console.WriteLine(employee.name + ", " + employee.salary);
                }
                Console.WriteLine("");
            }
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
