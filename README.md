# CELT2.0: Sentiment Analyzer  

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) [![GitHub issues](https://img.shields.io/github/issues/Team-Glare/CELT2)](https://github.com/Team-Glare/CELT2/issues)  [![codecov](https://img.shields.io/badge/codecov-100%25-brightgreen)](https://codecov.io/gh/Team-Glare/CELT2)
[![DOI](https://zenodo.org/badge/403367995.svg)](https://zenodo.org/badge/latestdoi/403367995) 


[![Build and Publish CELTAPI to Azure Web App](https://github.com/Team-Glare/CELT2/actions/workflows/CELTAPI_CI_CD.yml/badge.svg)](https://github.com/Team-Glare/CELT2/actions/workflows/CELTAPI_CI_CD.yml) [![Build and Publish Server to Digital Ocean](https://github.com/Team-Glare/CELT2/actions/workflows/publish-on-release.yaml/badge.svg)](https://github.com/Team-Glare/CELT2/actions/workflows/publish-on-release.yaml)


https://user-images.githubusercontent.com/89696745/135383880-3f1749ab-e2c2-4390-8cae-3d70078f70d2.mp4


## INTRODUCTION

Sentiment analysis is among the most rapidly increasing research areas in computer science. It is usually quite difficult to keep up with all of the development taking place in the area. By analyzing the data provided in different methods, we expect to achieve our goal of accurately predicting a user's sentiment in our project. Although it is still in its early phases of development, this project has the potential for application to a variety of sectors that could be beneficial to society. This report offers users a broad overview of the project, allowing individuals to understand it as open-source software and add improvements. The report also helps developers in comprehending the code and serves as a starting point for the project. 

The following technologies were used to complete the development, and it is recommended that the next group of developers who take on this project have these technologies installed and running before proceeding: 
* FrontEnd:
  * HTML
  * CSS
  * Javascript
* API
  * ASP.NET Core Web API 3.1
  * Nunit and Moq (Test Framework)
* Server
  * Flask Server & Dockerfile for Containerization
  * Pytest (Test Framework)
* Model
  * Flair
  * Torch

Although we have used HTML and CSS for the FrontEnd, the users can merge the backend logic with any of the front-end frameworks they wish to use such as React, angularJS, etc.


## WEBSITE
* [CELT2.0 Website](https://team-glare.github.io/CELT2/)


## Steps for execution

<img width="882" alt="Capture1" src="https://user-images.githubusercontent.com/89327790/134822122-aabc6591-3c7f-4d4d-b4d2-991f6e4d6684.PNG">




An example of the analysis of a negative sample text:

<img width="899" alt="Capture2" src="https://user-images.githubusercontent.com/89327790/134822124-47256bc3-1985-4207-a1cd-1b6f21b8c337.PNG">




An example of the analysis of a positive sample text:

<img width="872" alt="Capture3" src="https://user-images.githubusercontent.com/89327790/134822125-24560298-1977-47b6-870d-3306d162e048.PNG">




An example of the analysis of an uploaded file:
<img width="920" alt="Capture4" src="https://user-images.githubusercontent.com/89327790/134822127-522b4c64-2319-4f0e-a444-17debe948e2c.PNG">

## Setup

Prerequisites:
* .NET >= 5.0
* Docker >= 20.10.7
* Python >= 3.8
* pip >= 20.0.2

Strongly recommended:
* Environment capable of using a UNIX-based terminal - Ubuntu, macOS, WSL/2, etc.

Dependencies:
* Within the context of the root folder, run ```setup.sh```. This will acquire the requirements from the API, Model, and Server, and download them for you from the appropriate sources.

Running the Server:
* Locally:
    * Within the server subdirectory, you can run ```./boot_dockerless.sh```, which will run Flask for you (after checking all of the require depedencies exist). This will only allow for local connections and testing.
* Containerized:
    * We assume that you are using Digital Ocean for the sake of these steps - we highly encourage this, as Digital Ocean provides students $100 credit through the GitHub students program. 
    * To setup a Digital Ocean access key, once logged in, go to the ```API``` tab, and generate a Personal Access Token. Save this as ```DIGITALOCEAN_ACCESS_TOKEN``` within the repository secrets, and the workflows will automatically use it.
    * Ensure that the latest version of your code is pushed to GitHub. Go to the ```Actions tab```, and select ```Build and Publish Server to Digital Ocean```. Click ```Run Workflow```, and specify a version number. After some time, this will deploy an image to the Digital Ocean Images storage.
    * After this, enter the ```Apps tab```, create an App, and set the run command ```gunicorn --worker-tmp-dir /dev/shm --chdir ./server app:app```. Once the app is deployed, the server should be available at an external link, viewable at the top of the dashboard.


## INSPIRATION AND IMPROVEMENTS

Our Sentiment Analyzer is based on work done by a previous group:
[C.E.L.T: The Sentimental Analyser](https://github.com/mrpudlo/SE_Project1)

The central function of our sentiment analyzer is similar, and the inputs that are supported in Phase 1 are available in the original Sentiment Analyzer.

CELT2.0 offers certain improvmenets over the original that make it easier to use and develop:
* Deployed on a server instead of locally
* Easier install process - central setup script setup.sh
* Line by line analysis - unfinished but supported by the analyzer 

## FUTURE SCOPE
View the [CELT2.0 Project](https://github.com/Team-Glare/CELT2/projects/2) in the Projects Tab to see issues that need attention.

Core functionality to be added:
* Video and audio file analysis
* Sentiment comparison of 2+ inputs
* Optionally show line by line analysis
* Create a separate DEV server for code integration.
* Add integration tests.
* Implement style and code checkers
* Allow server/model to analyze larger amounts of data


## LICENSE
This project is licensed under the MIT License  

## How to Contribute?  
Please see our CONTRIBUTING.md for instructions on how to contribute to the repo and assist us in improving this analyzer.

## VERSION
Initial release version 1.0.0

## Team Members
* [Setu Kumar Basak](https://github.com/setu1421)  
* [Conor Thomason](https://github.com/ConorThomason)  
* [Keertana Vellanki](https://github.com/KeertanaVellanki)  
* [Muntasir Hoq](https://github.com/muntasirhoq)  
* [Matthew Sohacki](https://github.com/msohacki)  
