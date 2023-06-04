rm ./docker-compose.yml
rm ./docker-compose.override.yml
rm ./RestApi/DockerFile

cp -r ./DockerBuildData/Linux/docker-compose* ./
cp -r ./DockerBuildData/Linux/DockerFile ./RestApi