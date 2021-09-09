# Import python 3.6 base repo from Docker repo: View images at https://hub.docker.com/_/python
FROM python:3.6-bullseye

# Set current working directory for future instructions: Documentation specifically only lists
# RUN, CMD, ENTRYPOINT, COPY, and ADD. If the folder doesn't exist, it will be created.
WORKDIR /server

# COPY file from the first parameter to the second parameter
# What isn't seen here is that the second requirements.txt has the WORKDIR behind it;
# so really, the command equates to COPY requirements.txt /server/requirements.txt
# Same for app.py, the server script
COPY requirements.txt requirements.txt
COPY app.py app.py

# When set to noninteractive, DEBIAN_FRONTEND disables
# the (usually) required user inputs during installation.
ARG DEBIAN_FRONTEND=noninteractive

# Take each line in requirements.txt, find the package, and install the version listed.
RUN pip install -r ./requirements.txt

# Specify that I want to run python upon starting the container
ENTRYPOINT [ "python" ]

# Point to app.py for the ENTRYPOINT to execute
CMD [ "/server/app.py" ]
