#
# @license
# Copyright Team Glare. All Rights Reserved.
#
# Use of this source code is governed by an MIT-style license that can be
# found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
#

# Import openjdk image for sentiment analysis usage
# Copy python 3.6 base image from Docker repo: View images at https://hub.docker.com/_/python
# This is a new feature as of Docker 17.05 called multi-stage builds
# https://docs.docker.com/develop/develop-images/multistage-build/
FROM python:3.9-slim-bullseye

# Set current working directory for future instructions: Documentation specifically only lists
# RUN, CMD, ENTRYPOINT, COPY, and ADD. If the folder doesn't exist, it will be created.
WORKDIR /
RUN touch __init__.py

# COPY file from the first parameter to the second parameter
# What isn't seen here is that the second requirements.txt has the WORKDIR behind it;
# so really, the command equates to COPY requirements.txt /server/requirements.txt
# Same for app.py, the server script
COPY model model
COPY server server

# When set to noninteractive, DEBIAN_FRONTEND disables
# the (usually) required user inputs during installation.
ARG DEBIAN_FRONTEND=noninteractive

# A dependency requires GCC to install. This package installs that, amongst others. The -y flag has the same
# functionality as the previous DEBIAN_FRONTEND arg, but sometimes it doesn't work for apt.
RUN apt update && apt -y install gcc && apt -y install g++

# Take each line in requirements.txt, find the package, and install the version listed.
RUN pip install -r /server/requirements.txt 
RUN pip install -r /model/requirements.txt -f https://download.pytorch.org/whl/lts/1.8/torch_lts.html

# Specify that I want to run python upon starting the container
ENTRYPOINT [ "python" ]

# Point to app.py for the ENTRYPOINT to execute
CMD [ "/server/app.py" ]
