#!/usr/bin/env node

// Obtém os parâmetros passados pela linha de comando
// process.argv começa com ["node", "arquivo.js", param1, param2, ...]
// Removemos os 2 primeiros elementos para pegar apenas os parâmetros do usuário
const parametros = process.argv.slice(2);

// Calcula a quantidade de parâmetros recebidos
const quantidade = parametros.length;

// Calcula o dobro da quantidade
const dobro = quantidade * 2;

// Imprime o resultado
console.log(`Quantidade de parâmetros recebidos: ${quantidade}`);
console.log(`Dobro da quantidade: ${dobro}`);
console.log();

// Imprime cada parâmetro duas vezes
console.log("Parâmetros duplicados:");

for (const parametro of parametros) {
    console.log(parametro);
    console.log(parametro);
}
