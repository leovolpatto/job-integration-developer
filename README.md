# Intelipost: Teste Prático Desenvolvedor de Integrações

## Utilização
### Como rodar o serviço localmente
Para rodar o projeto de maneira padrão, basta utilizar o [Docker](https://www.docker.com/community-edition#/download) com o seguinte comando:
```
docker run -p5000:5000 leovolpatto/integration:latest
```
- O serviço irá rodar em http://localhost:5000/api/tracking

### Como rodar o serviço localmente e sem o Docker
Para rodar o serviço é preciso:
- Instalar o [.NET](https://www.microsoft.com/net/learn/get-started/linux/rhel)
- Após instalar e configurar o .NET, em sua pasta ($HOME) ou de sua preferência, você precisa clonar o projeto do Github:
 ```git clone https://github.com/leovolpatto/job-integration-developer.git```
 - Na pasta do projeto (jog-integration-developer), devemos agora carregar as dependencias do Nuget necessárias:
 ```dotnet restore```
 - Compilar o serviço:
 ```dotnet build```
 - Executar o serviço:
 ```dotnet run --project IntelipostMiddleware/IntelipostMiddleware.Service.csproj```
 - O serviço irá rodar em http://localhost:5000/api/tracking
 
 ### Como utilizar o serviço hospedado na Amazon AWS
 - O serviço roda em http://18.205.15.245/api/tracking

### Observaçoes
- A unica operação disponível nessa API é um POST do rastreamento em /api/tracking
- As informações devem ser enviadas em JSON
- Modelo do rastreamento a ser enviado deve conter estas informações:
```
{
  	"order_id":123,
	"event":{
		"status_id":1
		"date":"2018-02-02T10:45:32"
	},
	"package":{
		"package_id":1,
		"package_invoice":{
			"number":"9871236",
			"key":"01234567890123456789012345678901234567891234"
			"date":"2018-02-01T10:45:32" 
		}
	}
}
```
- Qualquer outra operação ou recurso que não seja POST em api/tracking retornará NotFound

## Decisões tomadas
### Tecnologia
#### Plataforma
Decidi usar .NET Core por ser totalmente open source e multiplataforma. Foi questão de curiosidade de fazer uma api em C# depois de tanto tempo em PHP.

#### Testes
Utilizei xUnit ao invés de outras opções por já ter uma breve experiência. Eles podem ser rodados ou debugados localmente no Visual Studio ou Visual Studio Code

#### CI/CD
- Achei que ficaria fácil fazer deploy em vários containers Docker e também para testes locais sem precisar instalar muita coisa então a cada push na master e release-v1 no repositório no Github um Automated Build é disparado no [DockerHub](https://hub.docker.com/r/leovolpatto/integration/). Assim fica fácil para usar o serviço em qualquer lugar. Não tive tempo para terminar, mas tinha começado a configurar um grupo de autoscaling no AWS com load balancer.
- Configurei na AWS um ambiente com o Jenkins. Cada push na master do repositorio dispara um job no Jenkins que compila o código e inicia um container Docker com o serviço. Minha intenção original era ter um servidor só para o Jenkins, e fazer os outros do serviço escalarem, mas isso iria me custar um tempo ( $$$$ )
- A imagem do Docker pode ser gerada, na pasta raiz do projeto com ```docker build --rm -f Dockerfile -t leovolpatto/middleware-intelipost:latest .```

### Resolução do desafio
- Apostei num middleware acoplado ao sistema de rastreamento. Esse sistema recebe as informações de rastreio por POST em /api/tracking e envia para um sistema externo
- Criei uma estrutura que possa facilitar o desenvolvimento deste aviso de rastreio a outros sistemas. Basicamente é só extender as classes e interfaces em Integrations.External
- A ideia do middleware foi porque como essas integrações podem ser muito especificas ou plugins, elas não precisam ficar dentro do sistema de rastremento. Mas sim, usado como um middleware por ele.
      
