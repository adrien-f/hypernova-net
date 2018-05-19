# HypernovaNet

Sample project using Hypernova and ASP .NET Core to render server-side React components.

## Running

```
docker-compose up
```

## Example

Currently it uses a tag helper.

```typescript
import * as React from "react";
import {renderReact} from "hypernova-react"

interface HelloWorldProps {
    from: string;
}

export class HelloWorldComponent extends React.Component<HelloWorldProps, {}> {
    render() {
        return <h1>Hello World, from {this.props.from}!</h1>
    }
}

export default renderReact('HelloWorld', HelloWorldComponent);
```

```csharp
services.AddSingleton<IHypernovaClient>(new HypernovaClient(new HypernovaConfig
{
    Endpoint = "http://127.0.0.1:3000"
}));
```

```html
<hypernova component="HelloWorld" data="@Model.HelloWorldData"/>
```
