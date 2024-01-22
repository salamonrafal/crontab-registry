node {
    try {
        def dotnetVersion = "6.0"
        
        stage('[GIT] Run Checkout') {
            checkout scm
        }

        stage('[.NET] Run test') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")
            dotnet.pull()
            dotnet.inside {
                sh 'ls -lh'
                sh '''
                    export DOTNET_CLI_HOME="/tmp/DOTNET_CLI_HOME"
                    export HOME="/tmp"
                    dotnet restore; \
                    dotnet build --no-restore; \
                    dotnet test --no-build --verbosity normal;
                '''
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