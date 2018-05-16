import hypernova from "hypernova/server";

hypernova({
    devMode: true,
    getComponent(name) {
        if (name == 'HelloWorld') {
            return require('./component').default;
        }
        return null;
    },
    port: 3000
})