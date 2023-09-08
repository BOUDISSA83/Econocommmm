const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
        target: "https://sateba-greentunnel.azurewebsites.net",
    secure: true
  }
]

module.exports = PROXY_CONFIG;
