using Xamarin.Forms;
using Todo.Views;

namespace Todo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = (Color)Current.Resources["blue"]
            };
        }
    }
}
