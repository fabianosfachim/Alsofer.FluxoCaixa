using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class StatusServices : IStatusServices
    {
        private readonly IStatusRepository _statusRepository;

        public StatusServices(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Response<StatusResponse>> ListarStatus()
        {
            StatusResponse statusResponse = new StatusResponse();

            try 
            {
                var status = _statusRepository.GetAll();

                if (status.Any())
                {

                    statusResponse.status = status.ToList();
                    statusResponse.Executado = true;
                    statusResponse.MensagemRetorno = "Consulta efetuada com sucesso";
                }
                else
                {
                    statusResponse.Executado = true;
                    statusResponse.MensagemRetorno = "Dados incorretos, digite novamente";
                }
            }
            catch
            {
                statusResponse.Executado = false;
                statusResponse.MensagemRetorno = "Erro na consulta de lista de status";
            }

            return new Response<StatusResponse>(statusResponse, $"Listar Status.");
        }

        public async Task<Response<StatusResponse>> ListarStatusAtivo()
        {
            StatusResponse statusResponse = new StatusResponse();

            try
            {
                var status = _statusRepository.Get(x => x.ativo == true);

                if (status.Any())
                {

                    statusResponse.status = status.ToList();
                    statusResponse.Executado = true;
                    statusResponse.MensagemRetorno = "Consulta efetuada com sucesso";
                }
                else
                {
                    statusResponse.Executado = true;
                    statusResponse.MensagemRetorno = "Dados incorretos, digite novamente";
                }
            }
            catch
            {
                statusResponse.Executado = false;
                statusResponse.MensagemRetorno = "Erro na consulta de lista de status";
            }

            return new Response<StatusResponse>(statusResponse, $"Listar Status Ativo.");
        }
    }
}
