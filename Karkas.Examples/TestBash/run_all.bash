#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.

set -euo pipefail

export current_script_directory=$(dirname "$0")
echo "The script you are running has:"
echo "basename: [$(basename "$0")]"
echo "dirname : [$current_script_directory]"
echo "pwd     : [$(pwd)]"

$current_script_directory/run_chinook_sqlite_auto_increment.bash
$current_script_directory/run_chinook_oracle_auto_increment.bash stop
$current_script_directory/run_chinook_oracle_normal.bash stop
$current_script_directory/run_chinook_sqlserver_auto_increment.bash  stop
$current_script_directory/run_datatypes_sqlite.bash
$current_script_directory/run_datatypes_oracle.bash stop
$current_script_directory/run_datatypes_sqlserver.bash stop

