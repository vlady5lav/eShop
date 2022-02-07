# eShop

## Update hosts file

### For Windows

#### Enter the following commands in the Command Line (cmd.exe) with Administrative Privileges

#### Backup your original hosts

```
copy /V %WINDIR%\System32\drivers\etc\hosts %WINDIR%\System32\drivers\etc\hosts.alevel.bak
```

#### Modify hosts file

```
echo "0.0.0.0 www.alevelwebsite.com" >> %WINDIR%\System32\drivers\etc\hosts
```

```
echo "127.0.0.1 www.alevelwebsite.com" >> %WINDIR%\System32\drivers\etc\hosts
```

```
echo "192.168.0.1 www.alevelwebsite.com" >> %WINDIR%\System32\drivers\etc\hosts
```

### For Mac or Linux

#### Enter the following commands in the Terminal

#### Backup your original hosts

```
sudo cp /etc/hosts /etc/hosts.alevel.bak
```

#### Modify hosts file

```
sudo -- sh -c -e "echo '0.0.0.0 www.alevelwebsite.com' >> /etc/hosts";
```

```
sudo -- sh -c -e "echo '127.0.0.1 www.alevelwebsite.com' >> /etc/hosts";
```

```
sudo -- sh -c -e "echo '192.168.0.1 www.alevelwebsite.com' >> /etc/hosts";
```

## Swagger Urls

[http://www.alevelwebsite.com:5000/swagger/index.html](http://www.alevelwebsite.com:5000/swagger/index.html)

[http://docker.host.internal:5000/swagger/index.html](http://docker.host.internal:5000/swagger/index.html)

[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

## Build apps and run Docker container

```
docker-compose build --no-cache
```

```
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
