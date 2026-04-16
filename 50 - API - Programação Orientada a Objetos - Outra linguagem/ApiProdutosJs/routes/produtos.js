import express from "express";
import { produtoController } from "../controllers/ProdutoController.js";

const router = express.Router();

/**
 * GET /produtos
 * Obtém todos os produtos
 */
router.get("/", (req, res) => {
  try {
    const produtos = produtoController.obterTodos();
    res.json({
      sucesso: true,
      mensagem: "Produtos obtidos com sucesso",
      dados: produtos,
      total: produtos.length
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter produtos",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/:id
 * Obtém um produto específico pelo ID
 */
router.get("/:id", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const produto = produtoController.obterPorId(id);

    if (!produto) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Produto com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Produto obtido com sucesso",
      dados: produto
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter produto",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/:id/descricao
 * Obtém a descrição detalhada de um produto
 */
router.get("/:id/descricao", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const descricao = produtoController.obterDescricao(id);

    if (!descricao) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Produto com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Descrição obtida com sucesso",
      dados: { descricao }
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter descrição",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/tipo/:tipo
 * Filtra produtos por tipo
 */
router.get("/tipo/:tipo", (req, res) => {
  try {
    const tipo = req.params.tipo;
    const produtos = produtoController.filtrarPorTipo(tipo);

    res.json({
      sucesso: true,
      mensagem: `Produtos do tipo '${tipo}' obtidos com sucesso`,
      dados: produtos,
      total: produtos.length
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao filtrar produtos",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/estoque/baixo
 * Obtém produtos com estoque baixo
 */
router.get("/estoque/baixo/:limite", (req, res) => {
  try {
    const limite = parseInt(req.params.limite) || 10;
    const produtos = produtoController.obterEstoqueBaixo(limite);

    res.json({
      sucesso: true,
      mensagem: "Produtos com estoque baixo obtidos com sucesso",
      dados: produtos,
      total: produtos.length,
      limite
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter produtos com estoque baixo",
      erro: erro.message
    });
  }
});

/**
 * POST /produtos
 * Cria um novo produto
 */
router.post("/", (req, res) => {
  try {
    const { tipo, nome, preco, estoque, ...dadosEspecificos } = req.body;

    if (!nome || !preco || estoque === undefined) {
      return res.status(400).json({
        sucesso: false,
        mensagem: "Nome, preço e estoque são obrigatórios"
      });
    }

    const novoProduto = produtoController.criar({
      tipo,
      nome,
      preco,
      estoque,
      ...dadosEspecificos
    });

    if (!novoProduto) {
      return res.status(400).json({
        sucesso: false,
        mensagem: "Erro ao criar produto"
      });
    }

    res.status(201).json({
      sucesso: true,
      mensagem: "Produto criado com sucesso",
      dados: novoProduto
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao criar produto",
      erro: erro.message
    });
  }
});

/**
 * PUT /produtos/:id
 * Atualiza um produto existente
 */
router.put("/:id", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const produtoAtualizado = produtoController.atualizar(id, req.body);

    if (!produtoAtualizado) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Produto com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Produto atualizado com sucesso",
      dados: produtoAtualizado
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao atualizar produto",
      erro: erro.message
    });
  }
});

/**
 * DELETE /produtos/:id
 * Deleta um produto
 */
router.delete("/:id", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const deletado = produtoController.deletar(id);

    if (!deletado) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Produto com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Produto deletado com sucesso"
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao deletar produto",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/info/eletronico/:id
 * Obtém informações específicas de um eletrônico
 */
router.get("/info/eletronico/:id", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const info = produtoController.obterInfoEletronico(id);

    if (!info) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Eletrônico com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Informações de eletrônico obtidas com sucesso",
      dados: info
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter informações de eletrônico",
      erro: erro.message
    });
  }
});

/**
 * GET /produtos/info/roupa/:id
 * Obtém informações específicas de uma roupa
 */
router.get("/info/roupa/:id", (req, res) => {
  try {
    const id = parseInt(req.params.id);
    const info = produtoController.obterInfoRoupa(id);

    if (!info) {
      return res.status(404).json({
        sucesso: false,
        mensagem: `Roupa com ID ${id} não encontrado`
      });
    }

    res.json({
      sucesso: true,
      mensagem: "Informações de roupa obtidas com sucesso",
      dados: info
    });
  } catch (erro) {
    res.status(500).json({
      sucesso: false,
      mensagem: "Erro ao obter informações de roupa",
      erro: erro.message
    });
  }
});

export default router;
