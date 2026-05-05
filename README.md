# Tradogram.REST.SDK

## Overview
**tradogram.REST.SDK** is a .NET 8 library that uses `Flurl` to provide a strongly-typed interface for integrating with the Tradogram REST API. The current iteration of this library aligns with Changelog #50 of the tradogram API docs. 

## Features

- **Full API Wrapper**: All methods currently exposed as of the Changelog noted above in Overview, are available for use. 
- **Strongly-typed Requests**:
- **Stringly-typed Responses**:
- **Custom Field Support**:
- **Testing**:
- **Logging**:

## Disclaimer

## Setup Instructions

### Prerequisites
- Tradogram API access (developer token)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or later (recommended)
- Serilog v4.3.0 or later for logging

### Installation
```
Install-Package Tradogram.REST.SDK
```

## Usage

### 0. Http Client Configuration and API Key Encoding
**IMPORTANT: Never expose your org token in client-side code or public repositories. Use a secrets manager or json configuration files that are in the .gitignore file**

```csharp
using Tradogram.REST.SDK.Utilities;
using Serilog;

    var encode = new Encoding();
    var flurlClient = new FlurlClientConfiguration();
    var client = flurlClient.CreateFlurlClient("https://api.tradogram.com/v1.0.4", false, 30);
    // client will need passed into the 1st parameter of each Endpoint class initiailization
    var xapikey = encode.Base64EncodeKey("your-org-token");
    // xapikey will need passed into the 2nd parameter of each Endpoint class initialization
```

### 1. Endpoint Initializations
```csharp
using Tradogram.REST.SDK.Endpoints;

    var approvalAPI = new ApprovalAPI(client, xapikey);
    var requisitionAPI = new RequisitionAPI(client, xapikey);
    var purchaseOrderAPI = new PurchaseOrderAPI(client, xapikey);
    var invoiceAPI = new InvoiceAPI(client, xapikey);
    var deliveryAPI = new DeliveryAPI(client, xapikey);
    var expensesAPI = new ExpensesAPI(client, xapikey);
    var creditNoteAPI = new CreditNoteAPI(client, xapikey);
    var branchAPI = new BranchAPI(client, xapikey);
    var supplierAPI = new SupplierAPI(client, xapikey);
    var glAccountAPI = new GlAccountAPI(client, xapikey);
    var departmentAPI = new DepartmentAPI(client, xapikey);
    var unitAPI = new UnitAPI(client, xapikey);
    var taxAPI = new TaxAPI(client, xapikey);
    var categoryAPI = new CategoryAPI(client, xapikey);
    var itemAPI = new ItemAPI(client, xapikey);
    var projectAPI = new ProjectAPI(client, xapikey);
    var locationAPI = new LocationAPI(client, xapikey);
```


