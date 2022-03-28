namespace LinhaDeTransporteClasse
{
    public class ServicoLinhaDeTransporte
    {
        public List<int> ListaDeChaves { get; set; }
        private List<LinhaDeTransporte> ListaDeTransporte { get; set; }

        public ServicoLinhaDeTransporte()
        {
            ListaDeTransporte = new List<LinhaDeTransporte>();
        }

        public void CriarListaDeChaves()
        {
            ListaDeChaves = new List<int>();
            ListaDeChaves.Add(10);
            ListaDeChaves.Add(15);
            ListaDeChaves.Add(36);
            ListaDeChaves.Add(40);
            ListaDeChaves.Add(60);
            ListaDeChaves.Add(1600);
        }

        public List<int> AdicionarChaveNaListaDeChaves(int novaChave)
        {
            ListaDeChaves.Add(novaChave);
            return ListaDeChaves;
        }

        public LinhaDeTransporte CriarLinhaDeTransporte(int codigo, string descricao, int tipo, int codigoFornecedor, double tarifa)
        {
            return new LinhaDeTransporte()
            {
                Codigo = codigo,
                Descricao = descricao,
                Tipo = tipo,
                CodigoFornecedor = codigoFornecedor,
                Tarifa = tarifa
            };
        }

        public void CadastroLinha(LinhaDeTransporte linhaDeTransporte)
        {
            ListaDeTransporte.Add(linhaDeTransporte);
        }

        public LinhaDeTransporte? ConsulteLinhaDeTransporte(int codigo)
        {
            foreach (var consulta in ListaDeTransporte)
            {
                if (consulta.Codigo == codigo)
                {
                    return consulta;
                }
            }
            return null;
        }

        public void ExclusaoLinhaDeTransporte(int codigo)
        {
            foreach (var consulta in ListaDeTransporte)
            {
                if (consulta.Codigo == codigo)
                {
                    ListaDeTransporte.Remove(consulta);
                    break;
                }
            }
        }

        public void EditarLinhaDeTransporte(LinhaDeTransporte linhaDeTransporte)
        {
            var edicao = ConsulteLinhaDeTransporte(linhaDeTransporte.Codigo);
            ExclusaoLinhaDeTransporte(linhaDeTransporte.Codigo);
            CadastroLinha(linhaDeTransporte);
        }

        public void ReajusteTarifaLinhaDeTransporte(LinhaDeTransporte linhaDeTransporte)
        {
            switch (linhaDeTransporte.Tipo)
            {
                case 1:
                    linhaDeTransporte.Tarifa = linhaDeTransporte.Tarifa * 1.10;
                    break;
                case 2:
                    linhaDeTransporte.Tarifa = linhaDeTransporte.Tarifa * 1.05;
                    break;
                case 3:
                    linhaDeTransporte.Tarifa = linhaDeTransporte.Tarifa * 1.20;
                    break;
            }
        }
    }
}
