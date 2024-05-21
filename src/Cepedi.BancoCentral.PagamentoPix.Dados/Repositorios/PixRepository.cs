using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Data.Repositories;

public class PixRepository : IPixRepository {

    private readonly ApplicationDbContext _context;
    public PixRepository(ApplicationDbContext context) => _context = context;

    public async Task<PixEntity> CriarPixAsync(PixEntity pix)
    {

        _context.Pix.Add(pix);
        await _context.SaveChangesAsync();
        return pix;
    }

    public async Task<PixEntity> AtualizarPixAsync(PixEntity pix){
        _context.Pix.Update(pix);
        await _context.SaveChangesAsync();
        return pix;
    }


    public async Task<ICollection<PixEntity>> GetAllPixsAsync()
    {
       return await _context.Pix.ToListAsync();
    }

    public async Task<ICollection<PixEntity>> GetAllPixsByBankContaAsync(string codigoInstituicao, string agencia, string conta)
    {
        return await _context.Pix.Where(pix => pix.Conta.Numero == codigoInstituicao && pix.Conta.Agencia == agencia && pix.Conta.Conta == conta).ToListAsync();
    }

    public async Task<PixEntity> ObterPixByChavePixAsync(string chavePix)
    {
        return  await _context.Pix.Where(x => x.ChavePix == chavePix).FirstOrDefaultAsync();
    }
}