

resource "azurecaf_name" "image-account-name" {
  name          = "animalchat"
  resource_type = "azurerm_storage_account"
}

resource "azurecaf_name" "image-container" {
  name          = "images"
  resource_type = "azurerm_storage_container"
}

resource "azurerm_storage_account" "image-account" {
  name                     = azurecaf_name.image-account-name.result
  resource_group_name      = azurerm_resource_group.application_group.name
  location                 = var.Location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = {
    # environment = "staging"
  }

  depends_on = [azurerm_resource_group.application_group]
}

resource "azurerm_storage_container" "images" {
  name                  = azurecaf_name.image-container.result
  storage_account_name  = azurecaf_name.image-account-name.result
  container_access_type = "private"

  depends_on = [azurerm_storage_account.image-account]
}