var isTruthy = function(isTrue){
    if(isTrue == true){
        return true
    }
    else{
        return false
    }
}

console.log(isTruthy(false));

var carro = new Object()

carro.marca = "Chevrolet";
carro.modelo = "Vectra"
carro.placa = "9999999";
carro.ano = 2020;
carro.cor = "Prata";
carro.quantasPortas = 4;
carro.assentos = 5;
carro.quantidadePessoas = 0;

carro.mudarCor = function(novaCor){
    carro.cor = novaCor
}

carro.obterCor = function(){
    return carro.cor
}

carro.obterModelo = function(){
    return carro.modelo
}

carro.obterMarca = function(){
    return carro.marca
}

carro.obterMarcaModelo = function(){
    return `Esse carro é um ${carro.marca} ${carro.modelo}`
}

carro.adicionarPessoas = function(pessoas){
    let assentoRestante = carro.assentos - carro.quantidadePessoas
    let singPerso = "pessoas"

    if (assentoRestante == 1 ) {
        singPerso = "pessoas"
    }
    if (assentoRestante < pessoas) {
        return `Só cabem mais ${assentoRestante} ${singPerso}!`
    }
    if (carro.quantidadePessoas == 5) {
        return "O carro já está lotado!"
    }
    carro.quantidadePessoas = carro.quantidadePessoas + pessoas
    return `Já temos ${carro.quantidadePessoas} pessoas no carro!`
}

carro.removerPessoas = function(pessoas){
    if (pessoas > carro.quantidadePessoas) {
        return `Temos ${carro.quantidadePessoas} pessoas no carro!`
    }
    carro.quantidadePessoas = carro.quantidadePessoas - pessoas
    return `Temos ${carro.quantidadePessoas} pessoas no carro!`
}

console.log(carro.obterCor())
console.log(carro.mudarCor("Vermelho"))
console.log(carro.obterCor())
console.log(carro.mudarCor("Verde Musgo"))
console.log(carro.obterCor())
console.log(carro.obterMarcaModelo())

console.log(carro.adicionarPessoas(2))
console.log(carro.adicionarPessoas(4))
console.log(carro.adicionarPessoas(3))

console.log(carro.removerPessoas(4))

console.log(carro.adicionarPessoas(10))

console.log(`Há ${carro.quantidadePessoas} pessoas no carro!`)