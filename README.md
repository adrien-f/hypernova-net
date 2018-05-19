# HypernovaNet

Sample project using Hypernova and ASP .NET Core to render server-side React components.

## Running

```
docker-compose up
```

## Example

Currently it uses a tag helper.

```csharp
services.AddSingleton<IHypernovaClient>(new HypernovaClient(new HypernovaConfig
{
    Endpoint = "http://127.0.0.1:3000"
}));
```

```html
<hypernova component="HelloWorld" data="@Model.HelloWorldData"></hypernova>
```
