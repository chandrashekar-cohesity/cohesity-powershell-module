function Generate-CohesityPSCmdletTemplate {
    <#
        .SYNOPSIS
	Creates a powershell cmdlet template. 
	.DESCRIPTION
	Creates a powershell cmdlet's script template based on the given method type and feature. In case if the user doesn't provide the file path, it will create a file in the current directory.
	.LINK
	https://cohesity.github.io/cohesity-powershell-module/#/README
	.EXAMPLE
	Generate-CohesityPSCmdletTemplate -ActionType <string> -Feature <string>
        Generate-CohesityPSCmdletTemplate -ActionType Get -Feature ProtectionJob 
        Creates a template file for the given feature and Method type in the current location.
        .EXAMPLE
        Generate-CohesityPSCmdletTemplate -ActionType <string> -Feature <string> -FilePath <Path>
        Generate-CohesityPSCmdletTemplate -ActionType Get -Feature ProtectionJob -FilePath /home/Cohesity/
        Creates a template file for the given feature and Method type in the location passed in the FilePath.
    #>

    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateSet("GET", "POST","PUT","DELETE", "REGISTER")]
        [string]$ActionType,
        [Parameter(Mandatory = $true)]
        [string]$Feature,
        [Parameter(Mandatory = $false)]
        [string]$FilePath = $null
    )

    Begin {
    }

    Process {
        $ActionType = $ActionType.toLower()

        switch -exact ($ActionType){
            "get" {
                $filePrefix = "Get"
                $httpMethod = "Get"
                $errorMessage = "`"$Feature : Failed to fetch.`""
                break
            }
            "put" {
                $filePrefix = "Update"
                $httpMethod = "Put"
                $errorMessage = "`"$Feature : Failed to update.`""
                break
            }
            "post" {
                $filePrefix = "New"
                $httpMethod = "Post"
                $errorMessage = "`"$Feature : Failed to create.`""
                break
            }
            "delete" {
                $filePrefix = "Remove"
                $httpMethod = "Delete"
                $errorMessage = "`"$Feature : Failed to remove.`""
                break
            }
            "register"{
                $filePrefix = "Register"
                $httpMethod = "Post"
                $errorMessage = "`"$Feature : Failed to register.`""
                break
            }
        }

        # Creating file name of the new template file based on the method type and feature provided by the user like Register-CohesityProtectionJob.ps1 
        $fileName = $filePrefix + '-Cohesity' + $feature + '.ps1'

        # If file path is not provided by the user, current location is taken.
        if(!$FilePath){
            $fileLoc = "$((Get-Location).Path)/$fileName"
        }
        else{
            $fileLoc = "$FilePath/$fileName"
        }

        # Creating the new file.
        New-item $fileLoc
        $processBlock = $null
        $deleteBlock = $null

        if($ActionType -eq "post" -OR $ActionType -eq "put" -OR $ActionType -eq "register"){
            # Creating Process block for template file with body payload part for Post, Put, Register operation
            $processBlock = @"
        
        #       `$payload = @{}
        #       `$payloadJson = $payload | ConvertTo-Json -Depth 100
        #       `$resp = Invoke-RestApi -Method $httpMethod -Uri `$cohesityUrl -Headers `$cohesityHeaders -Body `$payloadJson
"@
        }

        if($ActionType -eq "get" -OR $ActionType -eq "delete"){
            if ($ActionType -eq "delete") {
                $processBlock = @"

        #       if(`$PSCmdlet.ShouldProcess(`$Param1)){
"@
                $deleteBlock = @"
        
        #       } else {
        #            return
        #       }
"@      
            }

            # Creating Process block for template file without body payload part for Get and Delete operation
            $processBlock = @"
                $processBlock
        #       `$resp = Invoke-RestApi -Method $httpMethod -Uri `$cohesityUrl -Headers `$cohesityHeaders
"@
        }

        # Creating the template body here.
        $FileContent = @"
function $filePrefix-Cohesity$Feature {
    <#
        .SYNOPSIS
        <string>.
        .DESCRIPTION
        <string>.
        .NOTES
        <string>
        <Add any specific note for the cmdlet or any prerequisites>
        .LINK
        https://cohesity.github.io/cohesity-powershell-module/#/README
        .EXAMPLE
        $filePrefix-Cohesity$Feature -Param1 <string>
    #>
    [CmdletBinding($(if($ActionType -eq "delete"){'SupportsShouldProcess = $True, ConfirmImpact = "High"'}))]
    Param(
        [Parameter(Mandatory = `$false)]
        `$Param1
    )
    Begin {
        if (-not (Test-Path -Path "`$HOME/.cohesity")) {
            throw "Failed to authenticate. Please connect to the Cohesity Cluster using 'Connect-CohesityCluster'"
        }
        `$cohesitySession = Get-Content -Path `$HOME/.cohesity | ConvertFrom-Json
        `$cohesityServer = `$cohesitySession.ClusterUri
        `$cohesityToken = `$cohesitySession.Accesstoken.Accesstoken
    }

    Process {
        #       Please uncomment the code to use it

        #       Append the url with your ActionType accordingly.
        #       `$cohesityUrl = `$cohesityServer + '/irisservices/api/v1/public/'
        #       `$cohesityHeaders = @{'Authorization' = 'Bearer ' + `$cohesityToken }
                $processBlock

        #       if (`$resp) {
        #           `$resp
        #       }
        #       else {
        #           `$errorMsg = $errorMessage
        #           Write-Host `$errorMsg
        #           CSLog -Message `$errorMsg
        #       }
                $deleteBlock
    }

    End {
    }
}
"@ | out-file $fileLoc # Writing the content of the template into the new created file.
    }

    End {
    }
}
Generate-CohesityPSCmdletTemplate 
