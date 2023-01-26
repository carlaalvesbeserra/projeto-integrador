function cadastrar(){
    var campoNome = document.getElementById('nome');
    var campoTel = document.getElementById('tel');
    var campoData = document.getElementById('data');
    var campoPedido = document.getElementById('pedido');
    var campoQuantidade = document.getElementById('quantidade');

    if (campoNome.value , campoTel.value , campoData.value , campoPedido.value , campoQuantidade.value != 0){
        alert('Pedido cadastrado com sucesso!')
    }
}