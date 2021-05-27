namespace ControleEstoque.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Preencha o nome.")]
        public string Nome { get; set; }
        public string Contrato { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public bool Ativo { get; set; }
    }
}