variable "resource_group_name" {
  type = string
  description = "Name of the resource group"
}

variable "resource_group_location" {
  type = string
  description = "Resource group location"
}

variable "app_service_plan_name" {
  type = string
  description = "Name of the app service plan"
}

variable "app_service_name" {
  type = string
  description = "app service name"
}

variable "sql_server_name" {
  type = string
  description = "Name of the SQL Server"
}

variable "sql_database_name" {
  type = string
  description = "Name of the SQL DB"
}

variable "sql_admin_login" { 
  type = string
  description = "Admin login name"
}

variable "sql_admin_password" {
  type = string
  description = "Admin login password"
}

variable "firewall_rule_name" {
  type = string
  description = "Firewall rule name"
}

variable "repo_URL" {
  type = string
  default = "Git Hub repository link"
}