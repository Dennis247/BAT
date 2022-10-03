using BAT.api.Models.Dtos.TeamDtos;

namespace BAT.api.Models.Dtos.AccountDtos;

public class AccountResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public bool IsVerified { get; set; }
    public bool IsOnline { get; set; }
    public DateTime LastTimeLoggedIn { get; set; }

    public IEnumerable<int> Teams { get; set; }
   // public List<PermissionDtos.PermissionDto> UserPermissions { get; set; }
}