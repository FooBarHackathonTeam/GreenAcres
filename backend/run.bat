rd ./docker-compose.yml
rd ./docker-compose.override
rd ./DockerFile

xcopy /s ./DockerBuildData/Windows/docker-compose* .
xcopy ./DockerBuildData/Windows/DockerFile* ./RestApi