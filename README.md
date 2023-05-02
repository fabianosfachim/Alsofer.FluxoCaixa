# FluxoCaixaEmpresaAlsofer

Projeto implementado para que uma pequena empresa possa realizar o Controle de Fluxo de Caixa.

A idéia do projeto é que se possa cadastrar clientes que geram receitas e cadastrar fornecedores que geram receitas

Para que isto possa ocorrer é necessário realizar o cadastro dos clientes e fornecedores. 

Tambem se faz necessario realizar o cadastro das despesas e receitas.

Com estes cadastros básicos efetuados é possível realizar o cadastro dos valores de receitas e o cadastro de valores de despesas

Foi disponibilizado um relatório de controle de de diárias que mostra o extrato diário consolidado de todos os dias do mês digitado como parâmetro.

## Solução

Projeto gerado com o DotNet Core versão 6.0 
Banco de Dados da solução é SQL SERVER

## Acesso ao sistema


- username: 'teste@teste.com'
- password: '123456'

## BackEnd

para o backend criar o banco de dados no sql server executando o script `ScriptBancoDados.sql` e alterar a string de conexão com o banco de dados.
para executar o projeto localmente realizar o build do mesmo efetue o login de acesso com os dados indicados e depois faça a autenticação no swager com o tokem gerado
realizar os cadastros básicos conforme indicado na apresentação do projeto
para gerar o relatório digite o período correspondente