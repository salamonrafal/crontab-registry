# crontab-registry

# Docker 


## Build image


### Default
```shell
docker image build -f ./docker/Dockerfile -t crontab-registry:beta-1 .
```

### For development
```shell
docker image build -f ./docker/Dockerfile.development -t crontab-registry:beta-1 .
```


## Container create

### For Production
```shell
docker container create -it -p 18181:4500 -l com.salamonrafal.repository="crontab-registry" --name "crontab-registry" --restart always crontab-registry:beta-1
```

### For Development
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

### Stop & Destroy
```shell
docker container stop crontab-registry && docker container rm crontab-registry
```


## Container run bash
```shell
docker exec -it crontab-registry bash
```

## Get docker container logs:
```shell
docker logs crontab-registry
```

## Setup Secrets for container
```shell
(source '.env' && docker exec -it crontab-registry \
  dotnet user-secrets set "CrontabRegistryDatabaseOptions:ConnectionString" "${CRONTAB_REGISTRY_MONGODB_CS_SECRETS}" \
  --project ./src/CrontabRegistry/Application/Application.csproj; echo "SECRETS: ${CRONTAB_REGISTRY_MONGODB_CS_SECRETS}" && docker container restart crontab-registry);
```

## Full commands

### Rebuld for Development env
```shell
docker container stop crontab-registry && docker container rm crontab-registry; \
  (source '.env' \
    && docker image build -f ./docker/Dockerfile.development -t crontab-registry:beta-1 . \
    && docker container create -it -p 18181:4500 --env-file=./.env -l com.salamonrafal.repository="crontab-registry" --name "crontab-registry" --restart always crontab-registry:beta-1 \
    && docker container start crontab-registry \
  );
```