# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
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
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> <br> - Clicar em "Login" <br> - Clicar em "Alterar ou Cadastrar produto" |
|Critério de Êxito | - Os cadastros e alterações foram realizados com sucesso. |
|  	|  	|

| **Caso de Teste** 	| **CT-03 – Cadastro de Quizzes**	|
|:---:	|:---:	|
|Requisito Associado | RF-03 O sistema deve permitir que os gerentes cadastrem e atualizem quizzes interativos. |
| Objetivo do Teste 	| Verificar se o usuário *GERENTE* consegue realizar a postagem e/ou atualização de quizzes interativos. |
| Passos 	| - Acessar o navegador <br> - Informar o endereço do site (link a ser disponibilizado)<br> - Clicar no botão "Entrar" <br> - Preencher os dados solicitados <br> - Clicar em "Login" <br> - Clicar em "Alterar ou Cadastrar produto" |
|Critério de Êxito | - Os cadastros e alterações foram realizados com sucesso. |
|  	|  	|
 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
