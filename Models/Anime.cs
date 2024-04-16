namespace AnimesProtech.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Synopsis { get; set; }
        public string? Editor { get; set; }
        public bool? IsDeleted { get; set; }

        // Parameterless constructor required by EF Core
        public Anime()
        {
        }

        public Anime(string nome, string synopsis, string editor, bool isDeleted)
        {
            Name = nome;
            Synopsis = synopsis;
            Editor = editor;
            IsDeleted = isDeleted;
        }
    }
}
