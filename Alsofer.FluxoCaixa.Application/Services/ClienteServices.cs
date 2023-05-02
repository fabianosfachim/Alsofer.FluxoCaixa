using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Response<ClienteResponse>> AdicionarClientes(ClienteRequest clienteRequest)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {
              
                var cliente = _clienteRepository.GetAsync(x => x.cpfCnpj == clienteRequest.cliente.cpfCnpj.Trim()).Result.FirstOrDefault();

                if (cliente == null)
                {
                    await _clienteRepository.AddAsync(clienteRequest.cliente);

                    //Id para chamar o cadastro do endereço
                    var idCliente = clienteRequest.cliente.id;

                    if (idCliente > 0)
                    {
                        clienteResponse.objCliente = clienteRequest.cliente;
                        clienteResponse.Executado = true;
                        clienteResponse.MensagemRetorno = "Cadastro de cliente efetuada com sucesso";
                    }
                }
                else
                {
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Já existe um cliente com este cnpj cadastrado no banco de dados";
                }
            }
            catch
            {
                clienteResponse.Executado = false;
                clienteResponse.MensagemRetorno = "Erro ao cadastrar o cliente";
            }

            return new Response<ClienteResponse>(clienteResponse, $"Cadastro Cliente.");
        }

        public async Task<Response<ClienteResponse>> AtualizarDadosCliente(ClienteRequest clienteRequest)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {
                await _clienteRepository.UpdateAsync(clienteRequest.cliente);

                clienteResponse.objCliente = clienteRequest.cliente;
                clienteResponse.Executado = true;
                clienteResponse.MensagemRetorno = "Atualização do cadastro de cliente efetuada com sucesso";

            }
            catch
            {
                clienteResponse.Executado = false;
                clienteResponse.MensagemRetorno = "Erro ao cadastrar o cliente";
            }

            return new Response<ClienteResponse>(clienteResponse, $"Cadastro Cliente.");
        }

        public async Task<Response<ClienteResponse>> ListarClientes()
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {
                var listaCliente = await _clienteRepository.GetAllAsync();

                if (listaCliente.Any())
                {
                    clienteResponse.Cliente = listaCliente.ToList();
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Consulta de cliente efetuada com sucesso";
                }
                else
                {
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Não existem clientes cadastrados no banco de dados";
                }
            }
            catch
            {
                clienteResponse.Executado = false;
                clienteResponse.MensagemRetorno = "Erro na consulta de cliente";
            }

            return new Response<ClienteResponse>(clienteResponse, $"Lista Clientes.");
        }

        public async Task<Response<ClienteResponse>> ListarClientesAtivos()
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {
                var listaCliente = await _clienteRepository.GetAsync(x => x.ativo == true);

                if (listaCliente.Any())
                {
                    clienteResponse.Cliente = listaCliente.ToList();
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Consulta de cliente efetuada com sucesso";
                }
                else
                {
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Não existem clientes cadastrados no banco de dados";
                }
            }
            catch
            {
                clienteResponse.Executado = false;
                clienteResponse.MensagemRetorno = "Erro na consulta de cliente";
            }

            return new Response<ClienteResponse>(clienteResponse, $"Lista Clientes.");
        }

        public async Task<Response<ClienteResponse>> ListarDadosCliente(int id)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            try
            {
                var dadosCliente = await _clienteRepository.GetByIdAsync(id);

                if (dadosCliente != null)
                {
                    clienteResponse.objCliente = dadosCliente;
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Consulta de cliente efetuada com sucesso";
                }
                else
                {
                    clienteResponse.Executado = true;
                    clienteResponse.MensagemRetorno = "Não existem cliente cadastrado no banco de dados para este consulta";
                }
            }
            catch
            {
                clienteResponse.Executado = false;
                clienteResponse.MensagemRetorno = "Erro na consulta de cliente";
            }

            return new Response<ClienteResponse>(clienteResponse, $"Dados Cliente.");
        }
    }
}
