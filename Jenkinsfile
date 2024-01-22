node {
    try {
        def dotnetVersion = "6.0"
        
        stage('Prepare and Checkout') {
            checkout scm
        }

        stage('Prepare and Checkout') {
            def dotnet = docker.image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")
            dotnet.pull()
            maven.inside {
                sh 'ls -lh'
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