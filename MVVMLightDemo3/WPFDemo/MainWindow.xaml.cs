using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WPFDemo.Models;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TodoItem> TodoItems { get; set; }

        public MainWindow()
        {
            // Initialize the list with some data
            TodoItems = new List<TodoItem>
            {
                new TodoItem { Name = "Item 1", Description = "Description 1", Priority = 1 },
                new TodoItem { Name = "Item 2", Description = "Description 2", Priority = 2 },
                new TodoItem { Name = "Item 3", Description = "Description 3", Priority = 3 }
            };

            // Register the list as a resource
            // ATTENSION:
            // Resource must be registered before InitializeComponent() method is called!!!
            // This is not the best practice, but it is a simple way to pass data to the view
            this.Resources["TodoItemsCodeBehind"] = TodoItems;


            InitializeComponent();
        }
    }

    public class TodoItemCollection : ObservableCollection<TodoItem>
    {
    }
}
