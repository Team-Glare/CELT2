
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


![CELT2.0 Architecture](https://user-images.githubusercontent.com/8182937/135469169-44d400b6-ff5f-481b-8a23-d3965c8d6cb2.png)

In our repo, we have separate directories of frontend, API, server, and model.

* Frontend: If any code is committed into the frontend directory, then the frontend gets published to GitHub pages using the Github actions. Our published frontend URL: https://team-glare.github.io/CELT2/
* API: If any code is committed into the API directory, then the API gets published to Azure Webapp using the Github actions. Our published API URL: https://celtapi.azurewebsites.net/
* Model & Server: If any code is committed into the model and server directory, then the model & server gets published to Digital Ocean using the Github actions.

The advantages of CELT2.0 architecture:
* Easily maintainable.
* Can be easily swapped out any submodule with a different module.
* Each sub-module can be tested separately.
* Each sub-module change can be published separately.



## WEBSITE
* [CELT2.0 Website](https://team-glare.github.io/CELT2/)


## 

<img width="882" alt="Capture1" src="https://user-images.githubusercontent.com/89327790/134822122-aabc6591-3c7f-4d4d-b4d2-991f6e4d6684.PNG">




An example of the analysis of a negative sample text:

<img width="899" alt="Capture2" src="https://user-images.githubusercontent.com/89327790/134822124-47256bc3-1985-4207-a1cd-1b6f21b8c337.PNG">




An example of the analysis of a positive sample text:

<img width="872" alt="Capture3" src="https://user-images.githubusercontent.com/89327790/134822125-24560298-1977-47b6-870d-3306d162e048.PNG">




An example of the analysis of an uploaded file:
<img width="920" alt="Capture4" src="https://user-images.githubusercontent.com/89327790/134822127-522b4c64-2319-4f0e-a444-17debe948e2c.PNG">

## Setup

Prerequisites:
* [.NET](https://dotnet.microsoft.com/download/dotnet/5.0) >= 5.0
* [Docker](https://docs.docker.com/get-docker/) >= 20.10.7
* [Python](https://www.python.org/downloads/) >= 3.8
* [pip](https://linuxize.com/post/how-to-install-pip-on-ubuntu-20.04/) >= 20.0.2

Strongly recommended:
* Environment capable of using a UNIX-based terminal - Ubuntu, WSL/2, etc.

Dependencies:
* Within the context of the root folder, run ```setup.sh```. This will acquire the requirements from the API, Model, and Server, and download them for you from the appropriate sources.

*If the script says "command not found" or something similar, either run ```chmod +x ./setup.sh```. This grants the script execution privileges. Depending on your setup, this may occur for the boot_dockerless files, amongst others. The same command will fix the issue.*


Running the Server:
* Locally:
    * Within the server subdirectory, you can run ```./boot_dockerless.sh```, which will run Flask for you (after checking all of the require depedencies exist). This will only allow for local connections and testing. The server will be listening on 'http://localhost:8000' 
* Containerized:
  * Containerization instructions can be viewed in [containerization.md](containerization.md)

Running the API:
* Locally:
    * Within the API/CELTAPI subdirectory, change `ServerBaseURL` of the `appsettings.json` to 'http://localhost:8000'.
    * Then, within the API subdirectory, run the ```run.sh```, then the API will be listening on 'https://localhost:5001'.
    * You can run the API manually as well by moving into the subdirectory API/CELTAPI and run this command `dotnet run CELTAPI.csproj`

Running the Frontend:
* Locally:
	* In the ```main.js``` file, replace the ```apiBaseURL``` with the above API url 'https://localhost:5001'.
	* Open the ```index.html``` file to access the main page. 


## INSPIRATION AND IMPROVEMENTS

Our Sentiment Analyzer is based on work done by a previous group:
[C.E.L.T: The Sentimental Analyser](https://github.com/mrpudlo/SE_Project1)

The central function of our sentiment analyzer is similar, and the inputs that are supported in Phase 1 are available in the original Sentiment Analyzer.

CELT2.0 offers certain improvements over the original that make it easier to use and develop:
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
