using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Domain.Model;


namespace Alsofer.FluxoCaixa.Application.Services.Interfaces
{
    public interface IRelatorioFluxoCaixaDiarioServices
    {
        Task<Response<RelatorioFluxoCaixaDiarioResponse>> GetRelatorioDiarioFluxoCaixa(RelatorioFluxoCaixaDiarioRequest clienteRequest);
    }
}
