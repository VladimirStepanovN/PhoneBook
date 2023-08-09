namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //создаем телефонную книгу с контактами
            List<Contact> phoneBook = new()
            {
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            };

            while (true)
            {
                Console.WriteLine("Введите номер страницы от 1 до 3");
                var input = Console.ReadKey().KeyChar;
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine("Страницы не существует");
                    Console.WriteLine();
                }
                else
                {
                    var pageContent = phoneBook.OrderBy(contact => contact.Name)
                        .ThenBy(contact => contact.LastName)
                        .Skip((pageNumber - 1) * 2)
                        .Take(2);
                    Console.WriteLine();
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
                    Console.WriteLine();
                }
            }
        }
    }
}