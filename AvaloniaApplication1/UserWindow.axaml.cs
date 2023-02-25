using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Metsys.Bson;

namespace AvaloniaApplication1;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        InitializeComponent();
        LoadData();
    }

    public void LoadData()
    {
        UsersDataGrid.Items = Helper.GetContext().Users.Include(q=>q.IdRolesNavigation).ToList();
        RoleCBox.Items = Helper.GetContext().Roles.ToList();
        RoleCBox.SelectedIndex = 0;
    }
    private void EditUserBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Helper.GetContext().SaveChanges();
    }

    private void DeleteUserBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = UsersDataGrid.SelectedItem as Models.User;
        Helper.GetContext().Users.Remove(user);
        Helper.GetContext().SaveChanges();
        LoadData();
    }

    private void AddUserBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var role = RoleCBox.SelectedItem as Models.Role;
        var user = new Models.User()
        {
            Login = (string.IsNullOrWhiteSpace(LoginTBox.Text)) ? "q" : LoginTBox.Text,
            Password = (string.IsNullOrWhiteSpace(PasswordTBox.Text)) ? "q" : PasswordTBox.Text,
            IdRolesNavigation = role,
        };
        Helper.GetContext().Users.Add(user);
        Helper.GetContext().SaveChanges();
        LoadData();
    }
}