For correct implementation, in the beginning, you must set the configuration options which are used by the current repository.

In your configuration file `appsettings.json` or `appsettings.{Environment}.json` you must add the following configurations as in example:

```json
"HangFireOptions": {
   "HeartbeatInterval": "HangFire server heartbeat interval",
   "ServerCheckInterval": "HangFire server check interval",
   "StorageTypeName": "Current database provider",
   "StorageConnectionString": "HangFire database connection string"
 }
```

`StorageTypeName` -> Set current `HangFire` database type, allowed values: 
* `MsSql` -> used for Microsoft SQL server;
* `PostgreSql` -> used for PostgreSQL server.

`StorageConnectionString` -> Set the current connection string where to store all data necessary for using the HangFire service.

The `HeartbeatInterval` and `ServerCheckInterval` are used in case when you register application as server in your `StartUp.cs` file.
```csharp
public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.RegisterProcessorAsServer(configuration)
            ...
        }
```


After setting all configurations, the next step is to set the configuration on your `StartUp.cs` file.

```csharp
        public void ConfigureServices(IServiceCollection services)
        {
            //Set configuration required for HangFire
            services.ConfigureHangFireServices(configuration);
            
            //Set current instance a a server
            services.RegisterProcessorAsServer(configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Set UI dashboard url and authorization filters
            app.UseCustomHangFireDashboard("/hangfire", new List<IDashboardAsyncAuthorizationFilter>());
        }
```

For the auth filter you must implement `IDashboardAsyncAuthorizationFilter` and set the necessary authorization criteria in the dependency of your application requirements.

To use implemented out-of-process you can use MediatR extensions allowing you to add a request to the queue.
Available methods are: `Enqueue`, `Enqueue<T>`, `EnqueueAwait`, `EnqueueAwait<T>`. All specified previous method return `IResult` from [`AggregatedGenericResultMessage`](https://www.nuget.org/packages/AggregatedGenericResultMessage), controlling all results without throwing exceptions.


In other cases, you can inject `IDispatcherService` to have access to dispatch methods where you can send a MediatR request or a method.

Also in the repository is available `IJobExecutionService`, which allows getting some useful information such as `GetLastSuccessfulRun`, `GetJobResultReturnedItems`, and `GetJobResultReturnedItem`.

