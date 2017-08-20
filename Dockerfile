FROM microsoft/aspnetcore-build:2
WORKDIR /src
ARG source=.
COPY $source .
RUN dotnet publish -c Release -o /app
ENV ASPNETCORE_URLS "http://*:5000"
EXPOSE 5000
WORKDIR /app
ENTRYPOINT ["dotnet", "films-app.dll"]