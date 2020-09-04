declare -A configDict
env_variables_file = "E:\\Certs\\build_secrets"
while IFS='=' read -r key value; do
        configDict[$key]=$value
    done < $env_variables_file

# env_variables = (`cat "$env_variables_file" `)
build_docker_image(){
    printf "--- Building Docker Image ---"
    (cd src/Presentation/Api/)
    docker build . -t DHsysApi
}
push_docker_image(){
    printf "---  Push Docker Image ---"
    echo "docker push"
}
