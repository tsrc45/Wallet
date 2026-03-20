using WalletManagement.Core.Domain.Services.Communication;

namespace WalletManagement.Core.Domain.Services
{
    public interface IConfigurationService
    {
        Task<IList<string>> GetAllScopes();
        Task<IList<string>> GetAllGrantTypes();
        ConfigurationResponse SetConfiguration(
           string configName, object config);
        Task<ConfigurationResponse> SetConfigurationAsync(
                        string configName, object config, string updatedBy,
                        bool makerCheckerFlag = false);
        T GetPlainConfiguration<T>(string configName);
        T GetConfiguration<T>(string configName);
        Task<T> GetConfigurationAsync<T>(string configName);
        Task<string> GetActiveAuthenticationId();
        Task<ConfigurationResponse> UpdateDefaultAuthScheme(string Id);
    }
}
