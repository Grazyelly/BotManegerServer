# 🤖 BotManager

Projeto desenvolvido em .NET 8 para gerenciamento e execução de bots, com integração à inteligência artificial da Google. O sistema segue uma arquitetura em camadas, com separação clara de responsabilidades, e utiliza Entity Framework Core com SQLite para persistência de dados.

---

## 🏗️ Arquitetura

O projeto adota uma **arquitetura em camadas**, favorecendo a escalabilidade, testes e manutenibilidade. As camadas estão organizadas da seguinte forma:

- **`BotManagerServer.Api`**  
  Camada de apresentação (exposição da Web API, Injeções de dependência)
  
- **`BotManagerServer.Infra`**  
  Camada de aplicação (serviços, casos de uso, validações)
  
- **`BotManagerServer.Core`**  
  Camada de domínio (entidades de negócio, interfaces)
  
- **`BotManagerServer.Data`**  
  Camada de infraestrutura de dados (migrations, contexto EF, repositórios)
  
- **`BotManagerServer.ExternalServices`**  
  Camada de integração com serviços externos (API do Google)

---

## 🧩 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional)
- Chave de API da Google (para IA)
- Editor: Visual Studio 2022, VS Code

---

## ⚙️ Configuração

1. **Clone o repositório:**

```bash
git clone https://github.com/seu-usuario/BotManager.git
cd BotManager
```

2. **Configure a string de conexão no `appsettings.json`. Exemplo a baixo**

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=complete_com_o_caminho_ate_essa_pasta\\BotManagerServer.Data\\chatbots.db"
}
```

> 🛠️ Altere o caminho para refletir o ambiente da sua máquina.

3. **Configure a chave da IA da Google:**

Adicione ao arquivo `OpenAiService.cs` dentro da camada externalService, onde está Key= você devera passar sua chave na frente.

```.cs
var response = await _httpClient.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/{request.model}:generateContent?key=", content);
```

---

## 🗃️ Banco de Dados (Entity Framework Core)

### Para execução dos comandos abaixo referente a migrations você deve estar referenciando a pasta BotManagerServer.Data no seu terminal, após isso pode voltar para pasta raiz.

### ▶️ Aplicar migrations existentes:

```bash
cd BotManagerServer.Data
dotnet ef database update
```

### 🏗️ Criar uma nova migration:

```bash
cd BotManagerServer.Data
dotnet ef migrations add NomeDaMigration
```

> Certifique-se de que o pacote `Microsoft.EntityFrameworkCore.Design` está instalado e o projeto `.Data` está referenciado.

---

## 🚀 Executando o projeto

Para iniciar a aplicação, entre no diretório da API e execute:

```bash
cd BotManagerServer.Api
dotnet run
```

A API estará disponível nos seguintes endpoints:
- `https://localhost:5001`
- `http://localhost:5000`

---

## 📂 Estrutura de Pastas (resumo)

```
BotManager/
├── BotManagerServer.Api/              # Camada de apresentação (Web API)
├── BotManagerServer.Infra/      	   # Regras de negócio / Casos de uso
├── BotManagerServer.Core/             # Entidades e contratos
├── BotManagerServer.Data/             # EF Core, repositórios, migrations
├── BotManagerServer.ExternalServices/ # Integrações com serviços externos (Google IA)
```


---

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).