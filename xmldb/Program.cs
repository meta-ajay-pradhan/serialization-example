using System.Xml.Serialization;

[XmlRoot(ElementName = "Employee")]
public class Employee
{
    [XmlAttribute("name")]
    public string? Name { get; set; }
}
public class Program
{

    public static void serialize(List<Employee> employees, string xmlFilePath)
    {

        XmlSerializer xmlSerializer = new XmlSerializer(employees.GetType());
        using (StreamWriter writer = new StreamWriter(xmlFilePath))
        {
            xmlSerializer.Serialize(writer, employees);
        }

    }

    public static List<Employee>? deserialize(string xmlFilePath)
    {
        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            using (StreamReader reader = new StreamReader(xmlFilePath))
            {
                return (List<Employee>?)xmlSerializer.Deserialize(reader);
            }
        }
        catch (InvalidOperationException e)
        {
            return new List<Employee>();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static void Main(string[] args)
    {
        string xmlFilePath = "employee.xml";
        List<Employee>? employees = deserialize(xmlFilePath);

        while (true)
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All Employee");
            Console.WriteLine("3. Exit");
            Console.Write(">> ");
            string? option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string? name = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name))
                    {
                        throw new InvalidDataException();
                    }
                    Employee? employee = new Employee() { Name = name };
                    employees?.Add(employee);
                    serialize(employees!, xmlFilePath);
                    Console.WriteLine("Added and Saved!!");
                    break;
                case "2":
                    List<Employee>? employees1 = deserialize(xmlFilePath);
                    foreach (Employee emp in employees1!)
                    {
                        Console.WriteLine(emp.Name);
                    }
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    throw new InvalidOperationException();
            }
            Console.Write("---------------PRESS ENTER-------------------");
            Console.ReadLine();

        }
    }
}