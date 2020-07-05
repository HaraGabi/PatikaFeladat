# Garage

## A solution futtatásának alapfeltételei

1. Visual Studio 2019
2. SQL Server 2017+ (installed as DEFAULT instance to avoid config changes)
3. .NET Core 3.1 LTS

## Adatbázis telepítése

### EF Core tools telepítése, ha szükséges:
dotnet tool install -g dotnet-ef

### Adatbázis telepítése

Minden esetben a következő connectionString-re történik:

"Server=.;Database=Garage;Integrated Security=True"

dotnet ef database update --project Data

## Egyéb magyarázatok

- A kiírásnak megfelelő Adatbázis magyarázat a 
Patika_felvételi_plus_DBMap.docx második oldalán található.
A rajz maga draw.io formátumban a Patika_Felvételi_Diagram.drawio
fájlban.
- Számos egyszerűsítés van a projektben, az architektúra 
kidolgozásra helyeztem a hangsúlyt.
- Resharper-t használtam a projekthez, így annak megfelelő, a
fejlesztést támogató annotációk is szerepelnek benne.