node {
    try {
        def dotnetVersion = "6.0"
        
        stage('[GIT] Run Checkout') {
            checkout scm
        }

        stage('[.NET][Testing] Run test') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")
            dotnet.pull()
            dotnet.withRun('--env DOTNET_CLI_HOME=/tmp/DOTNET_CLI_HOME --env HOME=/tmp') {
                sh 'ls -lh'

                stage('[.NET][Testing] Restore projects') {
                    sh 'dotnet restore;'
                }

                stage('[.NET][Testing] Build application') {
                    sh 'dotnet build --no-restore;'
                }

                stage('[.NET][Testing] Run test') {
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