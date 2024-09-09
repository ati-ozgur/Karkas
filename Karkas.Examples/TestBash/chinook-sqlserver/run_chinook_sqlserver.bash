#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.

set -euo pipefail

CONTAINER_NAME="chinook-sqlserver-container1"
IMAGE_NAME="chinook-sqlserver-image1"

#!/bin/bash

WORKING_DIR=$PWD
echo $PWD


cd ./Karkas.Examples/TestBash/chinook-sqlserver

docker build -t $IMAGE_NAME .

echo "docker build finished"

if docker ps -a --format '{{.Names}}' | grep -q "^$CONTAINER_NAME\$"; then
     echo "Container $CONTAINER_NAME is running"
     echo "Stopping Container $CONTAINER_NAME "
  	docker stop "$CONTAINER_NAME" &>/dev/null && echo "Stopped container $CONTAINER_NAME"
  	docker rm "$CONTAINER_NAME"
 else
   echo "Container $CONTAINER_NAME is not running"
 fi

echo "starting docker container $CONTAINER_NAME with image $IMAGE_NAME"

docker run --detach -p 1433:1433 --name $CONTAINER_NAME  --hostname $CONTAINER_NAME  $IMAGE_NAME

echo "go to ${WORKING_DIR}"
cd $WORKING_DIR

CONTAINER_ID=$(docker inspect --format="{{.Id}}" "$CONTAINER_NAME")
echo "CONTAINER_ID ${CONTAINER_ID}"



#rm -rf Karkas.Examples/GeneratedProjects/ChinookSqlServer

# rm -rf Karkas.Examples/GeneratedProjects/ChinookSqlite
# dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname ChinookSqlite
# cd Karkas.Examples/GeneratedProjects/ChinookSqlite
# dotnet new console
# dotnet add package Microsoft.Data.Sqlite
# dotnet add reference "../../../Karkas.Core/Karkas.Core.DataUtil/Karkas.Core.DataUtil.csproj"
# dotnet add reference "../../../Karkas.Core/Karkas.Core.Data.Sqlite/Karkas.Core.Data.Sqlite.csproj"
# cp ../../TestCSharp/SqliteProgramChinook.cs Program.cs
# cp --recursive ../../TestCSharp/Helpers/ .
# cp ../../TestCSharp/HelpersConnection/ConnectionHelperSqlite.cs ConnectionHelper.cs
# cp ../../Chinook/Chinook.db Chinook.db
# dotnet build
# dotnet run

