param location string

resource appServicePlan 'Microsoft.Web/serverfarms@2021-01-01' = {
  name: 'asp-core'
  location: location
  sku: {
    name: 'S1'
    tier: 'Standard'
  }
}

output appServicePlanId string = appServicePlan.id
