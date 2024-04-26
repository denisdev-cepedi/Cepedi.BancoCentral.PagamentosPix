using Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;


using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Data.Tests.MemoryDatabase
{
    public class PessoaRepositoryTests
    {
        [Fact]

        public async Task Can_Get_Pessoas_From_Database(){
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            
            using (var context = new ApplicationDbContext(options)){
                context.Pessoa.Add(new PessoaEntity { Nome = "Pessoa1", Cpf = "00000000191" });
                context.Pessoa.Add(new PessoaEntity { Nome = "Pessoa2", Cpf = "11111111111" });
                context.SaveChanges();
            }
            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var pessoaRepository = new PessoaRepository(context);
                var pessoas = await pessoaRepository.ObtemPessoasAsync();

                // Assert
                Assert.Equal(2, pessoas.Count);
                Assert.Equal("Pessoa1", pessoas[0].Nome);
                Assert.Equal("Pessoa2", pessoas[1].Nome);
            }
        }
        public async Task Update_Pessoa_From_Database()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var pessoaRepository = new PessoaRepository(context);
                var pessoa = await pessoaRepository.ObtemPessoaPorIdAsync(1);
                pessoa.Cpf = "22222222222";
                await pessoaRepository.AtualizarPessoaAsync(pessoa);
            }
            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var pessoaRepository = new PessoaRepository(context);
                var pessoa = await pessoaRepository.ObtemPessoaPorIdAsync(1);
                Assert.Equal("22222222222", pessoa.Cpf);
            }

        }
    }
}