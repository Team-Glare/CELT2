#! /bin/bash
# Stops all currently running containers
# Can be restarted with boot.sh

docker stop $(docker ps -aq)
