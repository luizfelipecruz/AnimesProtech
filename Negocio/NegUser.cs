using AnimesProtech.Context;
using AnimesProtech.Controllers;
using AnimesProtech.Models;
using AnimesProtech.Services;
using Azure.Core;

namespace AnimesProtech.Negocio
{
    public class NegUser
    {

        private readonly AnimeProtech _animeProtech;

        public NegUser(AnimeProtech animeProtech)
        {
            if (animeProtech != null)
            {
                _animeProtech = animeProtech;
            }
        }
        public NegUser() { }

        public string Login(string login, string password)
        {
            var User = _animeProtech.usuarios
                           .Where(u => (u.Login == login) && (u.Password == password)).FirstOrDefault();
            if (User != null)
            {
                var tokens = Tokens.GenerateToken(User);
                return tokens.ToString();
            }
            return string.Empty;
        }

        public List<User>? list(string login)

        {
            var User = _animeProtech.usuarios
                .Where(a => (a.IsDeleted == false) &&
                (string.IsNullOrEmpty(login) || a.Login.Contains(login)))
                .ToList();

            if (User != null)
            {
                return User;

            }
            return null;
        }

        public User? Update(User user)
        {
            var UserCotext = _animeProtech.usuarios.Find();
            if (UserCotext != null)
            {
                if (!string.IsNullOrEmpty(user.Login))
                {
                    user.Login = UserCotext.Login;
                }
                if (!string.IsNullOrEmpty(user.Password))
                {
                    user.Password = UserCotext.Password;
                }

                _animeProtech.SaveChanges();

                return user;
            }

            return null;
        }
        public bool Delete(int id)
        {
            var UserCotext = _animeProtech.usuarios.Find();
            if (UserCotext != null)
            {
                UserCotext.IsDeleted = UserCotext.IsDeleted;
                _animeProtech.SaveChanges();

                return true;
            }
            return false;
        }
    }

}

