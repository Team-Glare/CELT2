#! /bin/bash

# Stops all of the currently running containers,
# then deletes those containers.
# The image is unaffected.

docker stop $(docker ps -aq) && docker rm $(docker ps -aq)
