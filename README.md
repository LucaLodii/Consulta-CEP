# Mini Projeto — Consulta de CEP
## Arquitetura Hexagonal em .NET

### Objetivo do Projeto
Desenvolver uma Web API em .NET que consulte informações de um CEP utilizando uma API pública (ex: ViaCEP ou Correios), aplicando os princípios da Arquitetura Hexagonal.

---

### Requisitos Técnicos
| Categoria          | Requisito                                  |
| ------------------ | ------------------------------------------ |
| **Framework** | .NET 8.0 ou superior                       |
| **Arquitetura** | Hexagonal (Ports & Adapters)               |
| **Formato de Retorno** | JSON                                       |
| **Documentação** | Swagger                                    |
| **Boas Práticas** | Clean Code, SOLID                          |
| **Outros** | Tratamento de erros, Injeção de dependência |

---

### Estrutura Recomendada da Solução
```

ConsultaCep/
├── Domain
│   ├── Entities
│   └── Interfaces
├── Application
│   ├── UseCases
│   ├── DTOs
│   └── Interfaces
├── Infrastructure
│   ├── Adapters
│   └── ExternalServices
└── WebApi
├── Controllers
└── Program.cs

```

> **Dica:** Pense na arquitetura como “camadas de cebola”: o Domínio está no centro (regra de negócio), e as demais camadas apenas o “tocam” por meio de contratos.

---

### Roteiro de Desenvolvimento

#### Etapa 1 — Configuração Inicial
- [ ] Criar a solução e os projetos nas camadas propostas.
- [ ] Configurar o Swagger para documentar os endpoints.
- [ ] Criar um endpoint de teste (`/health`) para validar o funcionamento.
**Objetivo:** garantir que o projeto esteja rodando corretamente.

#### Etapa 2 — Modelagem de Domínio
- [ ] Identificar os dados necessários de um endereço (CEP, Logradouro, Cidade, UF etc).
- [ ] Criar a entidade principal do domínio.
- [ ] Definir a interface (porta de saída) que representará o serviço de consulta de CEP.
**Objetivo:** definir o núcleo do sistema — as regras de negócio e contratos.

#### Etapa 3 — Caso de Uso (Application Layer)
- [ ] Criar um caso de uso responsável por:
    - Receber o CEP da requisição.
    - Validar o formato do CEP.
    - Acionar a interface do serviço (porta de saída).
- [ ] Preparar o retorno com os dados do endereço.
**Objetivo:** concentrar a lógica de aplicação e orquestrar as chamadas.

#### Etapa 4 — Adapter Externo (Infrastructure Layer)
- [ ] Criar um adapter que consulta uma API pública (ViaCEP ou Correios).
- [ ] Tratar erros de comunicação (API fora do ar, CEP inválido, etc.).
- [ ] Converter o retorno da API externa para o modelo interno da aplicação.
**Objetivo:** conectar a aplicação ao mundo externo sem acoplar regras de negócio.

#### Etapa 5 — Controller (Web Layer)
- [ ] Criar o controller que expõe o endpoint `/api/cep/{cep}`.
- [ ] Injetar o caso de uso por meio de Dependency Injection.
- [ ] Tratar respostas e erros com códigos HTTP adequados.
**Objetivo:** criar o ponto de entrada da aplicação para os consumidores da API.

#### ⚙️ Etapa 6 — Injeção de Dependências
- [ ] Registrar casos de uso, interfaces e adapters no container do .NET.
- [ ] Garantir que a aplicação resolva as dependências automaticamente.
**Objetivo:** ligar todas as camadas da arquitetura de forma desacoplada.

#### Etapa 7 — Testes
- [ ] Criar testes unitários para o caso de uso principal.
- [ ] Mockar o serviço externo de CEP.
- [ ] Validar cenários de sucesso, erro e CEP inválido.
**Objetivo:** aprender a testar regras de negócio isoladas da infraestrutura.

---

### Aprendizados Esperados
- ✅ Entender o conceito de Arquitetura Hexagonal
- ✅ Aplicar o princípio da inversão de dependência
- ✅ Separar regras de negócio de infraestrutura técnica
- ✅ Usar injeção de dependência corretamente
- ✅ Construir uma API REST profissional em .NET

---

### Entrega Final
- [x] Endpoint funcional: `GET /api/cep/{cep}`
- [x] Arquitetura Hexagonal aplicada
- [x] Documentação (Swagger)
- [x] Projeto rodando e testável localmente

```