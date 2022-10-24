
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

var appPath = "C:\\Users\\User\\Desktop\\HM\\HW9\\HW9\\HW9\\PhoneBook.csv";
var phonebook = TextPhoneBook(appPath);
AddPhoneBook(appPath);
phonebook = TextPhoneBook(appPath);
Console.WriteLine("Пошук по контактам. Ведiть данi:");
var first = SearchPeople(Console.ReadLine(), phonebook);
Console.WriteLine($"{(first.Any() ? $"{string.Join("\r\n", first)}" : "No castoms")}");

(string, string, string)[] SearchPeople(
    string input,
    List<(string, string, string)> collection) =>

    collection.Where(person =>
    person.Item1.Contains(input, StringComparison.OrdinalIgnoreCase) ||
    person.Item2.Contains(input, StringComparison.OrdinalIgnoreCase) ||
    person.Item3.Contains(input)).ToArray();


List<(string FirstName, string LastName, string PhoneNumber)> TextPhoneBook(string path)
{
    var book = new List<(string FirstName, string LastName, string PhoneNumber)>();
    var lines = File.ReadAllLines(path);
    foreach (var line in lines)
    {
        var split = line.Split(",");
        book.Add((split[0], split[1], split[2]));
    }

    return book;
}

void AddPhoneBook(string path)
{
    InputValue(out var firstname, "Iм'я");
    InputValue(out var lastname, "Прiзвище");
    InputValue(out var phonenumber, "Номер телефона");

    File.AppendAllLines(
        path,
        new[] { $"{firstname}, {lastname}, {phonenumber}" });
}
void InputValue(out string result, string Name)
{
    Console.WriteLine($"Ведiть {Name}");
    result = Console.ReadLine();
    Console.WriteLine($"{Name}: {result} ");
}

