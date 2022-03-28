using NUnit.Framework;
using System.Collections.Generic;
using LinhaDeTransporteClasse;

namespace TesteLinhaDeTransporte
{
    [TestFixture]
    public class TesteLinhaDeTransporte
    {
        private List<LinhaDeTransporte> listaLinhaDeTransporte;
        private LinhaDeTransporte linhaDeTransporte;
        private ValidacaoLinhaDeTransporte validador;

        [SetUp]
        public void MetodoInicial()
        {
            listaLinhaDeTransporte = new List<LinhaDeTransporte>();
            linhaDeTransporte = new LinhaDeTransporte();
            validador = new ValidacaoLinhaDeTransporte(linhaDeTransporte);

            AlimentarListaLinhaDeTransporte();
        }

        [Test, Sequential]
        public void TesteValidacaoCodigoObrigatorio([Values(-1, 0, 1)] int codigoLinha,
                                                    [Values(true, false, true)] bool ehValido)
        {
            linhaDeTransporte.Codigo = codigoLinha;
            Assert.IsTrue(validador.ValidarCodigoObrigatorio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoCodigoDominio([Values(-1, 0, 1, 10000)] int codigoDominio,
                                                [Values(false, false, true, false)] bool ehValido)
        {
            linhaDeTransporte.Codigo = codigoDominio;
            Assert.IsTrue(validador.ValidarCodigoDominio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoCodigoExistente([Values(1, 4)] int codigoChave,
                                                  [Values(true, false)] bool ehValido)
        {
            linhaDeTransporte.Codigo = codigoChave;
            Assert.IsTrue(validador.ValidarCodigoExistente(listaLinhaDeTransporte) == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoDescricaoObrigatoria([Values(null, "", "descricao")] string descricaoLinha,
                                                       [Values(false, false, true)] bool ehValido)
        {
            linhaDeTransporte.Descricao = descricaoLinha;
            Assert.IsTrue(validador.ValidarDescricaoObrigatorio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoDescricaoDominio([Values("", "ppppppppp", "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmppppppppppppppppppppppppppppppppppppppppppppppppp")] string tamanho,
                                                   [Values(false, true, false)] bool ehValido)
        {
            linhaDeTransporte.Descricao = tamanho;
            Assert.IsTrue(validador.ValidarDescricaoDominio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoTipoObrigatorio([Values(-1, 0, 1)] int codigoTipo,
                                                  [Values(true, false, true)] bool ehValido)
        {
            linhaDeTransporte.Tipo = codigoTipo;
            Assert.IsTrue(validador.ValidarTipoObrigatorio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoTipoDominio([Values(0, 1, 2, 4)] int codigoTipo,
                                              [Values(false, true, true, false)] bool ehValido)
        {
            linhaDeTransporte.Tipo = codigoTipo;
            Assert.IsTrue(validador.ValidarTipoDominio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoCodigoFornecedorObrigatorio([Values(-1, 0, 1)] int codigoFornecedor,
                                                              [Values(true, false, true)] bool ehValido)
        {
            linhaDeTransporte.CodigoFornecedor = codigoFornecedor;
            Assert.IsTrue(validador.ValidarCodigoFornecedorObrigatorio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoCodigoFornecedorDominio([Values(-1, 0, 1, 10000)] int codigoFornecedor,
                                                          [Values(false, false, true, false)] bool ehValido)
        {
            linhaDeTransporte.CodigoFornecedor = codigoFornecedor;
            Assert.IsTrue(validador.ValidarCodigoFornecedorDominio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoTarifaObrigatorio([Values(-1, 0, 1)] double tarifa,
                                                    [Values(true, false, true)] bool ehValido)
        {
            linhaDeTransporte.Tarifa = tarifa;
            Assert.IsTrue(validador.ValidarTarifaObrigatorio() == ehValido);
        }

        [Test, Sequential]
        public void TesteValidacaoTarifaDominio([Values(-1.0, 0.0, 1.0, 10000.0)] double tarifa,
                                                [Values(false, false, true, false)] bool ehValido)
        {
            linhaDeTransporte.Tarifa = tarifa;
            Assert.IsTrue(validador.ValidarTarifaDominio() == ehValido);
        }

        public void AlimentarListaLinhaDeTransporte()
        {
            for (int i = 1; i <= 3; i++)
            {
                listaLinhaDeTransporte.Add(new LinhaDeTransporte()
                {
                    Codigo = i,
                    Descricao = "descricao" + i.ToString(),
                    Tipo = i,
                    CodigoFornecedor = i,
                    Tarifa = 1.00 + i
                });
            }
        }
    }
}