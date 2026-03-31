# Projeto: CLI em JavaScript – Parâmetros em Dobro

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Criar uma aplicação console em **JavaScript** (linguagem diferente de C#) que:
- Receba parâmetros pela linha de comando
- Calcule e imprima o **dobro da quantidade de parâmetros**
- Imprima **cada parâmetro duas vezes**
- Replique a funcionalidade da versão em C# (Pasta 2)

---

## Status da Entrega

✅ **Completo** - Projeto pronto para apresentação com todas as evidências

---

## Arquivos Entregues

```
3 - Programa console que recebe parâmetros e os devolve em dobro em linguagem diferente de C#/
│
└── cli-parametros-js/
    ├── index.js                    ← Arquivo principal (CLI em JavaScript)
    ├── package.json                ← Configuração do projeto Node.js
    ├── documentation.md            ← Documentação técnica
    ├── gerar-evidencias.js         ← Script de geração do PDF
    ├── node_modules/               ← Dependências instaladas
    └── EVIDENCIAS_EXECUCAO.pdf     ← Documento de evidências (ENTREGÁVEL)
```

---

## Comparação: C# vs JavaScript

| Característica | C# (Pasta 2) | JavaScript (Pasta 3) |
|---|---|---|
| Linguagem | C# (.NET) | JavaScript (Node.js) |
| Arquivo Principal | `CliParametros/Program.cs` | `cli-parametros-js/index.js` |
| Execução | `dotnet run a b c` | `node index.js a b c` |
| Array de Parâmetros | `string[] args` | `process.argv.slice(2)` |
| Obter Quantidade | `args.Length` | `parametros.length` |
| Loop de Repetição | `foreach` | `for...of` |
| Saída no Console | `Console.WriteLine()` | `console.log()` |

---

## Como Executar

### Pré-requisitos
- Node.js instalado (v12+)

### Passos

1. Navegar até a pasta do projeto:
```powershell
cd "D:\Luizx\Program\CEUB\3SEMESTRE\desenvolvimento-de-distemas\3 - Programa console que recebe parâmetros e os devolve em dobro em linguagem diferente de C#\cli-parametros-js"
```

2. Executar o programa com parâmetros:
```powershell
node index.js a b c
```

3. Resultado esperado:
```
Quantidade de parâmetros recebidos: 3
Dobro da quantidade: 6

Parâmetros duplicados:
a
a
b
b
c
c
```

---

## Testes Realizados

### ✅ Teste 1: Sem parâmetros
```
Comando: node index.js
Resultado: Quantidade = 0, Dobro = 0 (PASSOU)
```

### ✅ Teste 2: Com 3 parâmetros simples
```
Comando: node index.js a b c
Resultado: Quantidade = 3, Dobro = 6, parâmetros duplicados (PASSOU)
```

### ✅ Teste 3: Com 5 parâmetros complexos
```
Comando: node index.js "Parametro Um" "Parametro Dois" ... (5 no total)
Resultado: Quantidade = 5, Dobro = 10, parâmetros com espaços tratados (PASSOU)
```

---

## Funcionalidade Implementada

O arquivo `index.js` contém:

1. **Captura de parâmetros**: `process.argv.slice(2)`
2. **Cálculo da quantidade**: `parametros.length`
3. **Cálculo do dobro**: `quantidade * 2`
4. **Saída formatada**: `console.log()`
5. **Loop de duplicação**: `for...of`

---

## Conceitos Aplicados

✓ CLI (Command Line Interface) em JavaScript  
✓ Manipulação de `process.argv` do Node.js  
✓ Arrays e métodos de string  
✓ Template literals (backticks)  
✓ Estruturas de repetição (for...of)  
✓ Entrada/saída no console  

---

## Documento de Evidências

**Arquivo**: `EVIDENCIAS_EXECUCAO.pdf`

Contém:
- Informações do projeto
- Objetivo e funcionalidade
- Código implementado
- Testes realizados com outputs
- Comparação com versão C#
- Conclusão e validação

---

## Conclusão

✅ Projeto implementado com sucesso em JavaScript  
✅ Funcionalidade idêntica à versão em C#  
✅ Todos os testes executados e validados  
✅ Código limpo, documentado e pronto para apresentação  
✅ Evidências de execução geradas em PDF  

---

## Autor
Luiz

**Disciplina**: Desenvolvimento de Sistemas
