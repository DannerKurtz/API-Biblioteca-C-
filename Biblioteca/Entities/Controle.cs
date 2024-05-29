namespace Biblioteca.Entities
{
    public class Controle
    {
        public int Id { get; set; }

        // chave estrangeira para id-usuario
        public int IdUsuario { get; set; }
        // navegação para usuario
        public Usuario Usuario { get; set; }

        //chave estrangeira para id-livro
        public int IdLivro { get; set; }
        // navegação para livro
        public Livro Biblioteca { get; set; }
    }
}
