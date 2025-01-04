using System.Text.Json;
using Planner.App.Models;

namespace Planner.App.Services;
public class UserStorage : IUserStorage
{
    UserProfile? UserProfile;
    List<BaseValue> BaseValues;

    public UserStorage()
    {
        BaseValues = [];
        var storageReturn = Task.Run(async () => await SecureStorage.GetAsync(nameof(UserProfile))).Result;
        if (!string.IsNullOrEmpty(storageReturn))
        {
            UserProfile = JsonSerializer.Deserialize<UserProfile>(storageReturn);
            var historicReturn = Task.Run(async () => await SecureStorage.GetAsync(nameof(BaseValues))).Result;
            if (!string.IsNullOrEmpty(historicReturn))
                BaseValues = JsonSerializer.Deserialize<List<BaseValue>>(historicReturn);
        }
        else
            UserProfile = null;
    }

    public UserProfile? GetUserProfile() => UserProfile;
    public List<BaseValue> GetBaseValues() => BaseValues;

    public void AddValue(BaseValue value) => BaseValues.Add(value);
    public void AddValues(IEnumerable<BaseValue> value) => BaseValues.AddRange(value);

    public void Dispose() => Task.Run(async () => await SecureStorage.SetAsync(nameof(BaseValues), JsonSerializer.Serialize(BaseValues)));
}
