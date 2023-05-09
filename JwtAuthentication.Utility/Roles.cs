namespace JwtAuthentication.Utility
{
    public static class Roles
    {
        public const string Writer = "Writer";
        public const string Reader = "Reader";
        public const string Administrator = Writer + "," + Reader;
    }
}
