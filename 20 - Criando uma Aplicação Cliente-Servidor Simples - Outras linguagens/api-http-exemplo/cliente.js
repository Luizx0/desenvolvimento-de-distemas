async function consumirApi() {
    try {
        const response = await fetch("http://localhost:3000/usuarios");

        const dados = await response.json();

        console.log("Lista de usuários:");
        console.log(dados);

    } catch (erro) {
        console.error("Erro ao consumir API:", erro);
    }
}

consumirApi();