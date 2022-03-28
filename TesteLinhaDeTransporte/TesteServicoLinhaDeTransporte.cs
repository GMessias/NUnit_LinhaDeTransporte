using NUnit.Framework;
using System.Collections.Generic;
using LinhaDeTransporteClasse;

namespace TesteLinhaDeTransporte
{
    [TestFixture]
    public class TesteServicoLinhaDeTransporte
    {
        private LinhaDeTransporte linhaDeTransporte;
        private LinhaDeTransporte linhaDeTransporte2;
        private LinhaDeTransporte linhaDeTransporteAuxiliar;
        private ServicoLinhaDeTransporte servicoLinhaDeTransporte;

        [SetUp]
        public void MetodoInicial()
        {
            servicoLinhaDeTransporte = new ServicoLinhaDeTransporte();
            AlimentarLinhaDeTransporte();
        }

        [Test]
        public void TesteServicoCadastroLinha()
        {
            servicoLinhaDeTransporte.CadastroLinha(linhaDeTransporte);
            var linhaDeComparacao = servicoLinhaDeTransporte.ConsulteLinhaDeTransporte(linhaDeTransporte.Codigo);
            Assert.IsTrue(linhaDeComparacao == linhaDeTransporte);
        }

        [Test]
        public void TesteServicoExclusaoLinha()
        {
            servicoLinhaDeTransporte.CadastroLinha(linhaDeTransporte);
            servicoLinhaDeTransporte.CadastroLinha(linhaDeTransporte2);
            servicoLinhaDeTransporte.ExclusaoLinhaDeTransporte(linhaDeTransporte.Codigo);
            Assert.IsNull(servicoLinhaDeTransporte.ConsulteLinhaDeTransporte(linhaDeTransporte.Codigo));
        }

        [Test]
        public void TesteServicoEditarLinha()
        {
            servicoLinhaDeTransporte.CadastroLinha(linhaDeTransporte);
            servicoLinhaDeTransporte.EditarLinhaDeTransporte(linhaDeTransporteAuxiliar);
            Assert.AreEqual(linhaDeTransporteAuxiliar, servicoLinhaDeTransporte.ConsulteLinhaDeTransporte(linhaDeTransporte.Codigo));
        }

        [Test, Sequential]
        public void TesteServicoTarifaAjuste([Values(1, 2, 3)] int ajuste,
                                             [Values(20 * 1.10, 20 * 1.05, 20 * 1.20)] double tarifaReajustado)
        {
            linhaDeTransporte.Tipo = ajuste;
            servicoLinhaDeTransporte.CadastroLinha(linhaDeTransporte);
            servicoLinhaDeTransporte.ReajusteTarifaLinhaDeTransporte(linhaDeTransporte);
            Assert.AreEqual(linhaDeTransporte.Tarifa, tarifaReajustado);
        }

        public void AlimentarLinhaDeTransporte()
        {
            linhaDeTransporte = new LinhaDeTransporte()
            {
                Codigo = 11,
                Descricao = "Teste Linha de Transporte",
                Tipo = 1,
                CodigoFornecedor = 11,
                Tarifa = 20
            };
            linhaDeTransporte2 = new LinhaDeTransporte()
            {
                Codigo = 12,
                Descricao = "Teste Linha de Transporte Auxiliar",
                Tipo = 2,
                CodigoFornecedor = 12,
                Tarifa = 30
            };
            linhaDeTransporteAuxiliar = new LinhaDeTransporte()
            {
                Codigo = 11,
                Descricao = "Teste Linha de Transporte Auxiliar para edição",
                Tipo = 3,
                CodigoFornecedor = 13,
                Tarifa = 50
            };
        }
    }
}
