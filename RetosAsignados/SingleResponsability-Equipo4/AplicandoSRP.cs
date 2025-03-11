/* Para aplicar el principio de responsabilidad unica se debe definir tres clases concretas que tendrán como unica responsabilidad trabajar con su respectivo objeto */

using System;
using System.Collections.Generic;

// Clase que gestiona los libros
class BookManager
{
    private List<string[]> books;

    public BookManager()
    {
        books = new List<string[]>();
    }

    public void AddBook(string title, string author, int copies)
    {
        books.Add(new string[] { title, author, copies.ToString() });
    }

    // Este método se ejecuta si se presta o se devuelve un libro
    public bool UpdateCopies(string title, int change)
    {
        // Recorrer lisa de libros
        foreach (var book in books)
        {
            if (book[0] == title)
            {
                int currentCopies = int.Parse(book[2]);
                if (currentCopies + change >= 0)
                {
                    book[2] = (currentCopies + change).ToString();
                    return true;
                }
            }
        }
        return false;
    }

    public bool BookExists(string title)
    {
        return books.Exists(book => book[0] == title);
    }
}

// Clase que gestiona los usuarios
class UserManager
{
    private List<string[]> users;

    public UserManager()
    {
        users = new List<string[]>();
    }

    public void AddUser(string name, string id, string email)
    {
        users.Add(new string[] { name, id, email });
    }
}

// Clase que gestiona los préstamos
class LoanManager
{
    // Lista de préstamos
    private List<string[]> loans;
    private BookManager bookManager;

    public LoanManager(BookManager bookManager)
    {
        this.bookManager = bookManager;
        loans = new List<string[]>();
    }

    // Prestar libro
    public bool LoanBook(string userId, string bookTitle)
    {
        if (bookManager.UpdateCopies(bookTitle, -1))
        {
            loans.Add(new string[] { userId, bookTitle });
            return true;
        }
        return false;
    }

    // Devolver libro
    public bool ReturnBook(string userId, string bookTitle)
    {
        // Para cada número de préstamos realizados
        for (int i = 0; i < loans.Count; i++)
        {
            if (loans[i][0] == userId && loans[i][1] == bookTitle)
            {
                loans.RemoveAt(i);
                bookManager.UpdateCopies(bookTitle, 1);
                return true;
            }
        }
        return false;
    }
}

// Clase Library que ahora actúa como intermediaria
class Library
{
    // Crear los objetos para cada clase que tiene una única responsabilidad
    private BookManager bookManager;
    private UserManager userManager;
    private LoanManager loanManager;

    // Constructor
    public Library()
    {
        bookManager = new BookManager();
        userManager = new UserManager();
        loanManager = new LoanManager(bookManager);
    }

    public void AddBook(string title, string author, int copies)
    {
        bookManager.AddBook(title, author, copies);
    }

    public void AddUser(string name, string id, string email)
    {
        userManager.AddUser(name, id, email);
    }

    public bool LoanBook(string userId, string bookTitle)
    {
        return loanManager.LoanBook(userId, bookTitle);
    }

    public bool ReturnBook(string userId, string bookTitle)
    {
        return loanManager.ReturnBook(userId, bookTitle);
    }
}

// Clase con método principal
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddUser("Jose", "U123", "jose@email.com");
        library.AddBook("libro1", "autor1", 3);

        if (library.LoanBook("U123", "libro1"))
            Console.WriteLine("Préstamo exitoso.");
        else
            Console.WriteLine("No se pudo realizar el préstamo");

        if (library.ReturnBook("U123", "libro1"))
            Console.WriteLine("Devolución exitosa.");
        else
            Console.WriteLine("No se pudo devolver el libro");
    }
}