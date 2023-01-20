# karkas
======


## How it works after code generation 1

```mermaid
sequenceDiagram
    Web-UI->>+Web-API: sends TypeLibrary JSON
    Web-API->>+Bs:  Call Bs Insert method with argument TypeLibrary
    Bs->>+Dal: Call Dal Insert method with argument TypeLibrary
    Dal->>+Database: Send SQL statement
    Database-->>-Dal: Send Result Back
    Dal-->>-Bs: Send Result Back
    Bs-->>-Web-API: Send Result Back
    Web-API-->>-Web-UI: Send Result Back
```



Aşağıdaki parçalardan oluşur.
 1. DAL - Data Access Library - Veri Ulaşım Kütüphanesi
 2. Code Generation

Bu hem kendisine ait bir kod kütüphanesi hemde bir code generation - kod üretme mantığı ile çalışmaktadır.

Aşağıdaki Veritabanlarını desteklemektedir.
 1. Sql Server
 2. Oracle
 3. Sqlite


## TODO

- Refactoring methods to English Only Names
- Remove Sqlite support and put json files for configuration. Instead of storing connection information in sqlite, json files will allow for version control also.
- Add configuration method which initializes from configuration files (app.config ...)
- Read logging and fix it

## Usage

...

## Installation - Kurulum

Kolay kullanımı desteklemek amacı ile nuget paketleri ile çalışmaktadır.
Aşağıdaki paketleri kullanabilirsiniz.

1. Karkas.CodeGeneration.WinApp.1.0.0
2. Karkas.Core.DataUtil.1.0.0

## Requirements

Visual Studio 2008-2012 ile çalışmaktadır.


## Contributing

See CONTRIBUTING file.

## Running the Tests

TODO

## Credits

...

## License

project-x is released under the MIT License. See the bundled LICENSE file for
details.
