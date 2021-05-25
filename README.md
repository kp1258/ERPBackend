# ERPBackend
This project is a part of the ERP system supporting management of production and trade company. The purpose of this system is to standarize order processing and support resource management. This project is server side application exposing web API.

## Technologies
Project is created with:
* ASP.Net Core 3.1
* ASP.NET Core Web API

## Features
* Placing and processing orders
* Warehouse state management
* User accounts management
* Standard product catalog management

## Additional information
### Security
Access to resources is secured with JSON Web Token based authentication and authorization. <br />
Authorization is role-based. Available roles:
* Administrator
* Salesman
* Production Manager
* Technologist
* Warehouseman
### File storage
Project is integrated with Azure Blob Storage

## Related projects
* [ERPFrontend](https://github.com/kp1258/ERPFrontend)
