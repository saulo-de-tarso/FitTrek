<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Documentação Completa - FitTrek API</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 0;
            padding: 20px;
        }
        h1, h2 {
            color: #4CAF50;
        }
        h3 {
            color: #333;
        }
        p {
            margin-bottom: 1em;
        }
        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border-radius: 5px;
            overflow-x: auto;
        }
        code {
            background-color: #f4f4f4;
            padding: 2px 4px;
            font-size: 90%;
        }
        .note {
            background-color: #f9f9f9;
            border-left: 5px solid #4CAF50;
            padding: 10px;
            margin: 20px 0;
        }
        ul {
            margin-bottom: 20px;
        }
        li {
            margin-bottom: 10px;
        }
        a {
            text-decoration: none;
            color: #4CAF50;
        }
        a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>

    <h1>Documentação Completa - FitTrek API</h1>

    <h2>Índice</h2>
    <ul>
        <li><a href="#visao-geral">Visão Geral</a></li>
        <li><a href="#entidades">Entidades da API</a></li>
        <li><a href="#autenticacao">Autenticação e Autorização</a></li>
        <li><a href="#instalacao">Instalação e Configuração</a></li>
        <li><a href="#endpoints">Endpoints da API</a></li>
        <li><a href="#identidade">Endpoint de Identidade</a></li>
        <li><a href="#seeder">Seeder</a></li>
        <li><a href="#deploy">Implantação no Azure</a></li>
    </ul>

    <h2 id="visao-geral">Visão Geral</h2>
    <p>A <strong>FitTrek API</strong> é uma aplicação RESTful (RESTful API) que permite a nutricionistas gerenciarem clientes, planos de dieta e refeições. A API adota controle de acesso baseado em funções (RBAC) e usa o <strong>ASP.NET Core Identity</strong> para autenticação e autorização. Com ela, nutricionistas podem criar, ler, atualizar e excluir (CRUD) dados relacionados a clientes, dietas e refeições, enquanto admins podem gerenciar nutricionistas. A API está conectada a um banco de dados Microsoft SQL Server.</p>

    <h3>Principais Funcionalidades:</h3>
    <ul>
        <li><strong>Admins</strong> podem gerenciar nutricionistas.</li>
        <li><strong>Nutricionistas</strong> podem gerenciar seus clientes, planos de dieta e refeições.</li>
        <li>A API aplica controle de acesso baseado em papéis para os usuários.</li>
        <li>Possui uma estrutura de autenticação baseada utilizando o <strong>ASP.NET Core Identity</strong></li>
        <li>O banco de dados é hospedado no <strong>ASP.NET Core Identity</strong></li>
        <li>Possui suporte para <strong>implantação no Microsoft Azure</strong> e execução local.</li>
    </ul>

    <h2 id="entidades">Entidades da API</h2>
    <ul>
        <li><strong>Nutricionistas:</strong> Representa um usuário que gerencia clientes, dietas e refeições.</li>
        <li><strong>Clientes:</strong> Representa indivíduos que são atribuídos planos de dieta por nutricionistas.</li>
        <li><strong>Planos de Dieta:</strong> Representa planos de dieta específicos atribuídos a um cliente.</li>
        <li><strong>Refeições:</strong> Representa refeições específicas incluídas em um plano de dieta.</li>
    </ul>

    <h2 id="autenticacao">Autenticação e Autorização</h2>
    <p>A API usa o **Microsoft Identity** para autenticação e autorização de usuários. Todos os endpoints exigem que o usuário seja autenticado via <strong>Bearer token</strong>. Os papéis de usuário suportados são:</p>
    <ul>
        <li><strong>Admin</strong>: Pode gerenciar nutricionistas e aplicar operações CRUD (criar, ler, atualizar e excluir).</li>
        <li><strong>Nutricionista</strong>: Pode gerenciar seus clientes, planos de dieta e refeições, e aplicar operações CRUD (criar, ler, atualizar e excluir) nessas entidades.</li>
    </ul>
    <p><strong>Nota:</strong> Apenas administradores podem gerenciar nutricionistas. Nutricionistas não podem gerenciar outros nutricionistas e seus clientes ou admins. Admins não podem gerenciar clientes de nutricionistas.</p>

    <h2 id="instalacao">Instalação e Configuração</h2>
    <h3>Pré-Requisitos</h3>
    <ul>
        <li><strong>.NET SDK</strong> versão 7.0 ou superior.</li>
        <li><strong>Microsoft SQL Server</strong> (ou outro servidor SQL compatível).</li>
        <li><strong>Azure CLI</strong> (se for fazer a implantação no Azure).</li>
        <li><strong>Postman</strong> ou <strong>Insomnia</strong> para testar as requisições (opcional).</li>
    </ul>

    <h3>Passos para Instalação</h3>
    <ol>
        <li><strong>Clonar o repositório:</strong>
            <pre><code>git clone https://github.com/saulo-de-tarso/FitTrek.git
