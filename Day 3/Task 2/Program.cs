using System;

namespace Task_2
{
    class Program
    {
        static void Main()
        {
            Library library = new Library("Abrehot Library", "4 kilo, Addis Ababa");

            // Adding books and media items to the library
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 1925);
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", 1960);
            library.AddBook(book1);
            library.AddBook(book2);

            MediaItem movie1 = new MediaItem("Inception", "Movie", 148);
            MediaItem musicAlbum1 = new MediaItem("Thriller", "Music", 42);
            library.AddMediaItem(movie1);
            library.AddMediaItem(musicAlbum1);

            // Display the catalog
            Console.WriteLine("Library Catalog:");
            library.PrintCatalog();
        }
    }
}