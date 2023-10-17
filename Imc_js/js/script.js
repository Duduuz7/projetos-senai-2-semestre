//lista global.
const listaPessoas = [];


function calcular(e) { //recebe evendo(e) e usa prevent para interromper o submit do formulario
    e.preventDefault();
    let nome = document.getElementById("nome").value.trim(); //limpa a string
    let altura = parseFloat(document.getElementById("altura").value); //NaN
    let peso = parseFloat(document.getElementById("peso").value);

    // verifica se  há algum campo sem preencher
    if (isNaN(altura) || isNaN(peso) || nome.lenght < 2) {
        alert('É necessário preencher todos os campos');
        return; //retorna para nao fazer o debaixo caso nn passe no if
    }

    const imc = calcularImc(peso, altura)
    const situacao = geraSituacao(imc);
    let now = new Date();

    //object short sintaxe, se a propriedade tem um nome e o valor tem o mesmo nome, posso deixar so 1 nome 
    //ex: (nome(propriedade): nome(valor) ||| nome).
    const pessoa = { //objeto literal
        nome, //nome: nome  (propriedade: valor)
        altura,
        peso,
        imc,
        situacao,
        dataCadastro: `${now.getDate()}/${now.getMonth() + 1}/${now.getFullYear()} ${now.getHours()}:${now.getMinutes()}`
    };


    listaPessoas.push(pessoa)

    //chamada funcao exibirDados que lista os dados
    exibirDados();

    // console.log(pessoa)

}//fim função calcular

//return peso / (altura **2);
// return peso / (altura * altura);
function calcularImc(peso, altura) {
    return peso / Math.pow(altura, 2);
}//fim função calcularImc

function geraSituacao(imc) {
    if (imc <= 18.5) {
        // document.getElementById('Situacao').innerText = "Magreza severa"
        return "Magreza Severa"
    }

    else if (imc > 18.5 && imc <= 24.99) {
        return "Peso Normal"
    }

    else if (imc > 24.99 && imc <= 29.99) {
        return "Acima do Peso"
    }

    else if (imc > 29.99 && imc <= 34.99) {
        return "Obesidade I"
    }

    else if (imc > 34.99 && imc <= 39.99) {
        return "Obesidade II"
    }

    else {
        return "Cuidado !!!"
    }
}//fim função geraSituacao


function exibirDados() {
    // <tr>
    //         <td>Eduardo</td>
    //         <td>1.78</td>
    //         <td>67</td>
    //         <td>21.1</td>
    //         <td>Normal</td>
    //         <td>19/06/2023 21:27</td>
    // </tr>

    let linhas = "";

    listaPessoas.forEach(function (p) {

        linhas += `
        <tr>
            <td data-cell="nome" id="nome">${p.nome}</td>
            <td data-cell="altura" id="altura">${p.altura}</td>
            <td data-cell="peso" id="peso">${p.peso}</td>
            <td data-cell="imc" id="imc">${p.imc}</td>
            <td data-cell="situacao" id="situacao">${p.situacao}</td>
            <td data-cell="data de cadastro">${p.dataCadastro}</td>
        </tr>
        `;
    });

    document.getElementById("corpo-tabela").innerHTML = linhas;

}