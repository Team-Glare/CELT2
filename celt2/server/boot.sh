#! /bin/bash

# Runs the server docker image, creating a container.
# NOTE: This does not replace any currently existing containers;
# They must be shutdown/deleted if you wish to use only one container.

docker run celt2_server_image
