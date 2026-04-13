using MedGrupo.Domain;
using Xunit;

namespace MedGrupo.Tests
{
    public class ContatoTests
    {
        [Fact]
        public void Deve_Calcular_Idade_Corretamente()
        {
            // Arrange: Contato nascido há exatos 20 anos
            var contato = new Contato { DataNascimento = DateTime.Today.AddYears(-20) };

            // Act
            var idade = contato.Idade;

            // Assert
            Assert.Equal(20, idade);
        }

        [Fact]
        public void Nao_Deve_Validar_Contato_Menor_De_Idade()
        {
            // Arrange: 17 anos
            var contato = new Contato { DataNascimento = DateTime.Today.AddYears(-17) };

            // Act
            var resultado = contato.Validar();

            // Assert
            Assert.False(resultado.Valid);
            Assert.Equal("O contato deve ser maior de idade.", resultado.Error);
        }

        [Fact]
        public void Nao_Deve_Validar_Data_Nascimento_Futura()
        {
            // Arrange: Amanhã
            var contato = new Contato { DataNascimento = DateTime.Today.AddDays(1) };

            // Act
            var resultado = contato.Validar();

            // Assert
            Assert.False(resultado.Valid);
            Assert.Equal("Data de nascimento não pode ser maior que hoje.", resultado.Error);
        }

        [Fact]
        public void Deve_Validar_Contato_Maior_De_Idade()
        {
            // Arrange: 25 anos
            var contato = new Contato { DataNascimento = DateTime.Today.AddYears(-25) };

            // Act
            var resultado = contato.Validar();

            // Assert
            Assert.True(resultado.Valid);
        }
    }
}