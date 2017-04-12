# Migration Instructions

To add a new migration:

1. Open the Package Manager Console
2. Add-Migration PersonalApplication -Project Finance.Repository.Ef

To update the database:

1. Update-Database -Project Finance.Repository.Ef

Note: The Finance.WebUi project must be the startup project for this to work
