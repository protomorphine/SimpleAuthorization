namespace SimpleAuthorization.Core.Dtos;

public class CreateUserDto
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string Fio { get; set; }
}
