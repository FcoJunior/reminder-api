# Rminder

## Run application
Run on terminal
```
$ cd source/Presentation/Reminder.Presentation.Api
$ dotnet run
```

## Run database on docker
```
$ docker pull mongo
$ docker run  --name mongo_server \
-e MONGO_INITDB_ROOT_USERNAME=admin \
-e MONGO_INITDB_ROOT_PASSWORD=root \
-e MONGO_INITDB_DATABASE=reminder \
-e MONGO_USERNAME=user \
-e MONGO_PASSWORD=root \
-p 27017:27017 \
mongo
```