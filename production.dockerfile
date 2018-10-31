FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY /out .
EXPOSE 80
ENTRYPOINT ["dotnet", "EBikesShop.Server.dll"]