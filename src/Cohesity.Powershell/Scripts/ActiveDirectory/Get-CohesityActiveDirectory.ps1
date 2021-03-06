#### USAGE ####
#	********************** Using Function *********************
#   Get-CohesityActiveDirectory -DomainNames "cohesity.com","abc.com"
###############
function Get-CohesityActiveDirectory {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $false)]
        [string[]]$DomainNames
    )
    Begin {
        if (-not (Test-Path -Path "$HOME/.cohesity")) {
            throw "Failed to authenticate. Please connect to the Cohesity Cluster using 'Connect-CohesityCluster'"
        }
        $session = Get-Content -Path $HOME/.cohesity | ConvertFrom-Json

        $server = $session.ClusterUri

        $token = $session.Accesstoken.Accesstoken
    }

    Process {
        if($DomainNames) {
            $domains = $DomainNames -join ","
            $url = $server + '/irisservices/api/v1/public/activeDirectory?domains='+$domains
        } else {
            $url = $server + '/irisservices/api/v1/public/activeDirectory'
        }

        $headers = @{'Authorization' = 'Bearer ' + $token }
        $resp = Invoke-RestApi -Method Get -Uri $url -Headers $headers
        $resp
    }
    End {
    }
}