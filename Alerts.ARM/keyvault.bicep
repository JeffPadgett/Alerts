param keyVaultName string
param location string = resourceGroup().location
param skuName string
param alertsPipelineObjectId string

resource keyVault 'Microsoft.KeyVault/vaults@2019-09-01' = {
  name: keyVaultName
  location: location
  properties: {
    sku: {
      family: 'A'
      name: skuName
    }
    tenantId: subscription().tenantId
    accessPolicies: []
  }
  
}

resource keyVaultAccessPolicy 'Microsoft.KeyVault/vaults/accessPolicies@2022-07-01' = {
  parent: keyVault
  name: 'add'
  properties: {
    accessPolicies: [
      {
        tenantId: subscription().tenantId
        objectId: alertsPipelineObjectId
        permissions: {
          secrets: [
            'get', 'set'
          ]
        }
      }
    ]
  }
}
