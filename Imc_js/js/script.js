function calcular(e) {
    e.preventDefault();
    let nome = document.getElementById("nome").value.trim(); //limpa a string
    let altura = parseFloat(document.getElementById("altura").value); //NaN
    let peso = parseFloat(document.getElementById("peso").value);

    // verifica se  há algum campo sem preencher
    if (isNaN(altura) || isNaN(peso) || nome.lenght < 2) {
        alert('É necessário preencher todos os campos');
        return;
    }

    const imc = calcularImc(peso, altura)
    const situacao = geraSituacao(imc);

    // console.log(nome);
    // console.log(altura);
    // console.log(peso);
    // console.log(imc);
    // console.log(situacao);

    const pessoa = { //objeto literal
        nome : nome,
        altura : altura,
        peso : peso,
        imc : imc,
        situacao : situacao
    }
    console.log(pessoa)


//return peso / (altura **2);
// return peso / (altura * altura);
    function calcularImc(peso, altura) {
        return peso / Math.pow(altura, 2);
    }

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
        
        else{
            return "Cuidado !!!"
        }
    }
} 