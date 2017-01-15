namespace ProdutosPrePago
{
    public class Estado: Entity
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public Pais Pais { get; set; }
    }
}