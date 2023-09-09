param mainKeyVaultName string
param mainLocation string = resourceGroup().location
param mainSkuName string = 'standard'
param alertsPipelineObjectId string

module keyVaultModule './keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params: {
    keyVaultName: mainKeyVaultName
    location: mainLocation
    skuName: mainSkuName
    alertsPipelineObjectId: alertsPipelineObjectId
  }
}
