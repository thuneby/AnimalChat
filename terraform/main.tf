locals {
  ResourceGroup = "animalchat"
}

resource "azurecaf_name" "resource-group" {
  name          = "animalchat"
  resource_type = "azurerm_resource_group"
}


resource "azurerm_resource_group" "application_group" {
  name     = azurecaf_name.resource-group.result
  location = var.Location
}



