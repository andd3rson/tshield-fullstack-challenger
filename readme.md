# TSHIELD CHALLENGER - TODO App.

<h6> INTRODUÇÃO </h6>
<p>
  Esta aplicação foi criada com base para demonstrar meu conhecimento em criar aplicação .NET e Angular.
  Importante salientar que por ser uma aplicação pequena e simples, a escrevi da mesmo forma. Evitando assim "Matar uma mosca com um canhão". Apesar de ter sido     disponibilizado 5 dias para realizar o teste, só tive 1 dia da minha agenda para fazer tal. 
</p>
<p>
  Das decisões do Backend: Obtei por não criar mais de uma camada, alem da **.Api. Adicionar mais camadas não fez sentido ao meu ver, visto que era apenas uma entity.
  Além disso, optei por não adicionar libs que fazem mapeamento, pelo mesmo motivo citado previamente.  
</p>
<h6>BIBLIOTECAS</h6> 
<ul>
  <li>EF Core</li>
  <li>Entity Framework Core</li>
  <li>Entity Framework Core Sql Server</li>
  <li>FluentValidation</li>
  <li>FluentValidation.DependencyInjection</li>
</ul>

<p>
  Das decisões do frontend: Optei por utilizar Standalone components. A modularização no angular 19 (versão o qual foi criada o front) não se encaixa muito bem, ao menos para este projeto. Além disso, não adicionei a url para uma variavel de ambiente, deixei fixa no código. Sei que é uma boa prática colocar em variavel de ambiente, contudo como era apenas 1 service. Optei por deixa-lo assim. 
</p>
<h6>BIBLIOTECAS</h6> 
<ul>
  <li>Angular Material</li>
</ul>


<h4>COMO EXECUTAR O PROJETO</h4>
<p>Você precisará ter uma versão do docker instalado em seu ambiente local</p>
<p>Após configurado, abra o terminal no local onde está localizado o arquivo <a href="https://github.com/andd3rson/tshield-fullstack-challenger">docker-compose.yml</a>  e digite o comando no terminal <b>docker compose up -d</b></p>
<p>Será criado os ambientes para executar a aplicação. Será gerado um build do backend, frontend e banco de dados. Além de serem gerados as migrations automaticamente. 
Concluido o build, voce pode abrir o browser na porta 4200, na url <a href="http://localhost:4200/tasks">tasks</a>
</p>

