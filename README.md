# eShop

## Create our own Docker bridge network
```
docker network create -d bridge --subnet 192.168.0.0/24 --gateway 192.168.0.1 dockernet
```

## Update hosts file
```
echo 0.0.0.0 www.alevelwebsite.com >> %WINDIR%\System32\drivers\etc\hosts
echo 127.0.0.1 www.alevelwebsite.com >> %WINDIR%\System32\drivers\etc\hosts
echo 192.168.0.1 www.alevelwebsite.com >> %WINDIR%\System32\drivers\etc\hosts
```

## Build apps and run Docker container
```
docker-compose build --no-cache
docker-compose up
```

## Migration tips

### Add-Migration
```
dotnet ef --startup-project Catalog/Catalog.Host migrations add InitialMigration --project Catalog/Catalog.Host
```

### Update-Migration
```
dotnet ef --startup-project Catalog/Catalog.Host database update InitialMigration --project Catalog/Catalog.Host
```

### Remove-Migration
```
dotnet ef --startup-project Catalog/Catalog.Host migrations remove --project Catalog/Catalog.Host -f
```
