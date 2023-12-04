// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        // Step 2: Binary Serialization and Deserialization
        Employee employee = new Employee
        {
            Id = 08,
            FirstName = "Soumya",
            LastName = "Sutar",
            Salary = 850000.0
        };

        // Binary Serialization
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream("employee.bin", FileMode.Create))
        {
            binaryFormatter.Serialize(fs, employee);
        }

        // Binary Deserialization
        using (FileStream fs = new FileStream("employee.bin", FileMode.Open))
        {
            Employee deserializedEmployee = (Employee)binaryFormatter.Deserialize(fs);
            Console.WriteLine("Binary Deserialization Result:");
            Console.WriteLine($"ID: {deserializedEmployee.Id}, Name: {deserializedEmployee.FirstName} {deserializedEmployee.LastName}, Salary: {deserializedEmployee.Salary}");
        }

        // Step 3: XML Serialization and Deserialization
        // XML Serialization
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
        using (TextWriter writer = new StreamWriter("employee.xml"))
        {
            xmlSerializer.Serialize(writer, employee);
        }

        // XML Deserialization
        using (TextReader reader = new StreamReader("employee.xml"))
        {
            Employee deserializedXmlEmployee = (Employee)xmlSerializer.Deserialize(reader);
            Console.WriteLine("\nXML Deserialization Result:");
            Console.WriteLine($"ID: {deserializedXmlEmployee.Id}, Name: {deserializedXmlEmployee.FirstName} {deserializedXmlEmployee.LastName}, Salary: {deserializedXmlEmployee.Salary}");
        }
    }
}