cd FitTrek</code></pre>
        </li>
        <li><strong>Configuração do banco de dados:</strong>
            <p>Abra o arquivo <code>appsettings.json</code> e configure a string de conexão para o seu SQL Server.</p>
            <pre><code>"ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=FitTrekDB;User Id=seu-usuario;Password=sua-senha;"
}</code></pre>
        </li>
        <li><strong>Instalar dependências:</strong>
            <pre><code>dotnet restore</code></pre>
        </li>
        <li><strong>Aplicar migrações do banco de dados:</strong>
            <pre><code>dotnet ef database update</code></pre>
        </li>
        <li><strong>Rodar a aplicação:</strong>
            <pre><code>dotnet run</code></pre>
            <p>A API estará acessível em <code>http://localhost:7279</code> por padrão.</p>
        </li>
    </ol>

    <h2 id="endpoints">Endpoints da API</h2>
    <h3>Autenticação (Identity)</h3>
    <p><strong>POST /api/identity/register</strong> - Não requer autenticação</p>
    <p><strong>Descrição:</strong> Registra usuário na aplicação.</p>
    <pre><code>{
  "email": "seuemail@email.com",
  "password": "suasenha"
}</code></pre>

    <p><strong>POST /api/identity/login</strong> - Não requer autenticação</p>
    <p><strong>Descrição:</strong> Realiza login e retorna um Bearer token.</p>
    <pre><code>{
        "email": "seuemail@email.com",
        "password": "suasenha"
}</code></pre>
    <p><strong>Resposta:</strong></p>
    <pre><code>{
  "tokenType": "Bearer",
  "accessToken": "seu-token-de-acesso",
  "expiresIn": 3600,
  "refreshToken": "refresh-token"

}</code></pre>

<p><strong>POST /api/identity/userRole - Requer autenticação</strong></p> 
    <p><strong>Descrição:</strong> Atribui uma função de usuário a um usuário. Funções aceitas: Admin e Nutritionist. Se a função for Admin, só precisa informar e-mail e senha. 
        Se for nutricionista (Nutritionist), precisa informar o Id do nutricionista. Para nutricionista, requer pré-cadastro do nutricionista através de um Admin no
        endpoint <strong>POST /api/nutritionists</strong>.</p>
    <pre><code>{
        "userEmail": "email-do-usuario@exemplo.com",
        "roleName": "funcao-do-usuario"
}</code></pre>

<p><strong>DELETE /api/identity/userRole - Requer autenticação</strong></p> 
    <p><strong>Descrição:</strong> Desatribui uma função de usuário a um usuário.</p>
    <pre><code>{
        "userEmail": "email-do-usuario@email.com",
        "roleName": "funcao-do-usuario"
}</code></pre>
    

    <h3>Nutricionistas (Nutritionists) - Requer autenticação e apenas Admins estão autorizados</h3>
    <p><strong>POST /api/nutritionists</strong></p>
    <p><strong>Descrição:</strong> Cria um novo nutricionista. 
        Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-nutricionista@exemplo.com",
        "phoneNumber": "(32) 91527-7307",
        "dateOfBirth": "2024-11-13"
}</code></pre>

    <p><strong>GET /api/nutritionists</strong></p>
    <p><strong>Descrição:</strong> Retorna todos os nutricionistas cadastrados na base de dados. 
        Podem ser filtrados por caracteres contendo nos nomes, e ordenados por nome ou receita mensal atual, em ordem crescente ou decrescente. Resultados
    paginados e o usuário pode escolher quantos resultados exibir por página (5, 10, 15 ou 30).</p>

    <p><strong>GET /api/nutritionists/{id}</strong></p>
    <p><strong>Descrição:</strong> Retorna dados do nutricionista informando o Id. 
        Caso o Id não exista, retorna uma exceção informando que o nutricionista não existe.</p>

    <p><strong>DELETE /api/nutritionists/{id}</strong></p>
    <p><strong>Descrição:</strong> Exclui um nutricionista informando o Id. 
        Caso o Id não exista, retorna uma exceção informando que o nutricionista não existe.</p>

        <p><strong>PATCH /api/nutritionists/{id}</strong></p>
    <p><strong>Descrição:</strong> Atualiza dados de um nutricionista informando o Id. 
        Caso o Id não exista, retorna uma exceção informando que o nutricionista não existe. 
    É possível passar dados parcialmente, caso o usuário queira atualizar apenas uma propriedade. 
    Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-nutricionista@exemplo.com",
        "phoneNumber": "(32) 91527-7307",
        "dateOfBirth": "2024-11-13"
}</code></pre>

    

    <h3>Clientes (Clients) - Requer autenticação e apenas nutricionistas (Nutritionist) estão autorizados</h3>
    <p><strong>POST /api/clients</strong></p>
    <p><strong>Descrição:</strong> Cria um novo cliente para o nutricionista logado. 
        Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-cliente@exemplo.com",
        "phoneNumber": "(11) 92389-9533",
        "gender": "Male",
        "dateOfBirth": "2024-11-13",
        "heightInCm": 300,
        "weightInKg": 500,
        "subscriptionPlan": "Silver"
}</code></pre>

    <p><strong>GET /api/clients</strong></p>
    <p><strong>Descrição:</strong> Retorna todos os clientes cadastrados na base de dados para o nutricionista logado. 
        Podem ser filtrados por caracteres contendo nos nomes, e ordenados por nome ou receita mensal atual, em ordem crescente ou decrescente. Resultados
    paginados e o usuário pode escolher quantos resultados exibir por página (5, 10, 15 ou 30).</p>

    <p><strong>GET /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Retorna dados do cliente informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o cliente não existe.</p>

    <p><strong>DELETE /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Exclui um cliente informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o cliente não existe.</p>

        <p><strong>PATCH /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Atualiza dados de um cliente informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o cliente não existe. 
    É possível passar dados parcialmente, caso o usuário queira atualizar apenas uma propriedade. 
    Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-cliente@exemplo.com",
        "phoneNumber": "(11) 92389-9533",
        "gender": "Male",
        "dateOfBirth": "2024-11-13",
        "heightInCm": 200,
        "weightInKg": 500,
        "subscriptionPlan": "Silver"
}</code></pre>

