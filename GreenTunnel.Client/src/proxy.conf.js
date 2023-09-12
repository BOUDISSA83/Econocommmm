const PROXY_CONFIG = [
    {
        context: [
            "/api",
            "/swagger",
            "/connect",
            "/oauth",
            "/Identity",
            "/.well-known",
            "/_framework"
        ],
        target: "https://sateba-greentunnel.azurewebsites.net",
        secure: true,
        changeOrigin: true
    }
]

module.exports = PROXY_CONFIG;
