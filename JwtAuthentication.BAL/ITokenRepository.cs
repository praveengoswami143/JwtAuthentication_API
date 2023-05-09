namespace JwtAuthentication.BAL
{
    public interface ITokenRepository
    {
        string CreateJWTToken(string username, List<string> roles);
    }
}