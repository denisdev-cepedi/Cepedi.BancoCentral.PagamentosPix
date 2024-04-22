using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Data.Repositories;

public class PixRepository : IPixRepository{

    private readonly ApplicationDbContext _context;

     public PixRepository(ApplicationDbContext context) => _context = context;

    public async Task<PixEntity> CriarPixAsync(PixEntity pix){

        _context.Pix.Add(pix);
        await _context.SaveChangesAsync();
        return pix;
    }

    public async Task<PixEntity> AtualizarPixAsync(PixEntity pix){
        _context.Pix.Update(pix);
        await _context.SaveChangesAsync();
        return pix;
    }


    public async Task<PixEntity> ObterPixByIdAsync(int id)
    {
         return await _context.Pix.Where(x => x.IdPix == id).FirstOrDefaultAsync();
    }

    public async Task<PixEntity> ObterChavePixAsync(string chavePix)
    {
        return await _context.Pix.Where(x => x.ChavePix == chavePix).FirstOrDefaultAsync();
    }
}