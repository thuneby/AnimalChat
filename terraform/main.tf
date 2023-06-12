locals {
  ResourceGroup = "animalchat"
}

resource "azurecaf_name" "resource-group" {
  name          = "animalchat"
  resource_type = "azurerm_resource_group"
}

resource "azurecaf_name" "image-account" {
  name          = "animalchat"
  resource_type = "azurerm_storage_account"
}

resource "azurecaf_name" "image-container" {
  name          = "images"
  resource_type = "azurerm_storage_container"
}



resource "azurerm_resource_group" "application_group" {
  name     = azurecaf_name.resource-group.result
  location = var.Location
}

resource "azurerm_storage_account" "image-account" {
  name                     = azurecaf_name.image-account.result
  resource_group_name      = azurerm_resource_group.application_group.name
  location                 = var.Location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = {
    # environment = "staging"
  }

}

resource "azurerm_storage_container" "images" {
  name                  = azurecaf_name.image-container.result
  storage_account_name  = azurecaf_name.image-account.result
  container_access_type = "private"

  depends_on = [azurerm_storage_account.image-account]
}

