namespace Biblioteca.Entities
{
    public class Livro
    {
        public int Id { get; set; } //Gerar um id Diferente do livro
        public required string NomeLivro { get; set; }
        public required int Genero { get; set; }
        public char StatusLivro { get; set; }
    }
}
