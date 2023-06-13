# Especificações do Projeto

A definição do problema e os pontos mais relevantes a serem tratados neste projeto foram consolidados com a participação de clientes da loja **Permita-se** a partir de conversas e entrevistas. Os detalhes levantados nesse processo foram agrupados na forma de personas e histórias de usuários.

## Personas

As personas levantadas durante o processo de entendimento do problema são apresentadas nas tabelas que se seguem. 

| **Bianca Souza** |      |      |
|------------------------------|------|------|
|![persona1](img/persona1.jpg) | **Idade:** 40 anos  | **Ocupação:** Terapeuta Holística, Massoterapeuta e proprietaria da loja Permita-se e atua como vendedora. Empreendedora. |
| **Motivações:** Bianca Souza é motivada pela necessidade de aprendizado através de cursos, por trabalhos artesanais e pela família	| **Frustrações:** Não conseguir passar credibilidade de seus produtos somente através das redes sociais | **Hobbies, História:** Estudar, levar uma vida saudável aos clientes, viajar|

| **Iza Souza** |      |      |
|------------------------------|------|------|
|![persona2](img/persona2.jpg) | **Idade:** 34 anos  | **Ocupação:** Técnica de laboratório, empreendedora e cliente da loja Permita-se  |
| **Motivações:** Iza Souza é movida pelo crescimento profissional e pelo amor aos familares.	| **Frustrações:** Plataformas de vendas sem todas as informações dos produtos | **Hobbies, História:** Viajar, leitura e assistir series/filmes|

| **Fernanda Mendes** |      |      |
|------------------------------|------|------|
|![persona3](img/persona3.jpg) | **Idade:** 27 anos  | **Ocupação:** Biomédica, empreendedora e cliente da loja Permita-se |
| **Motivações:** Fernanda encontra motivação no amor a família e pelos estudos.	| **Frustrações:** Dificuldade em localizar e ordenar os produtos desejados na hora da compra | **Hobbies, História:** passeios com os amigos, viagens.|


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:
|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Bianca Souza        | Deseja uma plataforma onde consiga postar os seus produtos, com fotos e todas as especificações de cada um. | Para facilitar na divulgação dos seus produtos. |
|Bianca Souza          | Deseja uma plataforma onde consiga filtrar e ordenar seus produtos. | Para direcionar a venda com o produto correto para cada cliente. |
|Bianca Souza     |Deseja uma plataforma onde o cliente consiga criar um cadastro no site  | Para futuramente o cliente receber ofertas via e- mail. |
|Iza Souza      | Deseja um canal de comunicação de fácil acesso com os vendedores da loja através do catálogo de vendas. | Para agilizar o processo de compra e tirar dúvidas caso seja necessário. |
|Iza Souza       | Deseja localizar por categorias todas as informações necessárias para a escolha do seu produto. | Para não se perder entre as páginas e ter agilidade na compra.  |
|Iza Souza        | Deseja deixar como produtos favoritos. | Para finalizar a compra mais tarde. |
|Fernanda Mendes        | Deseja ter acesso a informações sobre o produto de forma clara e acessível.| Para conhecer melhor a marca e os produtos ofertados. |
|Fernanda Mendes     |   Deseja pesquisar o produto por uma barra de busca | Para facilitar a localização do produto desejado. |
|Fernanda Mendes       |Deseja criar um carrinho com os produtos desejados. | Para finalizar a compra com mais rapidez.  |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01| O sistema deve permitir que os clientes criem uma conta | Alta |
|RF-02| O sistema deve permitir que os gerentes cadastrem e atualizem informações de produtos, como descrições, preços e imagens. | Alta |  
|RF-03| O sistema deve permitir que os clientes pesquisem produtos por nome e categoria.	| Média |
|RF-04| O sistema deve permitir que os clientes favoritem os produtos escolhidos | Baixa | 
|RF-05| O sistema deve permitir que os clientes adicionem produtos a um carrinho de compras  | Alta |
|RF-06| O sistema deve permitir que os clientes concluam a compra direcionando o pedido para um canal de comunicação externo com algum vendedor(a). | Alta | 
|RF-07| O sistema deve permitir que os clientes entrem em contato com a loja por meio de outros canais (redes sociais) | Baixa | 


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01| O sistema deve ser fácil de usar, intuitivo e ter uma interface amigável para os usuários | Alta | 
|RNF-02| O sistema deve ser responsivo permitindo a visualização em diferentes tamanhos de telas.  |  Médio | 
|RNF-03| O sistema deve ser publicado em um ambiente acessível publicamente na Internet | Alta | 
|RNF-04| O sistema deve garantir a privacidade e a segurança das informações dos usuários |  Alta | 
|RNF-05| O sistema deve ser fácil de manter, atualizar e corrigir, sem afetar a disponibilidade ou a qualidade do serviço  | Média | 
|RNF-06| O sistema deve ser compatível com os principais navegadores da atualidade (Google Chrome, Opera, Firefox, Microsoft Edge).  |  Média | 

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RE-01| O projeto deverá ser entregue no final do semestre letivo, não podendo extrapolar a data de 19/06/2023 |
|RE-02| O sistema deve se restringir às tecnologias de C# e banco de dados |
|RE-03| A equipe não pode subcontratar o desenvolvimento do trabalho   |

## Diagrama de Casos de Uso

O objetivo do diagrama de caso de uso em UML é demonstrar as diferentes maneiras que um usuário pode interagir com o sistema. Para o nosso caso, teremos apenas dois usuários: Cliente e Gerente, e no diagrama abaixo, podemos visualizar as funcionalidades acessadas por cada um.

![casos-de-uso-permita-se](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t1-time2-aro/assets/89558202/6749d81a-7a03-49b3-ae79-d0c3c410a8d2)
