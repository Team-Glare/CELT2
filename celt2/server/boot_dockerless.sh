#! /bin/bash

# Runs the server without needing to build a Docker image
# Note: This does not run with gunicorn. Good for testing server functionality,
# but not the server functions itself.

# This script must be run from the context of ~/celt2/server due to the relative paths used.
# Please cd into ~/celt2/server before attempting to run.
pip install -r ../model/requirements.txt -f https://download.pytorch.org/whl/lts/1.8/torch_lts.html
pip install -r ./requirements.txt
flask run
