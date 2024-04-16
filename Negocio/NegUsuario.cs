using AnimesProtech.Context;

namespace AnimesProtech.Negocio
{
    public class NegUsuario
    {

        public NegUsuario()
        {
            
        }
        private readonly AnimeProtech _animeProtech;

        public NegUsuario(AnimeProtech animeProtech)
        {
            _animeProtech = animeProtech;
        }

       public int Authenticate(string login , string password)
        {
            var User = _animeProtech.usuarios
                            .Where(u => (u.Login == login) && (u.Password == password)).FirstOrDefault();

            if (User != null)
            {
                return User.Id;
            }

            return 0;
        }

    }
}
