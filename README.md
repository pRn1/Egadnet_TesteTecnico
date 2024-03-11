<h1 align="center"> Desafio Técnico Egadnet </h1>

- O repositório a seguir apresenta um MVP para o teste técnico da Egadnet que consiste em fazer requisições a API Viacep;
- A solução foi implementada utilizando .NET Core 6.0, e conta com autenticação JWTBearer para fazer as requisições no endpoint de consumo da API Viacep;
- Para execução da aplicação, utilizaremos o CLI de .net e garantimos a instalação do SDK e do Runtime dele através do link https://dotnet.microsoft.com/pt-br/download/dotnet/6.0;
- A solução conta com autenticador com tempo de expiração e cache, ambos duram 5 minutos, caso a aplicação seja reiniciada o token ainda funciona, porém o cache para os dados vindos da API Viacep são cacheados por execução.

# Execução via Swagger

- A execução pode ocorrer abrindo o projeto no Visual Studio, e executando com o comando F5 para assim abrir a aplicação Swagger no navegador, através dessa execução, acessamos a tela abaixo:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/7c2b6280-bf9f-4978-96f0-6fceaaf9679e)
- Na tela acima precisamos executar 2 passos para acessarmos o endpoint necessário, primeiro deles é receber um token válido para autenticação da API, fazemos isso com o body abaixo no endpoint "/authenticate":
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/d5de39aa-4078-4fa2-b004-de4f7d04c519)
- Com a requisição feita, recebemos o token logo abaixo e precisamos adicioná-lo ao autenticador do Swagger:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/94552e45-3f60-4092-a585-a2235683b61c)
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/7ecb9ab7-a9c6-469d-972c-5b6471614126)
- Após autenticada a api, a requisição no endpoint de pesquisa do Viacep está disponível e podemos selecionar o CEP escolhido, importante se atentar ao fato que somente 8 dígitos numéricos são aceitos:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/b6b3223a-122b-40c8-b1b4-032aef765183)

# Execução via Postman

- Por outro lado, podemos executar a aplicação através do CMD e consultar os endpoints via Postman, entretanto as requisições serão apontadas para o endereço localhost, há duas portas separadas para o projeto:
  ```

  https://localhost:7175;http://localhost:5175
  
  ```
- Por fim, executamos a aplicação abrindo o CMD na pasta raiz do projeto, após isso executamos os comandos abaixo em ordem:
   ```
  cd ./Api
  ```
   ```
  dotnet restore
  ```
  ```
  dotnet build
  ```
  ```
  dotnet run
  ```
- Após a execução dos comandos, encontraremos algo assim no CMD e com isso podemos fazer as requisições no Postman:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/9c589aa9-aa9c-48b5-ae39-f769cf4ff03a)
- No Postman, precisamos fazer a mesma autenticação feita via Swagger, começamos utilizando o endpoint POST : `` https://localhost:7175/authenticate ``, com ele receberemos o token e poderemos aplicar no endpoint da requisição do Viacep:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/50147530-737a-478a-849a-c281819f48e6)
- Com o token em mãos podemos autenticador a rota GET : `` https://localhost:7175/Viacep/{cep} `` e assim obtermos nossos retornos:
  ![image](https://github.com/pRn1/Egadnet_TesteTecnico/assets/99836240/cbd2ec1c-a3db-4a09-8f10-eb663072d2ae)

- Assim finalizamos o desafio técnico proposto com um MVP funcional. Obrigado







