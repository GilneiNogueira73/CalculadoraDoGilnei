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
        private int segundonum;
        private string resultado;

        [Fact(DisplayName = "Realizar calculo com sucesso")]
        public void Test1()
        {

            txtDisplay = "10";
            lblMostraOps = "15";
            operacao = "+";
            segundonum = 10;
            resultado = txtDisplay + operacao + lblMostraOps;

            Assert.NotNull(resultado);
        }
    }
}
