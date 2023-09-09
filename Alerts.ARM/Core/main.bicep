param location string = 'East US'
param webappName string = 'twitchalerts'

module appServicePlanModule './appServicePlan.bicep' = {
  name: 'appServicePlanDeployment'
  params: {
    location: location
  }
}

module appServiceModule './appService.bicep' = {
  name: 'appServiceDeployment'
  params: {
    location: location
    webappName: webappName
    servicePlanId: appServicePlanModule.outputs.appServicePlanId
  }
  dependsOn: [
    appServicePlanModule
  ]
}

output mainAppServiceUrl string = appServiceModule.outputs.appServiceUrl
