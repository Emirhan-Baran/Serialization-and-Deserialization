using System.Text.Json;
using System.Xml.Serialization;


Person newPerson = new Person("David",34);


try
{
FileStream fs = new FileStream("person.dat",FileMode.Create);
BinaryWriter bw = new BinaryWriter(fs);
bw.Write(newPerson.UserName);
bw.Write(newPerson.UserAge);
bw.Close();
fs.Close();

FileStream fsRead = new FileStream("person.dat",FileMode.Open);
BinaryReader br = new BinaryReader(fsRead);
string readName= br.ReadString();
int readAge = br.ReadInt32();
Person readPerson = new Person(readName,readAge);
br.Close();
fsRead.Close();
Console.WriteLine($"Name: {readPerson.UserName}, Age: {readPerson.UserAge}");
}
catch(Exception ex)
{
    Console.WriteLine("Binary error: " + ex.Message);
}


try
{
FileStream fsXmlwrite =new FileStream("person.xml",FileMode.Create);
XmlSerializer xmlSerWrite= new XmlSerializer(typeof(Person));
xmlSerWrite.Serialize(fsXmlwrite,newPerson);
fsXmlwrite.Close();

FileStream fsxml=new FileStream("person.xml",FileMode.Open);
XmlSerializer xmlSer= new XmlSerializer(typeof(Person));
Person readXml = (Person)xmlSer.Deserialize(fsxml);
fsxml.Close();
Console.WriteLine($"Read from Xml , Name:{readXml.UserName} Age: {readXml.UserAge}");
}
catch(Exception ex)
{
     Console.WriteLine("Xml error: " + ex.Message);
}


try
{
string jsonString=JsonSerializer.Serialize(newPerson);
File.WriteAllText("person.json",jsonString);

string readJson=File.ReadAllText("person.json");
Person readJsonPerson = JsonSerializer.Deserialize<Person>(readJson);
Console.WriteLine($"Read from Json, Name: {readJsonPerson.UserName}, Age: {readJsonPerson.UserAge}");
}
catch(Exception ex)
{
    Console.WriteLine("Json error: " + ex.Message);
    
}

 public class Person
{
    public string UserName {get; set;}
    public int UserAge {get; set;}

    public Person(string name , int age)
    {
        UserName=name;
        UserAge=age;
    }

    public Person()
    {  
    }
}