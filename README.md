Aby połączyć się z bazą danych w Postgresie trzeba 
1. Wejść w PgAdmin4 i stworzyć bazę danych EmployeeManager.
2. W bazie EmployeeManager otworzyć termianl sql, przekopiować i wykonać skrypt InitializeTables który znajduje się w folderze Scripts w repozytorium i tworzy tabele potrzebne.
3. Podmienić w Connection Stringu na własny username/hasło/hosta (appsettings.json) w projekcie pliku i projekcie z testami jednostkowymi i integracyjnymi.
    "DefaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=EmployeeManager;"

Na gałęzi master znajduję się tylko kod, a na gałęzi Docker również pliki powstałe podczas Docker Compose.
