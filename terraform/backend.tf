terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
    }
    azurecaf = {
      source  = "aztfmod/azurecaf"
      version = "1.2.10"
    }
  }

  backend "azurerm" {
    resource_group_name  = "rg-terraform"
    storage_account_name = "animalchatterraform"
    container_name       = "tfstate"
    key                  = "tfstate"
  }
}
provider "azurerm" {
  features {}
}