using EncryptSolution;

namespace ProductApi.Dto;

public class UserDto
{
    [EncryptField]
    public string UserName { get; set; }
    [EncryptField]
    public string Password { get; set; }
    public string Role { get; set; }
}