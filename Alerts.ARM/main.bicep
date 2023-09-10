param keyVaultName string
param location string = resourceGroup().location
param skuName string = 'standard'
param alertsPipelineObjectId string
param appPrincipalId string

module keyVaultModule './keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params: {
    keyVaultName: keyVaultName
    location: location
    skuName: skuName
    alertsPipelineObjectId: alertsPipelineObjectId
    appPrincipalId: appPrincipalId
  }
}
