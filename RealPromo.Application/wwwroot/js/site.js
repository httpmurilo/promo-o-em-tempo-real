const connection = new signalR.HubConnectionBuilder().withUrl("/PromoHub").build();

connection.start().then(function(){
    console.info("Connected");
}).catch(function(err){
    console.error(err.toString());
});

connection.on("CadastradoSucesso", function(){
    const mensagem = document.getElementById("mensagem");
    mensagem.innerHTML = "Cadastro de promoção realizado com sucesso";
});

connection.on("ReceberPromocao", function(promocao){
    const containerLogin = document.getElementById("container-login");
    
    const containerPromo = document.createElement("div");
    containerPromo.setAttribute("class","container-promo");

    const containerChamada = document.createElement("div");
    containerPromo.setAttribute("class","container-chamada");
    
    const h1Titulo = document.createElement("h1");
    h1Titulo.innerText = promocao.empresa;

    const p1 = document.createElement("p");
    p1.innerText = promocao.chamada;

    const p2 = document.createElement("p");
    p2.innerText = promocao.regras;

    const containerBotao = document.createElement("div");
    containerBotao.setAttribute("class", "container-botao");

    const link = document.createElement("a");
    link.setAttribute("href",promocao.enderecoUrl);
    link.setAttribute("target","_blank");
    link.innerText = "Pegar";

    containerChamada.appendChild(h1Titulo);
    containerChamada.appendChild(p1);
    containerChamada.appendChild(p2);

    containerBotao.appendChild(link);

    containerPromo.appendChild(containerChamada);
    containerPromo.appendChild(containerBotao);
    containerLogin.appendChild(containerPromo);
    console.info(promocao);
});
const btnCadastrar = document.getElementById("btnCadastrar");
if(btnCadastrar != null){
    btnCadastrar.addEventListener("click",function(){
    const empresa = document.getElementById("empresa").value;
    const chamada = document.getElementById("chamada").value;
    const regras = document.getElementById("regras").value;
    const endereco = document.getElementById("endereco").value;

    const promocao = { empresa: empresa, chamada: chamada, regras : regras, endereco : endereco};
    
    connection.invoke("CadastrarPromocao", promocao).then(function(){
        console.info("Cadastrado com sucesso");
    }).catch(function(err){
        console.error(err.toString());
    });
    });
}