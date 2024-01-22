node {
    try {
        def dotnetVersion = "6.0"
        
        stage('[GIT] Run Checkout') {
            checkout scm
        }

        stage('[.NET][Testing] Run test') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")

            stage('[.NET][Testing] Pull image dotnet/sdk:$dotnetVersion') {
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

                stage('[.NET][Testing] Run test') {
                    sh '''
                        export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME
                        export HOME=/tmp

                        echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"
                        echo "HOME: \$HOME"

                        dotnet test --no-build --verbosity normal
                    '''
                }
            }
        }
    } catch (Exception e) {
        println('Caught exception: ' + e)

        currentBuild.result = 'FAILED'
    } finally {
        stage('Clean workspace') {
            cleanWs()
        }
    }
}