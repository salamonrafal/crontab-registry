node {
    def dotnetVersion = "6.0"
    def pathToTestResultsUnit = ".test-results/unit/TestResults.xml"
    def pathToTestResultsIntegration = ".test-results/integration/TestResults.xml"

    try {
        stage('[GIT] Run Checkout') {
            checkout scm
        }

        stage('[.NET][Testing] Run test') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")

            stage('[.NET][Testing] Pull image dotnet/sdk') {
                dotnet.pull()
            }

            dotnet.inside {
                sh 'ls -lh'

                stage('[.NET][Testing] Restore projects') {

                    sh '''
                        export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME
                        export HOME=/tmp

                        echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"
                        echo "HOME: \$HOME"

                        dotnet restore;
                    '''
                }

                stage('[.NET][Testing] Build application') {
                    sh '''
                        export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME
                        export HOME=/tmp

                        echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"
                        echo "HOME: \$HOME"

                        dotnet build --no-restore
                    '''
                }

                stage('[.NET][Testing] Run test Unit') {
                    try {
                        sh '''
                            export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME
                            export HOME=/tmp

                            echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"
                            echo "HOME: \$HOME"

                            dotnet test --no-build --verbosity normal --logger 'junit' --results-directory './.test-results/unit' ./tests/Unit/Unit.csproj;
                        '''

                        junit "$pathToTestResultsUnit"
                    } catch (Exception e) {
                        if (fileExists(pathToTestResultsUnit)) {
                            sh 'ls -lh'
                            println("file founded: $pathToTestResultsUnit");

                            junit "$pathToTestResultsUnit"
                        } else {
                            echo "File report does not exist"
                        }

                        throw new Exception("${e.message}")
                    }
                }


                stage('[.NET][Testing] Run test Integration') {
                    try {
                        sh '''
                            export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME
                            export HOME=/tmp

                            echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"
                            echo "HOME: \$HOME"

                            dotnet test --no-build --verbosity normal --logger 'junit' --results-directory './.test-results/integration' ./tests/Integration/Integration.csproj;
                        '''

                        junit "$pathToTestResultsIntegration"
                    } catch (Exception e) {
                        if (fileExists(pathToTestResultsIntegration)) {
                            sh 'ls -lh'
                            println("file founded: $pathToTestResultsIntegration");

                            junit "$pathToTestResultsIntegration"
                        } else {
                            echo "File report does not exist"
                        }

                        throw new Exception("${e.message}")
                    }
                }
            }
        }
    } catch (Exception e) {
        println('Caught exception: ' + e)

        currentBuild.result = 'FAILED'
    } finally {
        stage('Clean workspace') {
           // cleanWs()
        }
    }
}