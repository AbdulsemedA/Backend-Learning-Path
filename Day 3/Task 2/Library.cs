namespace Task_2
{
    class Library {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public List<Book> Books { get; private set; }
        public List<MediaItem> MediaItems { get; private set; }

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
        }

        public void RemoveMediaItem(MediaItem item)
        {
            MediaItems.Remove(item);
        }

        // public void PrintCatalog()
        // {
        //     Console.WriteLine($"Library Name: {Name}");
        //     Console.WriteLine($"Address: {Address}\n");

        //     Console.WriteLine("Books:");
        //     foreach (var book in Books)
        //     {
        //         Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
        //     }

        //     Console.WriteLine("\nMedia Items:");
        //     foreach (var item in MediaItems)
        //     {
        //         Console.WriteLine($"Title: {item.Title}, Type: {item.MediaType}, Length: {item.Duration}");
        //     }
        // }
        public void PrintCatalog()
        {
            Console.WriteLine($"{"=".PadLeft(60, '=')}"); // Top line
            Console.WriteLine($"{Name.ToUpper()} - CATALOG".PadLeft(60));
            Console.WriteLine($"{"=".PadLeft(60, '=')}"); // Middle line

            Console.WriteLine("Books:");
            foreach (var book in Books)
            {
                Console.WriteLine($"- {book.Title} by {book.Author} ({book.PublicationYear}), ISBN: {book.ISBN}");
            }

            Console.WriteLine("Media Items:");
            foreach (var item in MediaItems)
            {
                Console.WriteLine($"- {item.Title} ({item.MediaType}), Duration: {item.Duration} minutes");
            }

            Console.WriteLine($"{"=".PadLeft(60, '=')}"); // Bottom line
        }
    }

}