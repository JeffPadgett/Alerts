param mainKeyVaultName string
param mainLocation string = resourceGroup().location
param mainSkuName string = 'standard'

module keyVaultModule './keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params: {
    keyVaultName: mainKeyVaultName
    location: mainLocation
    skuName: mainSkuName
  }
}
