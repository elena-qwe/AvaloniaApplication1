using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Metsys.Bson;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void LogInBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = Helper.GetContext().Users
            .FirstOrDefault(q => q.Login == LoginTBox.Text && q.Password == PasswordTBox.Text);
        if (user != null)
        {
            new UserWindow().Show();
            this.Close();
        }
    }
    
}