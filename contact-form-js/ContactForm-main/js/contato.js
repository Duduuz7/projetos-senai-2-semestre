const urlLocal = "http://localhost:3000/contatos";

async function cadastrarContato(e) {
    e.preventDefault();

    const nome = document.getElementById("nome").value;
    const sobrenome = document.getElementById("sobrenome").value;
    const email = document.getElementById("email").value;
    const pais = document.getElementById("pais").value;
    const ddd = document.getElementById("ddd").value;
    const telefone = document.getElementById("telefone").value;
    const cep = document.getElementById("cep").value;
    const rua = document.getElementById("rua").value;
    const numero = document.getElementById("numero").value;
    const complemento = document.getElementById("complemento").value;
    const bairro = document.getElementById("bairro").value;
    const cidade = document.getElementById("cidade").value;
    const UF = document.getElementById("UF").value;
    const anotacoes = document.getElementById("anotacoes").value;

    const objDados = { nome, sobrenome, email, pais, ddd, telefone, cep, rua, numero, complemento, bairro, cidade, UF, anotacoes }

    try {
        const promise = await fetch(urlLocal, {
            body: JSON.stringify(objDados),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        const retorno = promise.json();

        console.log(retorno);
    } catch (error) {
        alert("Deu ruim" + error)
    }
}

async function chamarApi() {

    const cep = document.getElementById('cep').value;

    const url = `https://viacep.com.br/ws/${cep}/json/`

    try {

        const promise = await fetch(url)
        const endereco = await promise.json();

        //exibir dos dados no formulário
        exibirEndereco(endereco)


    } catch (error) {
        //rejeitada
        console.log("Deu ruim na API");

        alert("CEP inválido !!!")

        //informa o usuário
        limparEndereco()
    }

    function exibirEndereco(endereco) {
        document.getElementById("rua").value = endereco.logradouro
        document.getElementById("bairro").value = endereco.bairro
        document.getElementById("cidade").value = endereco.localidade
        document.getElementById("UF").value = endereco.uf
    }

    function limparEndereco() {
        document.getElementById("rua").value = ''
        document.getElementById("bairro").value = ''
        document.getElementById("cidade").value = ''
        document.getElementById("UF").value = ''
    }
}

function limparTudo() {
    document.getElementById("nome").value = ''
    document.getElementById("sobrenome").value = ''
    document.getElementById("email").value = ''
    document.getElementById("pais").value = ''
    document.getElementById("ddd").value = ''
    document.getElementById("telefone").value = ''
    document.getElementById("cep").value = ''
    document.getElementById("rua").value = ''
    document.getElementById("numero").value = ''
    document.getElementById("complemento").value = ''
    document.getElementById("bairro").value = ''
    document.getElementById("cidade").value = ''
    document.getElementById("UF").value = ''
    document.getElementById("anotacoes").value = ''
}