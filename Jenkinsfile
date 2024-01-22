node {
    try {
        def dotnetVersion = "6.0"
        
        stage('[GIT] Run Checkout') {
            checkout scm
        }

        stage('[.NET][Testing] Run test') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")
            dotnet.pull()
            dotnet.inside {
                sh 'ls -lh'
                sh 'export DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME'
                sh 'export HOME=/tmp'
                sh 'echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"'
                sh 'echo "HOME: \$HOME"'
                stage('[.NET][Testing] Restore projects') {
                    sh 'echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"'
                    sh 'echo "HOME: \$HOME"'
                    sh 'dotnet restore;'
                }

                stage('[.NET][Testing] Build application') {
                    sh 'echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"'
                    sh 'echo "HOME: \$HOME"'
                    sh 'dotnet build --no-restore;'
                }

                stage('[.NET][Testing] Run test') {
                    sh 'echo "DOTNET_CLI_HOME: \$DOTNET_CLI_HOME"'
                    sh 'echo "HOME: \$HOME"'
                    sh 'dotnet test --no-build --verbosity normal;'
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