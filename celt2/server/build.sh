#! /bin/bash
cp ../model/requirements.txt ./model_requirements.txt
docker build ./ -t celt2_server_image
