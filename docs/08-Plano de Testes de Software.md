# Plano de Testes de Software

<span style="color:red">
 
| **Caso de Teste** 	| **CT-01 – Cadastrar perfil** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-01 - AO sistema deve permitir que os clientes criem uma conta. |
| Objetivo do Teste 	| Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (e-mail, nome, sobrenome, celular, senha, confirmação de senha) <br> - Aceitar os termos de uso <br> - Clicar em "Registrar" |
|Critério de Êxito | - O cadastro foi realizado com sucesso. |
|  	|  	|

| **Caso de Teste** 	| **CT-02 – Cadastro e atualização de produtos**	|
|:---:	|:---:	|
|Requisito Associado | RF-02	-O sistema deve permitir que os gerentes cadastrem e atualizem informações de produtos, como descrições, preços e imagens. |
| Objetivo do Teste 	| Verificar se o usuário *GERENTE* consegue efetuar o cadastro e atualização dos produtos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados. <br> - Clicar em "Login" <br> - Clicar em "Alterar ou Cadastrar produto" |
|Critério de Êxito | - Os cadastros e alterações foram realizados com sucesso. |
|  	|  	|

| **Caso de Teste** 	| **CT-03 – Cadastro de Quizzes**	|
|:---:	|:---:	|
|Requisito Associado | RF-03 O sistema deve permitir que os gerentes cadastrem e atualizem quizzes interativos. |
| Objetivo do Teste 	| Verificar se o usuário *GERENTE* consegue realizar a postagem e/ou atualização de quizzes interativos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> - Clicar em "Login" <br> - Clicar em "Alterar ou Cadastrar produto" <br> - Salvar alterações e disponibilizar. |
|Critério de Êxito | - Os cadastros e alterações foram realizados com sucesso. |
|  	|  	|

| **Caso de Teste** 	| **CT-04 – Acesso e armazenamento de quizzes**	|
|:---:	|:---:	|
|Requisito Associado | RF-04 O sistema deve permitir que os clientes acessem a um quiz interativo que sugere os melhores produtos baseado nas suas necessidades. <br> RF-05 O sistema deve permitir que os clientes salvem o resultado do quiz em seu perfil |
| Objetivo do Teste 	| Verificar se o usuário *Cliente* consegue realizar os quizzes interativos, bem como o armazenamento deste em seu perfil. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> - Clicar em "Login" <br> - Realizar o quizz que deverá aparecer na tela inicial(casos de primeiro acesso). <br> Clicar em "Salvar resultado". |
|Critério de Êxito | - O cliente conseguiu realizar o Quizz corretamente e o resultado foi salvo em seu perfil. |
|  	|  	|

| **Caso de Teste** 	| **CT-05 – Busca**	|
|:---:	|:---:	|
|Requisito Associado | RF-06 O sistema deve permitir que os clientes pesquisem produtos por nome e categoria. |
| Objetivo do Teste 	| Verificar se o usuário *Cliente* obtém êxito ao buscar o produto desejado. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar na lupa, onde está escrito "buscar" <br> - Digitar o produto desejado <br> - Pressionar enter. <br> - Aguardar a conclusão da busca. |
|Critério de Êxito | - O cliente conseguiu buscar e encontrar o produto desejado. |
|  	|  	|

| **Caso de Teste** 	| **CT-06 – Favoritos**	|
|:---:	|:---:	|
|Requisito Associado | RF-07 O sistema deve permitir que os clientes favoritem os produtos escolhidos. |
| Objetivo do Teste 	| Verificar se o usuário *Cliente* obtém êxito ao favoritar um produto. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> - Clicar em "Login" <br> - Navegar até a página do produto desejado. <br> - Na página do produto, pressionar o botão "Adicionar a favorito ♥ ". <br> - Acessar o perfil para visualizar os produtos salvos como favoritos. |
|Critério de Êxito | - O cliente conseguiu adicionar um produto à sua lista de favoritos e também consegue visualizar os produtos em seu perfil. |
|  	|  	|

| **Caso de Teste** 	| **CT-07 – Carrinho de compras e compras**	|
|:---:	|:---:	|
|Requisito Associado | RF-08 O sistema deve permitir que os clientes adicionem produtos a um carrinho de compras. <br> RF-09 O sistema deve permitir que os clientes concluam a compra direcionando o pedido para um canal de comunicação externo com algum vendedor(a). |
| Objetivo do Teste 	| Verificar se o usuário *Cliente* obtém êxito ao adicionar um produto ao carrinho de compras e ao efetuar uma compra. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> - Clicar em "Login" <br> - Navegar até a página do produto desejado. <br> - Na página do produto, pressionar o botão "Adicionar ao carrinho 🛒 de compras ". <br> - Acessar o carrinho. <br> - Pressionar botão  "Finalizar com vendedor externo" <br>   |
|Critério de Êxito | - O cliente conseguiu adicionar um produto ao seu carrinho de compras e concluir a compra com vendedor externo. |
|  	|  	|

| **Caso de Teste** 	| **CT-08 – Contato com a loja**	|
|:---:	|:---:	|
|Requisito Associado | RF-10 O sistema deve permitir que os clientes entrem em contato com a loja por meio de outros canais (redes sociais) |
| Objetivo do Teste 	| Verificar se o usuário *Cliente* obtém êxito ao adicionar um produto ao carrinho de compras e ao efetuar uma compra. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Ir até o fim da página, onde estarão localizados os botões contendo as redes sociais do site(instagram e e-mail)  |
|Critério de Êxito | - O cliente conseguiu ser direcionado a pagina de contado desejada. |
|  	|  	|

> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
