using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios;


public class ContaRepository : IContaRepository
{
    private readonly ApplicationDbContext _context;

    public ContaRepository(ApplicationDbContext context) => _context = context;

    public async Task<ContaEntity> AtualizarContaAsync(ContaEntity conta)
    {
        _context.Conta.Update(conta);
        await _context.SaveChangesAsync();
        return conta;
    }


    public async Task<ContaEntity> CriarContaAsync(ContaEntity conta)
    {
        _context.Conta.Add(conta);
        await _context.SaveChangesAsync();
        return conta;

    }
    public async Task<ContaEntity> ObterContasByCpf(string Cpf)
    {

        return await _context.Conta
        .Include(c => c.Pessoa) // Include the related Pessoa entity
        .Where(p => p.Pessoa.Cpf == Cpf)
        .FirstOrDefaultAsync();

    }

    public async Task<List<ContaEntity>> ObtemContasAsync(int IdPessoa)
    {
        return await _context.Conta.Include(x => x.Pessoa).Where(p => p.IdPessoa == IdPessoa).ToListAsync();
    }

    public async Task<ContaEntity> ObtemContaPorIdAsync(int IdConta)
    {
        return await _context.Conta.Where(p => p.IdConta == IdConta).FirstOrDefaultAsync();
    }
    public async Task<ContaEntity> ObterContaAsync(int IdConta)
    {
        return await _context.Conta.Include(x => x.Pessoa).Where(p => p.IdConta == IdConta).FirstOrDefaultAsync();
    }

    public async Task<ContaEntity> ObterContaBankAsync(string CodigoInstituicao, string agencia, string conta)
    {
        return await _context.Conta
       .Include(x => x.Pessoa)
       .Where(x => x.Numero == CodigoInstituicao && x.Agencia == agencia && x.Conta == conta)
       .FirstOrDefaultAsync();
    }

    public async Task<List<ContaEntity>> ObterContasByCpfAsync(string Cpf)
    {
         return await _context.Conta.Include(x => x.Pessoa).Where(x => x.Pessoa.Cpf == Cpf).ToListAsync();
    }
}
