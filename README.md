# DotNet.Agencias.Correios [![Nuget](https://img.shields.io/nuget/v/DotNetAgenciasCorreios)](https://www.nuget.org/packages/DotNetAgenciasCorreios/) ![Nuget](https://img.shields.io/nuget/dt/DotNetAgenciasCorreios)

DotNet.Agencias.Correios is a .Net library that helps you to get brazilian's mail agency.

## Notes
Version 1.0.1:

- Upgrade to .NET 6

## Installation

Use the package manager to install.

```bash
Install-Package DotNetAgenciasCorreios  -Version 1.0.1
```

## Usage

```C#
services.<ChooseYours><IHttpClientWrapper, HttpClientWrapper>();
services.<ChooseYours><IAgenciasCorreios, AgenciasCorreios>();

```

### Features
You will get an object with an object's array with Nome, CEP, Endereço and Situação
```C#
var agencias = GetAgenciasAsync("SP", "Sao Paulo", "Centro");
// agencias.Agencia[0].Nome -> AC CENTRAL DE SAO PAULO
// agencias.Agencia[0].CEP -> 01031-959
// agencias.Agencia[0].Endereco -> PRACA DO CORREIO, SN
// agencias.Agencia[0].Situacao -> FECHADA - Abre Segunda às 10:00
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
