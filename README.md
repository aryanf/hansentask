# hansentask

The code is developed in 4 c# project:
TaskUI: which is an console interface
HansenInterface: which specify all needed interface and ease testing through mocking (even though there is no dependency injection yet in this solution yet)
HansenCore: which has main functionalities to parse and make Soft and Tough outputs
HansenTests: which are xunit tests

# building and running

vscode lunch and task files are included in the repository if needed to run by those. Tests can be run through terminal (docker test)

Solution file is generated if it needs to be opened by visual studio code

Additionally there are 2 docker files that provide interactive terminal after building the project.
1. default docker file is used to run the app console:
docker build -t hansen .    
docker run -it hansen <arguments>

2. test docker file which build the projects and run the tests:
docker build -t hansentests --file Dockerfile.tests .
docker run -it hansentests
