```markdown
# Documentação – Colaboração com Git e GitHub utilizando Git Flow

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Aplicar práticas de **controle de versão e colaboração utilizando Git e GitHub**, incluindo:

- Uso de **Star e Fork**
- Criação e organização de **repositórios**
- Uso de **branches seguindo Git Flow**
- Colaboração entre colegas via **Pull Requests**
- Realização de **Code Review e Merge**
- Registro do processo com **evidências e comentários técnicos**

---

# Tecnologias e Ferramentas Utilizadas

- Git
- GitHub
- Terminal / Linha de comando
- Editor de código (Visual Studio ou VS Code)

---

# Conceitos Utilizados

## Git

Sistema de **controle de versão distribuído** utilizado para rastrear alterações em arquivos e facilitar a colaboração entre desenvolvedores.

## GitHub

Plataforma online para hospedagem de repositórios Git, permitindo:

- colaboração
- revisão de código
- gerenciamento de projetos

## Git Flow

Modelo de organização de branches que define padrões para desenvolvimento.

Estrutura principal:

```

main
develop
feature/*
release/*
hotfix/*

```

Descrição:

- **main** → versão estável do projeto
- **develop** → integração das funcionalidades
- **feature/** → desenvolvimento de novas funcionalidades

---

# Estrutura do Repositório

```

proj-final-usuario
│
├── README.md
├── .gitignore
└── codigo-do-projeto

```

Branches utilizadas:

```

main
develop
feature/*

```

---

# Etapas da Atividade

## 1. Interação com repositório do professor

Foi acessado o repositório da organização do professor no GitHub.

Repositório analisado:

```

[https://github.com/Daniel-Lim-Apo](https://github.com/Daniel-Lim-Apo)

```

Ações realizadas:

- Foi adicionada uma **estrela (Star)** no repositório
- Foi criado um **Fork** do repositório para a conta pessoal

Objetivo dessas ações:

- Demonstrar interação com projetos no GitHub
- Criar uma cópia do repositório para estudo e experimentação

Evidências incluídas no relatório:

- Print do repositório com a estrela marcada
- Print confirmando o Fork criado na conta pessoal

---

# 2. Criação do repositório do projeto final

Foi criado um novo repositório no GitHub com o nome:

```

proj-final-<usuario>

```

Configurações iniciais:

- Visibilidade: **Private**
- Arquivo **README.md** inicial
- Estrutura básica do projeto

Clone do repositório para o ambiente local:

```

git clone <URL-do-repositorio>
cd proj-final-usuario

```

Primeiro commit realizado:

```

git add .
git commit -m "chore: initial commit with readme and gitignore"
git push origin main

```

Evidência:

- Print da página do repositório com README visível

---

# 3. Inicialização do Git Flow

Foi criada a branch **develop**, utilizada para integração das funcionalidades.

Comandos utilizados:

```

git checkout -b develop
git push -u origin develop

```

Opcionalmente foi executado:

```

git flow init

```

Configuração padrão:

```

Production branch: main
Development branch: develop

```

Evidência:

- Print das branches existentes no repositório

---

# 4. Desenvolvimento de uma Feature

Foi criada uma branch de funcionalidade seguindo o padrão **feature/**.

Exemplo:

```

git checkout develop
git checkout -b feature/health-endpoint

```

Nesta branch foi implementada uma melhoria ou funcionalidade no projeto.

Após a implementação foram realizados commits:

```

git add .
git commit -m "feat: add health endpoint"

```

Envio da branch para o GitHub:

```

git push -u origin feature/health-endpoint

```

Posteriormente foi aberta uma **Pull Request** para integração com a branch **develop**.

Evidências:

- Print da Pull Request criada
- Print da descrição da PR
- Print da aba **Files changed**

---

# 5. Colaboração entre colegas

Foi configurada colaboração entre os integrantes da dupla.

Passos realizados:

1. Adição do colega como **Collaborator** no repositório.
2. O colega clonou o repositório.
3. Criou uma nova branch de feature.

Exemplo:

```

git checkout develop
git checkout -b feature/improve-health-endpoint

```

Após implementar melhorias:

```

git add .
git commit -m "feat: improve health endpoint with app version"
git push -u origin feature/improve-health-endpoint

```

O colega abriu uma **Pull Request** para a branch **develop**.

O autor do repositório realizou:

- revisão de código
- comentários
- aprovação da PR
- merge da alteração

Evidências:

- Print da tela de colaboradores
- Print da PR aberta pelo colega
- Print das conversas de review
- Print do merge realizado

---

# 6. Contribuição no repositório do colega

O processo também foi realizado no repositório do colega.

Passos realizados:

1. Clone do repositório do colega
2. Criação de branch de feature
3. Implementação de melhoria
4. Commit e push
5. Criação de Pull Request

Evidências:

- Print da PR aberta
- Print dos commits
- Print das alterações realizadas

---

# 7. (Opcional) Criação de Release e Tag

Após a integração das funcionalidades foi criada uma tag de versão.

Comandos utilizados:

```

git checkout main
git pull
git tag -a v1.0.0 -m "Initial release"
git push origin v1.0.0

```

Evidência:

- Print da tag criada no GitHub

---

# 8. (Opcional) Uso de Issues

Foi criada uma **Issue** descrevendo uma tarefa do projeto.

Essa issue foi vinculada a uma Pull Request utilizando:

```

Closes #1

```

Isso permite que a issue seja fechada automaticamente quando a PR for mergeada.

Evidência:

- Print da Issue criada
- Print da PR vinculada à Issue

---

# Evidências Necessárias

Foram registradas evidências do processo por meio de capturas de tela, incluindo:

- Star no repositório do professor
- Fork realizado
- Página do repositório do projeto final
- Branches main e develop
- Pull Request da feature criada
- Tela de colaboradores adicionando colega
- Pull Request do colega no repositório
- Revisão de código
- Merge da Pull Request
- (Opcional) criação de release/tag
- (Opcional) criação de issue

---

# Aprendizados

Durante esta atividade foi possível compreender:

- Como utilizar Git para controle de versão
- Como utilizar GitHub para colaboração entre desenvolvedores
- Como estruturar branches utilizando Git Flow
- Como realizar Pull Requests e revisões de código
- Como organizar um fluxo de desenvolvimento colaborativo

---

# Conclusão

A atividade permitiu aplicar na prática conceitos fundamentais de **controle de versão e colaboração em equipe**, que são amplamente utilizados no desenvolvimento profissional de software.

O uso de **Git Flow, Pull Requests e Code Review** contribui para manter o código organizado, rastreável e com maior qualidade.

---

# Autor

Luiz  
Disciplina: Desenvolvimento de Sistemas  
Instituição: CEUB
```
