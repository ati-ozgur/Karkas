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

CONTAINER_NAME="datatypes-oracle23ai-container1"
IMAGE_NAME="datatypes-oracle23ai-image1"
DB_PASSWORD="Karkas@Passw0rd"




cd ./Karkas.Examples/Databases/data-types-oracle

docker build -f Dockerfile23ai -t $IMAGE_NAME .

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

docker run --detach -p 1523:1521 --name $CONTAINER_NAME  --hostname $CONTAINER_NAME  $IMAGE_NAME

CONTAINER_ID=$(docker inspect --format="{{.Id}}" "$CONTAINER_NAME")
echo "CONTAINER_ID $CONTAINER_ID"


timeout 600s grep -q 'DATABASE IS READY TO USE!' <(docker logs -f $CONTAINER_ID) ||  { echo "docker takes too long time to run"; exit 1; }



pwd

echo "go to ${BASE_REPO_DIRECTORY}"
cd ..
cd ..
cd ..
pwd

rm -rf Karkas.Examples/GeneratedProjects/DataTypesOracle

dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname DataTypesOracle23ai
cd Karkas.Examples/GeneratedProjects/DataTypesOracle


dotnet new console
dotnet add package Oracle.ManagedDataAccess.Core
dotnet add reference "../../../Karkas.Data/Karkas.Data/Karkas.Data.csproj"
dotnet add reference "../../../Karkas.Data/Karkas.Data.Oracle/Karkas.Data.Oracle.csproj"

cp ../../TestCSharp/Programs/ProgramDataTypesOracle.cs Program.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsings.cs GlobalUsings.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsingsDataTypes.cs GlobalUsingsDataTypes.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsingsOracle.cs GlobalUsingsOracle.cs

cp ../../TestCSharp/HelpersConnection/ConnectionHelperOracleDataTypes23ai.cs ConnectionHelper.cs

dotnet build
dotnet run

if [ $STOP = "stop" ]; then
  echo "stopping and removing containers"
  docker stop "$CONTAINER_NAME" &>/dev/null && echo "Stopped container $CONTAINER_NAME"
  docker rm "$CONTAINER_NAME"
fi
