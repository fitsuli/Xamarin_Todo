using System;
using System.Collections.Generic;
using Todo.Models;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Todo.Views
{
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();

            var preflist = new List<TodoItem>();
            var i = 0;
            while (Preferences.ContainsKey(i.ToString()))
            {
                preflist.Add(new TodoItem
                {
                    ID = i,
                    Name = Preferences.Get(i.ToString(), "nothing"),
                    Done = Preferences.Get(i.ToString() + "_status", true),
                });
                i++;
            }

            listView.ItemsSource = preflist;
        }

        async void OnItemAddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = new TodoItem()

            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage
                {
                    BindingContext = e.SelectedItem as TodoItem,
                    isInEditMode = true
                });
                listView.SelectedItem = null;
            }
        }
    }
}
