namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IOrganizationService
{
    Task CreateOrganizationAsync();

    Task GetOrganizationByIdAsync(long id);

    Task GetListOfOrganizations();

    Task DeleteOrganization(long id);
}