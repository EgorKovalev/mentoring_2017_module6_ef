namespace BusinessLayerAccess.Interfaces
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
