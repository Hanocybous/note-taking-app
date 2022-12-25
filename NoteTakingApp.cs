using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteTakingApp
{
    
    // Class to store the note
    public class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Note()
        {
            Title = "";
            Content = "";
        }

        public Note (string title, string content)
        {
            Title = title;
            Content = content;
        }

        public override string ToString()
        {
            return Title;
        }

        // Method to display the note
        public void Display()
        {
            Console.WriteLine("Title: " + Title + ", Content: " + Content);
        }

        // Method to edit the note
        public void Edit()
        {
            Console.Write("Enter the new title: ");
            Title = Console.ReadLine();
            Console.Write("Enter the new content: ");
            Content = Console.ReadLine();
        }

    }

    // Class to store the list of notes
    public class NoteList
    {
        public List<Note> Notes { get; set; }

        public NoteList()
        {
            Notes = new List<Note>();
        }

        // Method to add a note to the list
        public void AddNote()
        {
            Note note = new Note();
            Console.Write("Enter the title: ");
            note.Title = Console.ReadLine();
            Console.Write("Enter the content: ");
            note.Content = Console.ReadLine();
            Notes.Add(note);
        }

        // Method to display all the notes
        public void DisplayAllNotes()
        {
            foreach (Note note in Notes)
            {
                note.Display();
                Console.WriteLine();
            }
        }

        // Method to display a note
        public void DisplayNote()
        {
            Console.Write("Enter the title of the note: ");
            string title = Console.ReadLine();
            Note note = Notes.Find(x => x.Title == title);
            if (note != null)
            {
                note.Display();
            }
            else
            {
                Console.WriteLine("Note not found");
            }
        }

        // Method to edit a note
        public void EditNote()
        {
            Console.Write("Enter the title of the note: ");
            string title = Console.ReadLine();
            Note note = Notes.Find(x => x.Title == title);
            if (note != null)
            {
                note.Edit();
            }
            else
            {
                Console.WriteLine("Note not found");
            }
        }

        // Method to delete a note
        public void DeleteNote()
        {
            Console.Write("Enter the title of the note: ");
            string title = Console.ReadLine();
            Note note = Notes.Find(x => x.Title == title);
            if (note != null)
            {
                Notes.Remove(note);
            }
            else
            {
                Console.WriteLine("Note not found");
            }
        }

        // Method to search a note
        public void SearchNote()
        {
            Console.Write("Enter the keyword to search: ");
            string keyword = Console.ReadLine();
            var result = Notes.Where(x => x.Title.Contains(keyword) || x.Content.Contains(keyword));
            if (result.Count() > 0)
            {
                foreach (Note note in result)
                {
                    note.Display();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No note found");
            }
        }

    }

    // Class to display the menu
    public class Menu
    {
        public void Display()
        {
            Console.WriteLine("1. Add a note");
            Console.WriteLine("2. Display all notes");
            Console.WriteLine("3. Display a note");
            Console.WriteLine("4. Edit a note");
            Console.WriteLine("5. Delete a note");
            Console.WriteLine("6. Search a note");
            Console.WriteLine("7. Exit");
        }
    }

    // Class to handle the user input
    public class Input
    {
        public int GetInput()
        {
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
    }

    // Class to handle the application
    public class Application
    {
        public NoteList NoteList { get; set; }
        public Menu Menu { get; set; }
        public Input Input { get; set; }

        public Application()
        {
            NoteList = new NoteList();
            Menu = new Menu();
            Input = new Input();
        }

        // Method to start the application
        public void Start()
        {
            int choice = 0;
            while (choice != 7)
            {
                Menu.Display();
                choice = Input.GetInput();
                switch (choice)
                {
                    case 1:
                        NoteList.AddNote();
                        break;
                    case 2:
                        NoteList.DisplayAllNotes();
                        break;
                    case 3:
                        NoteList.DisplayNote();
                        break;
                    case 4:
                        NoteList.EditNote();
                        break;
                    case 5:
                        NoteList.DeleteNote();
                        break;
                    case 6:
                        NoteList.SearchNote();
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using the application");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

    // Class to run the application
    public class NoteTakingApp
    {
        public static void Main(string[] args)
        {
            Application app = new Application();
            app.Start();
        }
    }
    
}
