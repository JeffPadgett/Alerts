param location string
param webappName string
param servicePlanId string

resource appService 'Microsoft.Web/sites@2021-01-01' = {
  name: webappName
  location: location
  properties: {
    serverFarmId: servicePlanId
    siteConfig: {
      appSettings: [
        {
          name: 'WEBSITE_RUN_FROM_PACKAGE'
          value: '1'
        }
      ]
      netFrameworkVersion: 'v6.0'
    }
  }
}

output appServiceUrl string = appService.properties.defaultHostName
