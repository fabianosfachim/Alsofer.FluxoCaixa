# FluxoCaixaEmpresaAlsofer

Projeto implementado para que uma pequena empresa possa realizar o Controle de Fluxo de Caixa.

A idéia do projeto é que se possa cadastrar clientes que geram receitas e cadastrar fornecedores que geram despesas

Para que isto possa ocorrer é necessário realizar o cadastro dos clientes e fornecedores. 

Também se faz necessário realizar o cadastro das despesas e receitas.

Com estes cadastros básicos efetuados é possível realizar o cadastro dos valores de receitas e o cadastro de valores de despesas

Foi disponibilizado um relatório de controle de de diárias que mostra o extrato diário consolidado de todos os dias do mês digitado como parâmetro.

## Solução

Projeto gerado com o DotNet Core versão 6.0

Entity Framework 6.0 

Banco de Dados da solução é SQL SERVER

## Acesso ao sistema


- username: 'teste@teste.com'
- password: '123456'

## BackEnd

Para o backend criar o banco de dados no sql server executando o script `ScriptBancoDados.sql` e alterar a string de conexão com o banco de dados.

Poderá notar que existe também a Migration do banco de dados. Fica como opcional a maneira de criação do banco de dados.

Para executar o projeto localmente realizar o build do mesmo efetue o login de acesso com os dados indicados e depois faça a autenticação no autorization do swager com o tokem gerado pela api de login.

Para utilizar em container indica-se que faça uma pipeline onde a mesma deve gerar a imagem, foi disponibilizado o docker para realizar esta ação.

Passos necessários para gerar o relatório diário consolidado.

1. Realizar o cadastro do cliente na api de cliente
2. Realizar o cadastro de fornecedor na api de fornecedor
3. Realizar o cadastro da despesa na api de despesa.
4. Realizar o cadastro da receita na api de receita.
5. Realizar o cadastro de contas a pagar no dia desejado na api de contas a pagar.
6. Realizar o cadastro de contas a receber no dia desejado na api de contas a receber.
7. Para gerar o relatório do fluxo diário de caixa digite o período correspondente. Ele retornará o fluxo de caixa dia a dia e um totalizador no final para gerar um relatório. A api a ser utlizada é RelatorioFluxoCaixaDiario.
