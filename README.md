# API Catálogo - ASP.NET Core

## 📖 **Sobre o Projeto**

**API Catálogo** é uma API RESTful desenvolvida em ASP.NET Core para gerenciar um catálogo de produtos e suas 
respectivas categorias. O projeto foi estruturado seguindo as melhores práticas de desenvolvimento de software, como 
a separação de responsabilidades, o uso de padrões de projeto e a implementação de funcionalidades robustas, tornando-o 
uma base sólida e escalável para aplicações de e-commerce ou sistemas de gerenciamento de estoque.

Este projeto demonstra a aplicação prática de conceitos essenciais do ecossistema .NET para a construção de APIs 
eficientes e bem arquitetadas.

---

## ✨ **Funcionalidades Principais**

### Gestão de Categorias:

- `GET`: Listar todas as categorias com suporte a paginação.
- `GET`: Obter uma categoria específica por ID.
- `GET`: Filtrar categorias por nome, com paginação.
- `POST`: Criar uma nova categoria.
- `PUT`: Atualizar uma categoria existente.
- `DELETE`: Excluir uma categoria.

### Gestão de Produtos:

- `GET`: Listar todos os produtos.
- `GET`: Obter um produto específico por ID.
- `GET`: Listar produtos por categoria.
- `GET`: Listar produtos com paginação.
- `GET`: Filtrar produtos por critério de preço (maior, menor ou igual) com paginação.
- `POST`: Adicionar um novo produto.
- `PUT`: Atualizar um produto por completo.
- `PATCH`: Atualizar parcialmente um produto (ex: apenas estoque ou data).
- `DELETE`: Excluir um produto.

### Recursos Adicionais:

- **Tratamento de Exceções Global**: Middleware para capturar erros não tratados e retornar uma 
resposta padronizada.

- **Logging Customizado**: Implementação de um sistema de log para registrar eventos e erros em um 
arquivo de texto.

- **Documentação com Scalar/OpenAPI**: Geração automática da documentação da API, facilitando os testes 
e o consumo dos endpoints.

---

## 🏛️ Arquitetura e Padrões de Projeto

A arquitetura do projeto foi desenhada para ser limpa, organizada e de fácil manutenção, utilizando 
os seguintes padrões:

### **Padrão Repository e Unit of Work**:

- **Repository**: Abstrai a lógica de acesso a dados, desacoplando a camada de negócio da camada de 
persistência. Cada entidade possui seu repositório (`ProdutoRepository`, `CategoriaRepository`).

- **Unit of Work**: Mantém o controle sobre as transações do banco de dados, garantindo a consistência dos 
dados ao agrupar operações em uma única transação (`CommitAsync`).


### **Data Transfer Objects (DTOs)**:

- Utilizados para transferir dados entre a API e os clientes (ex: `ProdutoDTO`, `CategoriaDTO`). Isso evita a 
exposição direta das entidades do domínio e permite modelar os dados de forma otimizada para a visualização.
- **AutoMapper**: Utilizado para realizar o mapeamento automático entre as entidades de domínio e os DTOs, simplificando 
o código e eliminando a necessidade de conversões manuais.

### **Injeção de Dependência (DI)**:

- O ASP.NET Core gerencia o ciclo de vida dos serviços (como repositórios e o Unit of Work), injetando-os 
automaticamente nos controllers, o que promove o baixo acoplamento e facilita os testes unitários.

---

## **🛠️ Tecnologias Utilizadas**
- **Framework**: .NET 9.0
- **API**: ASP.NET Core
- **ORM**: Entity Framework Core 9.0
- **Banco de Dados**: MySQL
- **Mapeamento de Objetos**: AutoMapper
- **Serialização JSON**: Newtonsoft.Json
- **Documentação**: Scalar/OpenAPI

---

## 🚀 **Como Executar o Projeto**

Siga os passos abaixo para configurar e executar o projeto em seu ambiente local.
- .NET 9.0 SDK ou superior.
- A ferramenta de linha de comando do Entity Framework Core. Se não tiver, instale com o comando:

```bash
dotnet tool install --global dotnet-ef
```

- Um editor de código de sua preferência (ex: Visual Studio, VS Code).
- Um servidor de banco de dados MySQL ou MariaDB.

**1. Clonar o Repositório**

```bash
git clone https://URL-DO-SEU-REPOSITORIO.git
cd ASPNET-APICATALOGO
```

**2. Configurar a Conexão com o Banco de Dados**

Abra o arquivo `appsettings.json` e modifique a `DefaultConnection` 
com as credenciais do seu banco de dados MySQL.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;DataBase=CatalogoDB;Uid=seu_usuario;Pwd=sua_senha"
  },
  // ...
}
```

**3. Aplicar as Migrations**

As *migrations* do Entity Framework Core são responsáveis por criar e atualizar o schema 
do banco de dados com base nas suas entidades. Execute o comando abaixo no terminal, na raiz 
do projeto:

```bash
dotnet ef database update
```

Este comando criará o banco de dados `CatalogoDB` (se não existir) e as tabelas `Categorias` e `Produtos`. 
Ele também irá popular as tabelas com dados iniciais, conforme definido nos arquivos de migration.

**4. Executar a Aplicação**

Execute o seguinte comando para iniciar a API:

```bash
dotnet run
```

A API estará em execução e acessível em `https://localhost:7052` e `http://localhost:5159`.

**5. Acessar a Documentação**

Com a aplicação em execução, acesse a URL abaixo em seu navegador para visualizar a documentação 
interativa da API e testar os endpoints:

https://localhost:7052/scalar/v1