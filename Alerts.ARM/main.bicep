﻿param keyVaultName string
param location string = resourceGroup().location
param skuName string = 'standard'
param alertsPipelineObjectId string

module keyVaultModule './keyvault.bicep' = {
  name: 'keyVaultDeployment'
  params: {
    keyVaultName: keyVaultName
    location: location
    skuName: skuName
    alertsPipelineObjectId: alertsPipelineObjectId
    appServicePrincipalId: appService.outputs.identity.principalId
  }
}
