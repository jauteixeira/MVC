namespace RoleTopMVC.Repositories
{
    public class PedidoRepository
    {
        private const string PATH = "Database/Pedido.csv";
        public PedidoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Pedido pedido)
        {
            var linha = new string [] {PrepararPedidoCSV(pedido)};
            File.AppendAllLines(PATH, linha);
            return true;
        }
        public List<Pedido> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Pedido> pedidos = new List<Pedido> ();
            foreach (var linha in linhas)
            {
                Pedido pedido = new Pedido();
                pedido.Cliente = new Cliente();
                pedido.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                
            }
        }
    }
}