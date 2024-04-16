using AnimesProtech.Context;
using AnimesProtech.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace AnimesProtech.Negocio
{
    public class NegAnimes : Anime
    {

        private readonly AnimeProtech _animeProtech;
        public NegAnimes(AnimeProtech animeProtech)
        {
            _animeProtech = animeProtech;
        }
        public NegAnimes()
        {

        }

        public Anime Create(string name, string synopsis, string editor)
        {
            try
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(synopsis) && string.IsNullOrEmpty(editor))
                {
                    Anime anime = new Anime(name, synopsis, editor, false);
                    _animeProtech.Add(anime);
                    _animeProtech.SaveChanges();
                    return anime;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public Anime find(int id)
        {
            var anime = _animeProtech.Animes
                            .Where(a => (a.Id == id) && (a.IsDeleted == false)).FirstOrDefault();

            if (anime != null)
            {
                return anime;
            }
            return null;
        }

        public Anime update(int id, string name, string synopsis, string editor)
        {
            Anime anime = new Anime();
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    anime.Name = name;
                }
                if (string.IsNullOrEmpty(synopsis))
                {
                    anime.Synopsis = synopsis;
                }
                if (string.IsNullOrEmpty(editor))
                {
                    anime.Editor = editor;
                }

                _animeProtech.SaveChanges();
                return anime;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool delete(int id)
        {
            Anime anime = new Anime();

            try
            {
                anime.IsDeleted = true;

                _animeProtech.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
