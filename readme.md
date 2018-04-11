# BandsInTownSharp

A simple implementation of the Bands In Town v.3 API.
The response is JSON. 

Unfortunately the Bands In Town team removed some functions from the v.3 API, such as requesting events by location.
I'm in touch with the support and they have plans to add this in future again.


## Bands In Town API
Information about the API:
[Bands In Town API Info](https://manager.bandsintown.com/support/bandsintown-api)

The [API documentation](https://app.swaggerhub.com/apis/Bandsintown/PublicAPI/3.0.0#/artist%20information/artist) can also be used to generate sample rest calls to the API.

Please keep in mind:
> In order to use the Bandsintown API, you must have written consent from Bandsintown Inc. Any other use of the Bandsintown API is prohibited. Contact us to tell us what you plan to do and request your personal application ID.


## Included Projects
Included projects:
- BandsInTownSharp
- BandsInTownTest


## How to test
Checkout the project and have a look **into MainWindow.xaml.cs** in the **BandsInTownTest** project.
Here you will find the line with the **MyBitAPIKey**. Please replace with your key.

```C#
private BitClient bitClient = new BitClient("MyBitAPIKey");
```

## 3rd Party Libs
- Newtonsoft.Json.dll
- RestSharp.dll
- System.ValueTuple.dll
