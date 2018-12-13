### Table of Contents
**[Installation Instructions](#installation-instructions)**<br>


## Installation Instructions


1. Create a new database on SQL Server and call it Upgrades.
2.  Run [Scripts.sql](https://github.com/Justbeingjustin/auto-upgrade/blob/10daaf0afe6e4cde095eda19edc0a42aeb9ab7ae/Upgrades.API/Scripts/DbScript.sql).
3. Edit the the DBConnectionString in [appsettings.json](https://github.com/Justbeingjustin/auto-upgrade/blob/af4483bcb3ff72b599a86a73ec34fd8fb2253df1/Upgrades.API/appsettings.json).
4. Run the Upgrades.API in the project. This should open a browser window. Please take note of the port number in the url.
Adjust the port number for 'authBaseUrl' and 'projectsBaseUrl', seen [here](https://github.com/Justbeingjustin/auto-upgrade/blob/ea14d49db12567edfca236cd470aaf6017bed0c1/WPFSampleApp/App.config).

