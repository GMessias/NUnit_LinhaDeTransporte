namespace LinhaDeTransporteClasse
{
    public class ValidacaoLinhaDeTransporte
    {
        private readonly LinhaDeTransporte _linhaDeTransporte;
        private readonly ServicoLinhaDeTransporte servico;

        public ValidacaoLinhaDeTransporte(LinhaDeTransporte linhaDeTransporte)
        {
            _linhaDeTransporte = linhaDeTransporte;
            servico = new ServicoLinhaDeTransporte();
            servico.CriarListaDeChaves();
        }

        public bool ValidarCodigoObrigatorio()
        {
            if (_linhaDeTransporte.Codigo != 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidarCodigoDominio()
        {
            if (_linhaDeTransporte.Codigo > 0 && _linhaDeTransporte.Codigo <= 9999)
            {
                return true;
            }
            return false;
        }

        public bool ValidarCodigoExistente(List<LinhaDeTransporte> listaLinhaDeTransporte)
        {
            foreach (var consulta in listaLinhaDeTransporte)
            {
                if (consulta.Codigo == _linhaDeTransporte.Codigo)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidarDescricaoObrigatorio()
        {

            if (string.IsNullOrEmpty(_linhaDeTransporte.Descricao))
            {
                return false;
            }
            return true;
        }

        public bool ValidarDescricaoDominio()
        {
            if (_linhaDeTransporte.Descricao.Length >= 1 && _linhaDeTransporte.Descricao.Length <= 100)
            {
                return true;
            }
            return false;
        }

        public bool ValidarTipoObrigatorio()
        {
            if (_linhaDeTransporte.Tipo != 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidarTipoDominio()
        {
            if (_linhaDeTransporte.Tipo == 1 || _linhaDeTransporte.Tipo == 2 || _linhaDeTransporte.Tipo == 3)
            {
                return true;
            }
            return false;
        }

        public bool ValidarCodigoFornecedorObrigatorio()
        {
            if (_linhaDeTransporte.CodigoFornecedor != 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidarCodigoFornecedorDominio()
        {
            if (_linhaDeTransporte.CodigoFornecedor > 0 && _linhaDeTransporte.CodigoFornecedor <= 9999)
            {
                return true;
            }
            return false;
        }

        public bool ValidarTarifaObrigatorio()
        {
            if (_linhaDeTransporte.Tarifa != 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidarTarifaDominio()
        {
            if (_linhaDeTransporte.Tarifa > 0.0 && _linhaDeTransporte.Tarifa < 9999.99)
            {
                return true;
            }
            return false;
        }
    }
}
