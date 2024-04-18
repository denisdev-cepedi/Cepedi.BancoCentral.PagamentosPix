using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cepedi.BancoCentral.PagamentoPix.Data;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Entidades;
using Cepedi.BancoCentral.PagamentoPix.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Cepedi.BancoCentral.PagamentoPix.Dados.Repositorios
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context) => _context = context;
        
        public async Task<PessoaEntity> AtualizarPessoaAsync(PessoaEntity pessoa)
        {
            _context.Pessoa.Update(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<PessoaEntity> CriarPessoaAsync(PessoaEntity pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<List<PessoaEntity>> ObtemPessoasAsync()
        {
            return await _context.Pessoa.ToListAsync();
        }

        public async Task<PessoaEntity> ObtemPessoaPorIdAsync(int IdPessoa)
        {
            return await _context.Pessoa.Where(p => p.IdPessoa == IdPessoa).FirstOrDefaultAsync();
        }
        
    }
}