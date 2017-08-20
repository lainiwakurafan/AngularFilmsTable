# Films app

Angular 4 single page app with ASP.NET Core 2.0 backend for managing films to be watched in the future.

## Live demo

The latest version of the app is available on [films-app.now.sh](https://films-app.now.sh)

## Quickstart

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* [Node v6.11.1 (LTS)](https://nodejs.org/en/blog/release/v6.11.1/)
* [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core)

Clone this repository and switch to its folder
```
git clone https://github.com/lainiwakurafan/films-app.git
cd films-app
```

### Building and running the app

```shell
npm install && dotnet run
```

This will install node packages, restore .net project dependencies and launch the app the on <http://localhost:5000>

## Deployment

Currently [now.sh](https://now.sh) is used for deployment as a docker container.

### Dockerizing

[Dockerfile](https://github.com/lainiwakurafan/films-app/blob/master/Dockerfile) is available to build the image and run a container.

Use

```shell
docker build . -t films-app
```

to build the image and

```shell
docker run --rm -it -p 5000:5000 films-app
```

to run a container in a local environment.

### Store in the cloud

To deploy on now.sh simply run

```shell
now --docker
```

It will upload the sources and the docker file to the cloud, build the image, store and run the container in there. To do this you don't even need Docker installed.

## Known issues and limitations

* Webpack bundles haven't been optimized for web performance yet
* Currently, optimistic concurrency is supported only for delete requests, put and patch are to be done
* No tests yet
* Simple design

## Built With

* [Angular 4](https://angular.io)
* [ASP.NET Core 2.0](https://github.com/aspnet/Home)
* [Entity Framework Core 2.0](https://github.com/aspnet/EntityFramework)
* [Webpack](https://webpack.js.org/)
* [Docker](https://www.docker.com)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details