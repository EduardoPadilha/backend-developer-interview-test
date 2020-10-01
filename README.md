## Requisitos de instalação

O único requisito é ter o [Docker](https://www.docker.com/products/docker-desktop) instalado 

## Rodando o projeto

Os comandos a seguir são necessárrios para roda a aplicação, execute-os no teminal.

Clonando o repositório

```sh
$ git clone https://github.com/EduardoPadilha/backend-developer-interview-test.git feriasco
```

Entrar no diretório repositório clonado

```sh
$ cd feriasco/
```

Criando a imagem no docker
```sh
$ docker build -f ./WebApi/Dockerfile --force-rm -t feriasco.reservas:v0.0.2 .
```

Rodando o serviço no docker
```sh
$ docker run -d -p 5000:80 --name micro-reservas feriasco.reservas:v0.0.2
```
Após o término o container estrá no ar na porta 5000.

Acessando o endereço [http://localhost:5000](https://www.google.com) encontrará a página de entrada do Swagger com a exposição da api de maneira crua.