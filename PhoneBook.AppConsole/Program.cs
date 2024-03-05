// добавим библиотеку для работы со строкой подключения (в виде json-файла)
// название библиотеки Microsoft.Extensions.Configuration.Json
// создаем json-файл (appsettings.json) и прописываем там строку подключения
// затем добавляем название файла (appsettings.json) в .gitignore
// в свойствай файла appsettings.json отмечаем Copy_if_Newer, вместо Do_not_copy

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.DbLib;
using PhoneBook.Model;

var builder = new ConfigurationBuilder();
// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");
// создаем конфигурацию
var config = builder.Build();
// получаем строку подключения
var connectionString = config.GetConnectionString("DefaultConnection");

var db = new PhoneBookContext(connectionString);
/*var person1 = new Person()
{
    LastName = "Ivanov",
    FirstName = "Ivan",
    
};

var phone1 = new Phone()
{
    Type = PhoneType.Mobile,
    Number = "+79112222222",
    Person = person1
};
var phone2 = new Phone()
{
    Type = PhoneType.Home,
    Number = "+73952444444",
    Person = person1
};

db.Phones.Add(phone1);
db.Phones.Add(phone2);
db.Persons.Add(person1);
db.SaveChanges();*/
//var persons = db.Persons.Include(p => p.Phones).ToList();
foreach (var p in db.Persons.ToList())
{
    Console.WriteLine($"{p.Id}:{p.LastName} {p.FirstName}, PHONES:");
    foreach (var ph in db.Phones.ToList())
    {
        Console.Write($"{ph.Type.ToString()} {ph.Number}, ");
    }
}