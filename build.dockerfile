FROM microsoft/dotnet:2.1-sdk
WORKDIR /src
COPY . .
RUN dotnet build -c Release
RUN dotnet test "EBikesShop.Ui.Web.Tests.Unit/EBikesShop.Ui.Web.Tests.Unit.csproj" -c Release --logger:trx
RUN dotnet publish "EBikesShop.Server/EBikesShop.Server.csproj" -c Release -o out
EXPOSE 80
ENTRYPOINT ["dotnet", "EBikesShop.Server/out/EBikesShop.Server.dll"]