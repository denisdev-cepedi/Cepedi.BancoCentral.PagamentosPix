using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cepedi.BancoCentral.PagamentoPix.IoC;
public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var usuario = new UsuarioEntity { Nome = "Denis", Celular = "71992414041", CelularValidado = true, 
            Cpf = "1234567891", DataNascimento = DateTime.Now.AddYears(-31), Email = "denis.vieira@cepedi.org.br" };
        // var pessoa = new PessoaEntity { Nome = "Denis", Cpf = "1234567891" };
        // var conta = new ContaEntity { IdPessoa = 1, IdConta = 1, Numero="123", Agencia = "1234", Conta = "1234567" };
        // var pix = new PixEntity { IdPix = 1, IdConta = 1, ChavePix = "71992414041", IdTipoPix = 2, DataCriacao = DateTime.Now, Status = true };

        // var pessoa2 = new PessoaEntity { Nome = "Carol", Cpf = "2234567891" };
        // var conta2 = new ContaEntity { IdPessoa = 2, IdConta = 2, Numero="456", Agencia = "4567", Conta = "789065" };
        // var pix2 = new PixEntity {  IdConta = 2, ChavePix = "2234567891", IdTipoPix = 1, DataCriacao = DateTime.Now, Status = true };

        // Default data

        // Seed, if necessary
        if (!_context.Usuario.Any())
        {
            _context.Usuario.Add(usuario);
            // _context.Pessoa.Add(pessoa);
            // _context.Conta.Add(conta);
            // _context.Pix.Add(pix);
            // _context.Pessoa.Add(pessoa2);
            // _context.Conta.Add(conta2);
            // _context.Pix.Add(pix2);

            await _context.SaveChangesAsync();
        }
    }
}
