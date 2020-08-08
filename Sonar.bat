@echo off
SET runner=%1
SET step=%2
SET version=%3
SET branch=%4
SET target=%5

SET /P token=<sonar.key

IF "%branch%"=="" (SET branch=master)

IF /I "%step%"=="start" (
    echo Starting sonar...
    
    IF /I "%runner%"=="dotnet" (
        IF "%target%"=="" (
	    dotnet sonarscanner begin /k:"kitchenhelper" /v:"%version%" /o:"reanyalex" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%token%" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*,**/Program.cs,**/Startup.cs" /d:sonar.coverage.exclusions="**/*Tests.cs,**/KitchenHelper.API.Tests.Helpers/**/*,**/Program.cs,**/Startup.cs" /d:sonar.branch.name=%branch%
        ) ELSE (
            dotnet sonarscanner begin /k:"kitchenhelper" /v:"%version%" /o:"reanyalex" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%token%" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*,**/Program.cs,**/Startup.cs" /d:sonar.coverage.exclusions="**/*Tests.cs,**/KitchenHelper.API.Tests.Helpers/**/*,**/Program.cs,**/Startup.cs" /d:sonar.branch.name=%branch% /d:sonar.branch.target=%target%
        )
    )

    IF /I "%runner%"=="msbuild" (
        IF "%target%"=="" (
            SonarScanner.MSBuild begin /k:"kitchenhelper" /v:"%version%" /o:"reanyalex" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%token%" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*,**/Program.cs,**/Startup.cs" /d:sonar.coverage.exclusions="**/*Tests.cs,**/KitchenHelper.API.Tests.Helpers/**/*,**/Program.cs,**/Startup.cs" /d:sonar.branch.name=%branch%
        ) ELSE (
            SonarScanner.MSBuild begin /k:"kitchenhelper" /v:"%version%" /o:"reanyalex" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="%token%" /d:sonar.language="cs" /d:sonar.exclusions="**/bin/**/*,**/obj/**/*,**/Program.cs,**/Startup.cs" /d:sonar.coverage.exclusions="**/*Tests.cs,**/KitchenHelper.API.Tests.Helpers/**/*,**/Program.cs,**/Startup.cs" /d:sonar.branch.name=%branch% /d:sonar.branch.target=%target%
        )
    )

    echo Sonar started.
) ELSE IF /I "%step%"=="end" (
    echo Ending sonar...

    IF /I "%runner%"=="dotnet" (
        dotnet sonarscanner end /d:sonar.login="%token%"
    )

    IF /I "%runner%"=="msbuild" (
        SonarScanner.MSBuild end /d:sonar.login="%token%"
    )

    echo Ended sonar.
)