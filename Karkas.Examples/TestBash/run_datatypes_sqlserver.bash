#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.


STOP=${1-false}

set -euo pipefail

CONTAINER_NAME="datatypes-sqlserver-container1"
IMAGE_NAME="datatypes-sqlserver-image1"
DB_PASSWORD="Karkas@Passw0rd"



WORKING_DIR=$PWD
echo $PWD


cd ./Karkas.Examples/TestBash/datatypes-sqlserver

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



CONTAINER_ID=$(docker inspect --format="{{.Id}}" "$CONTAINER_NAME")
echo "CONTAINER_ID $CONTAINER_ID"


timeout 60s grep -q 'Recovery is complete' <(docker logs -f $CONTAINER_ID) || exit 1

docker exec $CONTAINER_ID bash /home/create_datatypes_sqlserver.bash


echo "go to ${WORKING_DIR}"
cd $WORKING_DIR

CONTAINER_ID=$(docker inspect --format="{{.Id}}" "$CONTAINER_NAME")
echo "CONTAINER_ID ${CONTAINER_ID}"



rm -rf Karkas.Examples/GeneratedProjects/DataTypesSqlServer

dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname DataTypesSqlServer
cd Karkas.Examples/GeneratedProjects/datatypesSqlServer
dotnet new console
dotnet add package Microsoft.Data.SqlClient
dotnet add reference "../../../Karkas.Data/Karkas.Data/Karkas.Data.csproj"
dotnet add reference "../../../Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj"

cp ../../TestCSharp/Programdatatypes.cs Program.cs
cp ../../TestCSharp/GlobalUsings.cs GlobalUsings.cs
cp ../../TestCSharp/GlobalUsingsdatatypes.cs GlobalUsingsdatatypes.cs

cp --recursive ../../TestCSharp/Helpers/ .
cp ../../TestCSharp/HelpersConnection/ConnectionHelperSqlServer.cs ConnectionHelper.cs
cp --recursive ../../TestCSharp/Bs/ .
cp --recursive ../../TestCSharp/Dal/ .


dotnet build
dotnet run

if [ $STOP = "stop" ]; then
  echo "stopping and removing containers"
  docker stop "$CONTAINER_NAME" &>/dev/null && echo "Stopped container $CONTAINER_NAME"
  docker rm "$CONTAINER_NAME"
fi

