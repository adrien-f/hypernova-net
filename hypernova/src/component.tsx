import * as React from "react";
import {renderReact} from "hypernova-react"


export class HelloWorldComponent extends React.Component<{}, {}> {
    render() {
        return <h1>Hello World, {(new Date().toISOString())}</h1>
    }
}

export default renderReact('HelloWorld', HelloWorldComponent);