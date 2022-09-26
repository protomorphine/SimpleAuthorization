using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Мапинг списка сущностей пользователь на список дто
    /// </summary>
    /// <param name="users">список сущностей - пользователь</param>
    /// <returns>Список дто</returns>
    public static List<UserDto> ToUserDtoList(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToUserDto()).ToList();
    }
}