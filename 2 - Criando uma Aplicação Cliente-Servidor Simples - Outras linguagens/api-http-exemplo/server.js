const express = require("express");

const app = express();
const PORT = 3000;

app.use(express.json());

// Dados fictícios
const usuarios = [
    { id: 1, nome: "Ana", idade: 22 },
    { id: 2, nome: "Carlos", idade: 30 },
    { id: 3, nome: "Maria", idade: 25 }
];

// Endpoint GET
app.get("/usuarios", (req, res) => {
    res.json(usuarios);
});

// Endpoint GET por id
app.get("/usuarios/:id", (req, res) => {
    const id = parseInt(req.params.id);
    const usuario = usuarios.find(u => u.id === id);

    if (!usuario) {
        return res.status(404).json({ mensagem: "Usuário não encontrado" });
    }

    res.json(usuario);
});

// Endpoint POST
app.post("/usuarios", (req, res) => {
    const { nome, idade } = req.body;

    const novoUsuario = {
        id: usuarios.length + 1,
        nome,
        idade
    };

    usuarios.push(novoUsuario);

    res.status(201).json(novoUsuario);
});

app.listen(PORT, () => {
    console.log(`API rodando em http://localhost:${PORT}`);
});