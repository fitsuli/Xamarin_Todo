using System;
using System.Threading.Tasks;
using Todo.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Todo.Views
{
    public partial class TodoItemPage : ContentPage
    {
        public bool isInEditMode = false;
        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            if (!isInEditMode) while (Preferences.ContainsKey(todoItem.ID.ToString())) todoItem.ID++;
            Preferences.Set(todoItem.ID.ToString(), todoItem.Name);
            Preferences.Set(todoItem.ID.ToString() + "_status", todoItem.Done);
            await OpenListReloaded();
        }

        private async Task OpenListReloaded()
        {
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            Navigation.InsertPageBefore(new TodoListPage(), this);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            Preferences.Remove(todoItem.ID.ToString());
            await OpenListReloaded();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
