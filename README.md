# (.NET) Videos Review API

This is a simple API that allows you to create, read, update and delete (CRUD) videos reviews.

## ⚠️ Requirements

- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

## 🧰 Install

### Docker

```
docker-compose -f ./docker-compose.yml -p dotnet_videos up -d
```

### dotnet-ef

```
dotnet tool install --global dotnet-ef
```

### Update Database

```
dotnet ef database update
```

## 🛠 Developer Server

```
dotnet watch run
```

## 🛠 Run

```
dotnet run
```
