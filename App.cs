using Planner.App.Models;
using Planner.App.Pages;
using Planner.App.Services;

namespace Planner.App;

public partial class App : Application
{
    public App(IUserStorage userStorage)
    {
        if (string.IsNullOrEmpty(Task.Run(async () => await SecureStorage.Default.GetAsync(nameof(UserProfile))).Result))
            this.ChangeToBeginingPage();
        else
            this.ChangeToMainPage();
        UserStorage = userStorage;
    }

    public IUserStorage UserStorage { get; }

    public void ChangeToMainPage() => MainPage = new HomePage(UserStorage);
}

public static class ApplicationExtension
{
    public static void ChangeToBeginingPage(this Application app) => app.MainPage = new BeginingPage();
    public static void ChangeToMainPage(this Application app) => app.ChangeToMainPage();
}
