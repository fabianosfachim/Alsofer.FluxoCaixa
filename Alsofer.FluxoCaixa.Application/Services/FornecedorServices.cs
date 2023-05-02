using Alsofer.FluxoCaixa.Application.Services.Interfaces;
using Alsofer.FluxoCaixa.Application.Services.Wrappers;
using Alsofer.FluxoCaixa.Data.Interfaces;
using Alsofer.FluxoCaixa.Data.Repositories.Entities;
using Alsofer.FluxoCaixa.Domain.Model;

namespace Alsofer.FluxoCaixa.Application.Services
{
    public class FornecedorServices : IFornecedorServices
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorServices(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<Response<FornecedorResponse>> AdicionarFornecedor(FornecedorRequest fornecedorRequest)
        {
            FornecedorResponse fornecedorResponse = new FornecedorResponse();

            try
            {

                var fornecedor = _fornecedorRepository.GetAsync(x => x.cpfCnpj == fornecedorRequest.fornecedor.cpfCnpj.Trim()).Result.FirstOrDefault();

                if (fornecedor == null)
                {
                    await _fornecedorRepository.AddAsync(fornecedorRequest.fornecedor);

                    //Id para chamar o cadastro do endereço
                    var idfornecedor = fornecedorRequest.fornecedor.id;

                    if (idfornecedor > 0)
                    {
                        fornecedorResponse.objFornecedor = fornecedorRequest.fornecedor;
                        fornecedorResponse.Executado = true;
                        fornecedorResponse.MensagemRetorno = "Cadastro de fornecedor efetuado com sucesso";
                    }
                }
                else
                {
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Já existe um fornecedor com este cnpj/cnpj cadastrado no banco de dados";
                }
            }
            catch
            {
                fornecedorResponse.Executado = false;
                fornecedorResponse.MensagemRetorno = "Erro ao cadastrar o cliente";
            }

            return new Response<FornecedorResponse>(fornecedorResponse, $"Cadastro Cliente.");
        }

        public async Task<Response<FornecedorResponse>> AtualizarDadosFornecedor(FornecedorRequest fornecedorRequest)
        {
            FornecedorResponse fornecedorResponse = new FornecedorResponse();

            try
            {

                await _fornecedorRepository.UpdateAsync(fornecedorRequest.fornecedor);

                fornecedorResponse.objFornecedor = fornecedorRequest.fornecedor;
                fornecedorResponse.Executado = true;
                fornecedorResponse.MensagemRetorno = "Atualização do fornecedor efetuado com sucesso";
            }
            catch
            {
                fornecedorResponse.Executado = false;
                fornecedorResponse.MensagemRetorno = "Erro ao cadastrar o atualizar o cadastro de fornecedor";
            }

            return new Response<FornecedorResponse>(fornecedorResponse, $"Atualização do Cadastro Fornecedor.");
        }

        public async Task<Response<FornecedorResponse>> ListarDadosFornecedor(int id)
        {
            FornecedorResponse fornecedorResponse = new FornecedorResponse();

            try
            {

               var fornecedor =  await _fornecedorRepository.GetByIdAsync(id);

                if(fornecedor != null)
                {
                    fornecedorResponse.objFornecedor = fornecedor;
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Consulta do fornecedor efetuado com sucesso";
                }
                else
                {
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Não existe fornecedor cadastrado no banco de dados";
                }
            }
            catch
            {
                fornecedorResponse.Executado = false;
                fornecedorResponse.MensagemRetorno = "Erro ao cadastrar o listar o cadastro de fornecedor";
            }

            return new Response<FornecedorResponse>(fornecedorResponse, $"Lista do Cadastro Fornecedor.");
        }

        public async Task<Response<FornecedorResponse>> ListarFornecedor()
        {
            FornecedorResponse fornecedorResponse = new FornecedorResponse();

            try
            {

                var fornecedor = await _fornecedorRepository.GetAllAsync();

                if (fornecedor != null)
                {
                    fornecedorResponse.Fornecedor = fornecedor.ToList();
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Consulta do fornecedor efetuado com sucesso";
                }
                else
                {
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Não existe fornecedor cadastrado no banco de dados";
                }
            }
            catch
            {
                fornecedorResponse.Executado = false;
                fornecedorResponse.MensagemRetorno = "Erro ao cadastrar o listar o cadastro de fornecedor";
            }

            return new Response<FornecedorResponse>(fornecedorResponse, $"Lista do Cadastro Fornecedor.");
        }

        public async Task<Response<FornecedorResponse>> ListarFornecedorAtivo()
        {
            FornecedorResponse fornecedorResponse = new FornecedorResponse();

            try
            {

                var fornecedor = await _fornecedorRepository.GetAsync(x => x.ativo == true);

                if (fornecedor != null)
                {
                    fornecedorResponse.Fornecedor = fornecedor.ToList();
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Consulta do fornecedor efetuado com sucesso";
                }
                else
                {
                    fornecedorResponse.Executado = true;
                    fornecedorResponse.MensagemRetorno = "Não existe fornecedor cadastrado no banco de dados";
                }
            }
            catch
            {
                fornecedorResponse.Executado = false;
                fornecedorResponse.MensagemRetorno = "Erro ao cadastrar o listar o cadastro de fornecedor";
            }

            return new Response<FornecedorResponse>(fornecedorResponse, $"Lista do Cadastro Fornecedor.");
        }
    }
}
