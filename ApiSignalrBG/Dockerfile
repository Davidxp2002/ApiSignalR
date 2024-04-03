#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN apt-get update \
    && apt-get install unzip \
    && curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg

WORKDIR /app
COPY . .

WORKDIR /app/ApiSignalrBG

# Expose the necessary port
EXPOSE 80

# Start the application with live compilation
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]
