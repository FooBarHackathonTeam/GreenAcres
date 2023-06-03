mkdir conf.d
dotnet dev-certs https --clean
dotnet dev-certs https -ep ./conf.d/https/dev_cert.pfx -p LubiePlacki1234
dotnet dev-certs https --trust
