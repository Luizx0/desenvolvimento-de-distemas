import express from "express";
import produtosRouter from "./routes/produtos.js";

/**
 * Servidor Express da API de Produtos
 * Implementação com POO, Herança e Polimorfismo em JavaScript
 */

const app = express();
const porta = 3000;

// Middleware para parsear JSON
app.use(express.json());

// Middleware para logar requisições
app.use((req, res, next) => {
  console.log(`[${new Date().toISOString()}] ${req.method} ${req.path}`);
  next();
});

/**
 * Rota raiz - Informações sobre a API
 */
app.get("/", (req, res) => {
  res.json({
    nome: "API de Produtos com POO em JavaScript",
    versao: "1.0.0",
    descricao: "API REST demonstrando Programação Orientada a Objetos com Classes, Herança e Polimorfismo",
    autor: "Estudante",
    endpoints: {
      todos: "GET /api/produtos",
      porId: "GET /api/produtos/:id",
      descricao: "GET /api/produtos/:id/descricao",
      porTipo: "GET /api/produtos/tipo/:tipo",
      estoqueBaixo: "GET /api/produtos/estoque/baixo/:limite",
      infoEletronico: "GET /api/produtos/info/eletronico/:id",
      infoRoupa: "GET /api/produtos/info/roupa/:id",
      criar: "POST /api/produtos",
      atualizar: "PUT /api/produtos/:id",
      deletar: "DELETE /api/produtos/:id"
    }
  });
});

/**
 * Rota de saúde da API
 */
app.get("/health", (req, res) => {
  res.json({
    status: "OK",
    timestamp: new Date().toISOString(),
    uptime: process.uptime()
  });
});

/**
 * Rotas da API de Produtos
 */
app.use("/api/produtos", produtosRouter);

/**
 * Rota 404 - Não encontrado
 */
app.use((req, res) => {
  res.status(404).json({
    sucesso: false,
    mensagem: "Rota não encontrada",
    caminho: req.path
  });
});

/**
 * Manipulador de erros global
 */
app.use((err, req, res, next) => {
  console.error("Erro:", err);
  res.status(500).json({
    sucesso: false,
    mensagem: "Erro interno do servidor",
    erro: err.message
  });
});

/**
 * Inicia o servidor
 */
app.listen(porta, () => {
  console.log("╔═══════════════════════════════════════════════════════════╗");
  console.log("║                                                           ║");
  console.log("║   🚀 API de Produtos com POO em JavaScript               ║");
  console.log("║                                                           ║");
  console.log(`║   Servidor rodando em http://localhost:${porta}                    ║`);
  console.log("║                                                           ║");
  console.log("║   Documentação: http://localhost:3000                    ║");
  console.log("║   Health Check: http://localhost:3000/health             ║");
  console.log("║                                                           ║");
  console.log("╚═══════════════════════════════════════════════════════════╝");
});

export default app;
