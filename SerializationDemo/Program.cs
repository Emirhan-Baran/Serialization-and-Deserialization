using System.IO;
using System.Xml.Serialization;
using System.Text.Json;


    Person newPerson = new Person("Alex",30);

    FileStream fs = new FileStream("person.dat",FileMode.Create);
    
    BinaryWriter bw = new BinaryWriter(fs);
    bw.Write(newPerson.UserName);
    bw.Write(newPerson.UserAge);

    bw.Close();
    fs.Close();

    Console.WriteLine("Binary Serilaziation is completed bro.");

XmlSerializer xmlSer = new XmlSerializer(typeof(Person));
FileStream xmlfs = new FileStream("person.xml",FileMode.Create);
xmlSer.Serialize(xmlfs,newPerson);

xmlfs.Close();
Console.WriteLine("Xml Serialization is completed bro.");

string json = JsonSerializer.Serialize(newPerson);
File.WriteAllText("person.json",json);
Console.WriteLine("Json Serializetion is completed bro.");


public class Person
{
   public string UserName { get; set; }   
    public int UserAge { get; set; }

public Person(string name,int  age)
    {
        UserName=name;
        UserAge=age;
    }
public Person()
    {
    }
    

}