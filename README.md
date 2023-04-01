> **Note** This repository is developed using .netstandard2.1

[![NuGet Version](https://img.shields.io/nuget/v/HFMRProcessor.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/HFMRProcessor/)
[![Nuget Downloads](https://img.shields.io/nuget/dt/HFMRProcessor.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/HFMRProcessor)


This repository has represented a way to implement **background processes in out-of-process**. As you may have a requirement to implement a document generation (or any other bulk operations) which can cost a lot of time and you don't want to block current UI and allow user to navigate or do something else in your application, here you can see an approch how to implement this stuff.

For current implementation are used (maybe known library for you) [`HangFire`](https://github.com/HangfireIO/Hangfire) and [`MediatR`](https://github.com/jbogard/MediatR).

* `HangFire` -> For background process/request execution.
* `MediatR` -> Mediator for message/requests processing.


For more information about that, follow the info from using doc.

**In case you wish to use it in your project, u can install the package from <a href="https://www.nuget.org/packages/HFMRProcessor" target="_blank">nuget.org</a>** or specify what version you want:

> `Install-Package HFMRProcessor -Version x.x.x.x`

## Content
1. [USING](docs/usage.md)
1. [CHANGELOG](docs/CHANGELOG.md)
1. [BRANCH-GUIDE](docs/branch-guide.md)