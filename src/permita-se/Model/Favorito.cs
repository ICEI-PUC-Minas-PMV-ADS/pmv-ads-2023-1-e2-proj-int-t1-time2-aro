namespace permita_se.Model
{
    public partial class Favorito
    {
        public string IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }   
    }
}
