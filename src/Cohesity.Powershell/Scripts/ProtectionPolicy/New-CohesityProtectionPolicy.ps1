function New-CohesityProtectionPolicy {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        $PolicyName
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
        $url = $server + '/irisservices/api/v1/public/protectionPolicies'

        $headers = @{'Authorization' = 'Bearer ' + $token }
        $payload = @{
            name                            = $PolicyName
            incrementalSchedulingPolicy     = @{
                periodicity     = "kMonthly";
                monthlySchedule = @{
                    dayCount = "kFirst";
                    day      = "kSunday"
                }
            }
            daysToKeep                      = 90;
            retries                         = 3;
            retryIntervalMins               = 30;
            blackoutPeriods                 = @();
            extendedRetentionPolicies       = @();
            snapshotReplicationCopyPolicies = @();
            snapshotArchivalCopyPolicies    = @();
            cloudDeployPolicies             = @()
        }
        $payloadJson = $payload | ConvertTo-Json
        $resp = Invoke-RestApi -Method Post -Uri $url -Headers $headers -Body $payloadJson
        if ($resp) {
            $resp
        }
        else {
            $errorMsg = "Protection Policy : Failed to create"
            Write-Host $errorMsg
            CSLog -Message $errorMsg
        }
    }
    End {
    }
}