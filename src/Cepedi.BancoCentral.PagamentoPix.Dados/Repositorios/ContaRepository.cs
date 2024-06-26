﻿using System;
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

    public async Task<List<ContaEntity>> ObtemContasAsync()
    {
        return await _context.Conta.ToListAsync();
    }

    public async Task<ContaEntity> ObtemContaPorIdAsync(int IdConta)
    {
        return await _context.Conta.Where(p => p.IdConta == IdConta).FirstOrDefaultAsync();
    }

}
