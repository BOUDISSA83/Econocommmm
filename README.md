**Server Build status**

[![Build status](https://dev.azure.com/SatebaDevProject/Green%20Tunnel/_apis/build/status/Green%20Tunnel%20-%20Server%20CI%20-%20QA)](https://dev.azure.com/SatebaDevProject/Green%20Tunnel/_build/latest?definitionId=3)

**Client Build status**

[![Build status](https://dev.azure.com/SatebaDevProject/Green%20Tunnel/_apis/build/status/Green%20Tunnel%20-%20Client%20CI%20-%20QA)](https://dev.azure.com/SatebaDevProject/Green%20Tunnel/_build/latest?definitionId=4)

**How to build the solution**

**Server**

Execute the following commands to build the backend. Make to sure to set GreenTunnel.Api as a startup project.
> dotnet tools restore

> dotnet run

**Client**

Make sure you have latest version of node installed with npm.
Execute the following commands :
> npm i -g @angular/cli@latest

> ng serve -o

or

> ng watch