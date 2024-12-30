#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.


STOP=${1-false}

set -euo pipefail


export current_script_directory=$(dirname "$0")
echo "The script you are running has:"
echo "basename: [$(basename "$0")]"
echo "dirname : [$current_script_directory]"
echo "pwd     : [$(pwd)]"

export BASE_REPO_DIRECTORY="$current_script_directory/../.."
echo "BASE_REPO_DIRECTORY: $BASE_REPO_DIRECTORY"
cd $BASE_REPO_DIRECTORY



CONTAINER_NAME="chinook-sqlserver-container1"
IMAGE_NAME="chinook-sqlserver-image1"
DB_PASSWORD="Karkas@Passw0rd"





cd ./Karkas.Examples/Databases/chinook-sqlserver

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



pwd

echo "go to ${BASE_REPO_DIRECTORY}"
cd ..
cd ..
cd ..
pwd


CONTAINER_ID=$(docker inspect --format="{{.Id}}" "$CONTAINER_NAME")
echo "CONTAINER_ID ${CONTAINER_ID}"


docker exec $CONTAINER_ID bash /home/create_chinook_sqlserver_autoincrementpks.bash



rm -rf Karkas.Examples/GeneratedProjects/ChinookSqlServerAutoIncrement

dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname ChinookSqlServerAutoIncrement
cd Karkas.Examples/GeneratedProjects/ChinookSqlServerAutoIncrement
dotnet new console
dotnet add package Microsoft.Data.SqlClient
dotnet add reference "../../../Karkas.Data/Karkas.Data/Karkas.Data.csproj"
dotnet add reference "../../../Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj"

cp ../../TestCSharp/Programs/ProgramChinookAutoIncrement.cs Program.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsings.cs GlobalUsings.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsingsChinook.cs GlobalUsingsChinook.cs

cp --recursive ../../TestCSharp/Helpers/ .
cp ../../TestCSharp/HelpersTest/TestHelperChinook.cs TestHelperChinook.cs

cp ../../TestCSharp/HelpersConnection/ConnectionHelperSqlServerChinook.cs ConnectionHelper.cs
cp --recursive ../../TestCSharp/Bs/Karkas.Examples.Chinook.Bs .
cp --recursive ../../TestCSharp/Dal/Karkas.Examples.Chinook.Dal .


dotnet build
dotnet run

if [ $STOP = "stop" ]; then
  echo "stopping and removing containers"
  docker stop "$CONTAINER_NAME" &>/dev/null && echo "Stopped container $CONTAINER_NAME"
  docker rm "$CONTAINER_NAME"
fi