<h3>Planos de dieta (DietPlans) - Requer autenticação e apenas nutricionistas (Nutritionist) estão autorizados</h3>
    <p><strong>POST /api/dietplans</strong></p>
    <p><strong>Descrição:</strong> Cria um novo plano de dieta para um cliente do nutricionista logado. 
        Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-plano de dieta@exemplo.com",
        "phoneNumber": "(11) 92389-9533",
        "gender": "Male",
        "dateOfBirth": "2024-11-13",
        "heightInCm": 300,
        "weightInKg": 500,
        "subscriptionPlan": "Silver"
}</code></pre>

    <p><strong>GET /api/clients</strong></p>
    <p><strong>Descrição:</strong> Retorna todos os plano de dietas cadastrados na base de dados para o nutricionista logado. 
        Podem ser filtrados por caracteres contendo nos nomes, e ordenados por nome ou receita mensal atual, em ordem crescente ou decrescente. Resultados
    paginados e o usuário pode escolher quantos resultados exibir por página (5, 10, 15 ou 30).</p>

    <p><strong>GET /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Retorna dados do plano de dieta informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o plano de dieta não existe.</p>

    <p><strong>DELETE /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Exclui um plano de dieta informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o plano de dieta não existe.</p>

        <p><strong>PATCH /api/clients/{id}</strong></p>
    <p><strong>Descrição:</strong> Atualiza dados de um plano de dieta informando o Id. 
        Caso o Id não exista, ou seja relacionado a outro nutricionista, retorna uma exceção informando que o plano de dieta não existe. 
    É possível passar dados parcialmente, caso o usuário queira atualizar apenas uma propriedade. 
    Validação: e-mail tem que ser um valor válido, e número de telefone deve ser válido e estar no formato (XX) 9XXXX-XXXX.</p>
    <pre><code>{
        "firstName": "Nome",
        "lastName": "Sobrenome",
        "email": "email-do-plano de dieta@exemplo.com",
        "phoneNumber": "(11) 92389-9533",
        "gender": "Male",
        "dateOfBirth": "2024-11-13",
        "heightInCm": 200,
        "weightInKg": 500,
        "subscriptionPlan": "Silver"
}</code></pre>

    <h2 id="seeder">Seeder</h2>
    <p>O Seeder cria dados padrão no banco de dados caso ele esteja vazio:</p>
    <ul>
        <li>Cria um <strong>nutricionista</strong> inicial.</li>
        <li>Cria um <strong>cliente</strong> inicial.</li>
        <li>Cria os <strong>papéis de usuário</strong> padrão.</li>
    </ul>

    <h2 id="deploy">Implantação no Azure</h2>
    <h3>Passos para Implantação</h3>
    <ol>
        <li><strong>Criar um App Service no Azure:</strong> Crie um novo App Service no portal Azure.</li>
        <li><strong>Implantar via Azure CLI:</strong>
            <pre><code>az webapp up --name nome-da-aplicacao --resource-group grupo-de-recursos --plan plano-app</code></pre>
        </li>
        <li><strong>Configurar a string de conexão:</strong> Configure as variáveis de ambiente para o banco de dados no App Service.</li>
    </ol>


</body>
</html>
