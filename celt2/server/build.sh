#! /bin/bash
cd ../
echo "Changed directory to /celt2/"
docker build ./ -t celt2_server_image -f ./server/Dockerfile 
