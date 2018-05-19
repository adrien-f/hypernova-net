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
