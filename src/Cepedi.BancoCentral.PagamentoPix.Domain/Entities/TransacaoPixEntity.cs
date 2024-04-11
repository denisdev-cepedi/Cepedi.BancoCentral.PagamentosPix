using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cepedi.BancoCentral.PagamentoPix.Domain.Entities;

public class TransacaoPixEntity
{
    public int Id { get; set; }

    public double Valor { get; set; }

    public DateTime Data { get; set; }

    public string ChavePix { get; set; }
    public string ChaveDeSeguranca { get; set; }

    public int IdPixOrigem { get; set; }

   public int IdPixDestino  { get; set; }

}
