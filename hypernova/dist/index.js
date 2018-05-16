"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const server_1 = __importDefault(require("hypernova/server"));
server_1.default({
    devMode: true,
    getComponent(name) {
        if (name == 'HelloWorld') {
            return require('./component').default;
        }
        return null;
    },
    port: 3000
});
