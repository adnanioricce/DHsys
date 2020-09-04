
libs_path="src/Libraries"
unit_tests_path="tests/UnitTests"
integration_tests_path="tests/IntegrationTests"
presentation_projects_path="src/Presentation"
api_lib_projects={Application,Core,DAL,Infraestructure}
api_projects={Api}.csproj
api_test_projects={Api.IntegrationTests,Api.Tests,Core.Tests,DAL.Tests,Services.Tests}.csproj
build_api() {
    for i in {Application,Core,DAL,Infraestructure}; do 
        printf "--- Building Libraries tests ---"
        echo "dotnet build $libs_path/$i/$i.csproj"
    done
    for i in {Api.IntegrationTests,Api.Tests}; do
        printf "--- Running Integration tests ---"
        echo "dotnet test tests/$unit_tests_path/$i/$i.csproj"
    done
    for i in {Core.Tests,DAL.Tests,Services.Tests}; do 
        printf "--- Running Unit tests ---"
        echo "dotnet test tests/$integration_tests_path/$i/$i.csproj"
    done
    echo "dotnet build $presentation_projects_path/$i/$i.csproj"
}
publish_api_binaries(){
    printf "--- building release binaries ---"
    echo "dotnet publish src/**/Api.csproj -c Release -o build/Api"    
}
build_desktop(){
    printf "--- Building Desktop binaries ---"
    # for
}
echo $(build_api)
# set_env_variables(){
# }
# dotnet build DHsys.sln --configuration Release
# dotnet test 
