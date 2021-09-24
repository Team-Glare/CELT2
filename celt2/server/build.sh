#! /bin/bash
cp ../model/requirements.txt ./model_requirements.txt
cp ../model/model.py ./model.py
docker build ./ -t celt2_server_image
