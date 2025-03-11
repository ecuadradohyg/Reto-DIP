/*Para aplicar el principio de responsabilidad unica se debe definir tres clases concretas que tendrán como unica responsabilidad trabajar con su respectivo objeto */

using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Library library = new Library("libro1", "autor", 12, "nombre", "id", "email");
    }
}

class Library
{
    public Library(string title, string author, int copies, string name, string id, string email)
    {
        BooksRepository book = new BooksRepository();
        book.books = new List<string>();
        book.AddBook(title, author, copies);
        Console.WriteLine("Libros: " + book.books.);

        UsersRepository user = new UsersRepository();
        user.users = new List<string>();
        user.AddUser(name, id, email);
        Console.WriteLine("Usuarios: " + user.users);

        LoansRepository loan = new LoansRepository();
        loan.loans = new List<string>();
    }
}

// Clase con la responsabilidad de gestionar libros
class BooksRepository
{
    public List<string> books;

    public void AddBook(string title, string author, int copies)
    {
        books.Add(title);
        books.Add(author);
        books.Add(copies.ToString());
    }
}

// Clase con la responsabilidad de gestionar usuarios
class UsersRepository
{
    public List<string> users;

    public void AddUser(string name, string id, string email)
    {
        users.Add(name);
        users.Add(id);
        users.Add(email);
    }
}

// Clase con la responabilidad unica de realizar prestamos de libros
class LoansRepository
{
    public List<string> loans;

    BooksRepository book = new BooksRepository();

    public bool LoanBook(string userId, string bookTitle)
    {
        foreach (var book in book.books)
        {
            if (book[0].ToString() == bookTitle && int.Parse(book[2].ToString()) > 0)
            {
                string copies = book[2].ToString();
                copies = (int.Parse(book[2].ToString()) - 1).ToString();
                loans.Add(userId);
                return true;
            }
        }
        return false;
    }
}

// Clase con la unica responsablilidad de la devolucion de libros
class ReturnsRepository
{
    LoansRepository loan = new LoansRepository();

    BooksRepository book = new BooksRepository();

    public bool ReturnBook(string userId, string bookTitle)
    {
        for (int i = 0; i < loan.loans.Count; i++)
        {
            if (loan.loans[i][0].ToString() == userId && loan.loans[i][1].ToString() == bookTitle)
            {
                loan.loans.RemoveAt(i);
                foreach (var book in book.books)
                {
                    if (book[0].ToString() == bookTitle)
                    {
                        string copies = book[2].ToString();
                        copies = (int.Parse(book[2].ToString()) + 1).ToString();
                        return true;
                    }
                }
            }
        }
        return false;
    }
}