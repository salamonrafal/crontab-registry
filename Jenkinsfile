node {
    try {
        def dotnetVersion = "6.0"
        
        stage('Prepare and Checkout') {
            checkout scm
        }

        stage('Prepare and Checkout') {
            docker
                .image("mcr.microsoft.com/dotnet/sdk:$dotnetVersion")
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