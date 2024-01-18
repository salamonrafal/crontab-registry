# crontab-registry

# Index of content
* [Docker](#docker)
  * [Build image](#build-image)
    * [Build image for Production](#build-image-for-production)
    * [Build image for Development](#build-image-for-development)
  * [Container create](#container-create)
    * [Container create for Production](#container-create-for-production)
    * [Container create for Development](#container-create-for-development)
  * [Container start](#container-start)
  * [Container restart](#container-restart)
  * [Container destroy](#container-destroy)
  * [Container Stop & Destroy](#container-stop--destroy)
  * [Container run bash](#container-run-bash)
  * [Logs for container](#logs-for-container)
  * [Set secret on container](#set-secret-on-container)
  * [Full commands](#full-commands)
    * [Rebuild for development env](#rebuild-for-development-env)


---


# Docker 


## Build image


### Build image for Production
```shell
docker image build -f ./docker/Dockerfile -t crontab-registry:beta-1 .
```

### Build image for Development
```shell
docker image build -f ./docker/Dockerfile.development -t crontab-registry:beta-1 .
```


## Container create

### Container create for Production
```shell
docker container create -it -p 18181:4500 -l com.salamonrafal.repository="crontab-registry" --name "crontab-registry" --restart always crontab-registry:beta-1
```

### Container create for Development
```shell
docker container create -it -p 18181:4500 --env-file=./.env -l com.salamonrafal.repository="crontab-registry" --name "crontab-registry" --restart always crontab-registry:beta-1
```


## Container start
```shell
docker container start crontab-registry
```


## Container restart
```shell
docker container restart crontab-registry
```


## Container stop
```shell
docker container stop crontab-registry
```


## Container destroy
```shell
docker container rm crontab-registry
```

### Container Stop & Destroy
```shell
docker container stop crontab-registry && docker container rm crontab-registry
```


## Container run bash
```shell
docker exec -it crontab-registry bash
```

## Logs for container:
```shell
docker logs crontab-registry
```

## Set secret on container
```shell
( source '.env' && docker exec -it crontab-registry \
  dotnet user-secrets set "CrontabRegistryDatabaseOptions:ConnectionString" "${CRONTAB_REGISTRY_MONGODB_CS_SECRETS}" \
  --project ./src/CrontabRegistry/Application/Application.csproj && docker container restart crontab-registry );
```

## Full commands

### Rebuild for development env
```shell
docker container stop crontab-registry && docker container rm crontab-registry; \
  (source '.env' \
    && docker image build -f ./docker/Dockerfile.development -t crontab-registry:beta-1 . \
    && docker container create -it -p 18181:4500 --env-file=./.env -l com.salamonrafal.repository="crontab-registry" --name "crontab-registry" --restart always crontab-registry:beta-1 \
    && docker container start crontab-registry \
  );
```