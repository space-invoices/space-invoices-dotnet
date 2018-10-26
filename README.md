# Space Invoices .NET SDK

[![Join the chat at https://gitter.im/space-invoices/space-invoices-dotnet](https://badges.gitter.im/space-invoices/space-invoices-dotnet.svg)](https://gitter.im/space-invoices/space-invoices-dotnet?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

The Space Invoices SDK provides an easy way to access Space Invoices API from application written in .NET Standard 1.1+, .NET Core 1.0+, and .NET Framework 4.5+

## Documentation

 **Detailed documentation about the API can be found at [docs.spaceinvoices.com](http://docs.spaceinvoices.com)**

**We also invite you to join our Slack community channel [Space Invaders](http://joinslack.spaceinvoices.com)**

## Installation

### Install SpaceInvoices via NuGet
```bash
nuget install SpaceInvoices
```

### From Package Manager:
```bash
PM> Install-Package SpaceInvoices
```
### From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "SpaceInvoices".
5. Click on the SpaceInvoices package, select the appropriate version in the right-tab and click *Install*.

## Usage

**TOKEN** and **ACCOUNT_ID** can be obtained by signing up for a develoepr account on our website: [spaceinvoices.com](http://spaceinvoices.com)

``` csharp
using SpaceInvoices;
SpaceConfiguration.SetApiKey("[your api key here]");
```

Example usage of SpaceInvoices SDK for creating an Organization.
``` csharp
SpaceOrganizationCreateOptions createOptions = new SpaceOrganizationCreateOptions{
    Name = "Space Exploration Technologies corp",
    Address = "Rocket Road",
    City = "Hawthorne",
    Zip = "CA 90250",
    Country = "USA",
    Iban = "123454321 123454321"
};

SpaceOrganizationService organizationService = new SpaceOrganizationService();
SpaceOrganization organization = organizationService.Create("USER_ID", createOptions);
```

Visit our website [spaceinvoices.com](http://spaceinvoices.com)