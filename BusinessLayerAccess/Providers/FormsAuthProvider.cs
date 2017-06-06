using BusinessLayerAccess.Interfaces;
using Domain.Entities;
using System.Web.Security;

namespace BusinessLayerAccess.Providers
{
    public class FormsAuthProvider : IAuthProvider
    {
        private readonly IRepository<User> _repository;
        public FormsAuthProvider(IRepository<User> repo)
        {
            _repository = repo;
        }
        public bool Authenticate(string username, string password)
        {
            /* ---------- Use Ninject technology for getting data source ---------- */
            bool isLogged = false;
            foreach (User user in _repository.Get())
            {
                if (username.Equals(user.Name.Trim()) && password.Equals(user.Password.Trim()))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    isLogged = true;
                }
            }
            return isLogged;

            /* ---------- Use ADO.NET technology for getting data source ---------- */
            /*using (CoinsStoreEntities dc = new CoinsStoreEntities())
            {
                var v = dc.Users.Where(a => a.UserName.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
                if (v != null)
                {                    
                    FormsAuthentication.SetAuthCookie(username, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }*/
        }
    }
}
