"use strict";
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const React = __importStar(require("react"));
const hypernova_react_1 = require("hypernova-react");
class HelloWorldComponent extends React.Component {
    render() {
        return React.createElement("h1", null,
            "Hello World, $",
            new Date());
    }
}
exports.HelloWorldComponent = HelloWorldComponent;
exports.default = hypernova_react_1.renderReact('HelloWorld', HelloWorldComponent);
