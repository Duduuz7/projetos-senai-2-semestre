let eduardo = {
    nome: "Eduardo",
    idade: 18,
    altura: 1.67
}; // objeto literal

let carlos = new Object();
carlos.nome = "Carlos";
carlos.idade = 36

// console.log(eduardo);
// console.log(carlos);
// const fruta = {};

const sacola = new Object();


sacola.itens = []; // lista/array

sacola.guardarItem = function (item) {
    this.itens.push(item);
}

sacola.guardarItem("banana");

console.log(sacola.itens);