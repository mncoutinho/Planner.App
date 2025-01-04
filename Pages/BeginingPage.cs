using System.Text.Json;
using Planner.App.Models;

namespace Planner.App;

public partial class BeginingPage : ContentPage
{
    Entry userNameEntry = new() { Placeholder = "Full Name" };
    Entry nickNameEntry = new() { Placeholder = "NickName" };
    Button nextButton;
    VerticalStackLayout layout;

    public BeginingPage()
    {
        BackgroundColor = Color.FromArgb("078715");

        layout = new VerticalStackLayout
        {
            Margin = new Thickness(150, 15, 150, 15),
            Padding = new Thickness(30, 60, 30, 30),
            Children =
        {
            new Label { Text = "Olá! É sua Primeira Vez aqui!", FontSize = 30, TextColor = Color.FromRgb(255, 255, 100) },
            new Label { Text = "Digite seu Nome Completo", TextColor = Color.FromRgb(255, 255, 255) },
            userNameEntry,
            new Label { Text = "Digite seu apelido", TextColor = Color.FromRgb(255, 255, 255) },
            nickNameEntry,
        }
        };

        nextButton = new Button { Text = "Seguir", BackgroundColor = Color.FromRgb(0, 148, 255) };
        nextButton.Clicked += (sender, e) =>
        {
            SetUserName(new(userNameEntry.Text, nickNameEntry.Text));
            Application.Current.ChangeToMainPage();
        };

        layout.Children.Add(nextButton);

        Content = layout;
    }

    void SetUserName(UserProfile profile) => Task.Run(async () => await SecureStorage.SetAsync(nameof(UserProfile), JsonSerializer.Serialize(profile)));
}
