#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["CodeCaseAzerionDynamicConfigStructure.UI/CodeCaseAzerionDynamicConfigStructure.UI.csproj", "CodeCaseAzerionDynamicConfigStructure.UI/"]
COPY ["../../CodeCaseAzerionDynamicConfigStructure/CodeCaseAzerionDynamicConfigStructure.DAL/CodeCaseAzerionDynamicConfigStructure.DAL.csproj", "../../CodeCaseAzerionDynamicConfigStructure/CodeCaseAzerionDynamicConfigStructure.DAL/"]
COPY ["../../CodeCaseAzerionDynamicConfigStructure/CodeCaseAzerionDynamicConfigStructure.Model/CodeCaseAzerionDynamicConfigStructure.Model.csproj", "../../CodeCaseAzerionDynamicConfigStructure/CodeCaseAzerionDynamicConfigStructure.Model/"]
RUN dotnet restore "CodeCaseAzerionDynamicConfigStructure.UI/CodeCaseAzerionDynamicConfigStructure.UI.csproj"
COPY . .
WORKDIR "/src/CodeCaseAzerionDynamicConfigStructure.UI"
RUN dotnet build "CodeCaseAzerionDynamicConfigStructure.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeCaseAzerionDynamicConfigStructure.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeCaseAzerionDynamicConfigStructure.UI.dll"]

dotnet publish CodeCaseAzerionDynamicConfigStructure.sln -c Release -o out