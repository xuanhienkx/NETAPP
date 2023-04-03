NOTE: before using the below command,
The CS.CoreAPI project must be selected as START UP project

1. For create imgration data
add-migration InitialCreate -context CSoftDataContext

2. Remove the current imgration data if you want to remove completely
Remove-Migration -context CSoftDataContext

3. Update the current database to match with current POCO models
Update-Database -context CSoftDataContext
