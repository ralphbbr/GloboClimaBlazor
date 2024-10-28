using Blazored.LocalStorage;

public class AuthService
{
    private readonly ILocalStorageService _localStorage;
    private string _cachedToken;

    public AuthService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        _cachedToken = await _localStorage.GetItemAsync<string>("jwt_token");
        return !string.IsNullOrEmpty(_cachedToken);
    }

    public async Task<string> GetTokenAsync()
    {
        return await _localStorage.GetItemAsync<string>("jwt_token");
    }
}
