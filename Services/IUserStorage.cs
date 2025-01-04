using Planner.App.Models;

namespace Planner.App.Services;
public interface IUserStorage
{
    void AddValue(BaseValue value);
    void AddValues(IEnumerable<BaseValue> value);
    void Dispose();
    List<BaseValue> GetBaseValues();
    UserProfile? GetUserProfile();
}