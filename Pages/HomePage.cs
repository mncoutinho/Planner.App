using Planner.App.Models;
using Planner.App.Services;

namespace Planner.App.Pages;

public partial class HomePage : ContentPage
{
    Button logoutButton;
    Grid layout;

    public HomePage(IUserStorage userStorage)
    {
        BackgroundColor = Color.FromArgb("078715");
        Title = $"Olá {userStorage.GetUserProfile().NickName}";
        var rowsDefitions = new List<RowDefinition>() { new() { Height = new GridLength(100) } };
        var baseValues = userStorage.GetBaseValues();
        baseValues.ForEach(row => rowsDefitions.Add(new()));
        var typeofBaseValue = typeof(BaseValue);
        layout = new Grid
        {
            Margin = new Thickness(15, 15, 15, 15),
            Padding = new Thickness(10),
            RowDefinitions = new([.. rowsDefitions]),
            ColumnDefinitions = new(typeofBaseValue.GetProperties().Select(e => new ColumnDefinition()).ToArray())

        };

        layout.Add(new Label() { Text = $"Olá {userStorage.GetUserProfile().NickName}", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center });
        typeofBaseValue.GetProperties().Select(e => e.Name).ToList().ForEach(e => layout.Add(new Label() { Text = e, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center }));
        baseValues.ForEach(e => typeofBaseValue.GetProperties().ToList().ForEach(p => layout.Add(new Label() { Text = p.GetValue(e)?.ToString(), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center })));
        logoutButton = new Button { Text = "Logout", BackgroundColor = Color.FromRgb(0, 148, 255), VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.CenterAndExpand, HeightRequest = 200 };
        layout.Children.Add(logoutButton);

        Content = layout;

        logoutButton.Clicked += (sender, e) =>
        {
            SecureStorage.Default.RemoveAll();
            Application.Current.ChangeToBeginingPage();
        };
    }
}
