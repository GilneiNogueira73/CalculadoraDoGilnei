using Moq;
using System;
using Xunit;


namespace TestesUnitariosCalculadora
{
    public class TestesDeOperacoes
    {
        private string txtDisplay;
        private string lblMostraOps;
        private string operacao;
        private string resultado;

        [Fact(DisplayName = "Realizar calculo com sucesso")]
        public void CalculoDeSoma()
        {

            txtDisplay = "10";
            lblMostraOps = "15";
            operacao = "+";
            resultado = txtDisplay + operacao + lblMostraOps;

            Assert.NotNull(resultado);
        }
    }
}
