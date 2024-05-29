namespace Biblioteca.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string NomeUsuario { get; set; }
        public required string CpfUsuario { get; set; }
        public string Email {  get; set; }
        public char StatusUsuario { get; set; }
    }
}
