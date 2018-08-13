[![Build status](https://ci.appveyor.com/api/projects/status/bltsg5mkb0ao1ep7/branch/master?svg=true)](https://ci.appveyor.com/project/DerKnob/bandsintownsharp/branch/master)

# BandsInTownSharp

A simple implementation of the BandsInTown (BIT) v.3 API.

Some information
- The BIT response is in the JSON format
- Solution is build with .Net 4.6.1
- I included a test progam with a simple UI

Unfortunately, the BandsInTown team removed some functions from the v.3 API, such as requesting events by location.
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
### Checkout
Checkout the project with git. Then open then Visual Studio solution. Go to **Extras->NuGet Package Manager->Package Manager Console** to open the **Package Manager Console**. Then type the command *Update-Package* to update the dependencies. If you want to setup it manually, have a look at the **3rd Party Libs** list. Now the build should work.

### Setup the BIT API Key
Once setup, have a look into the **MainWindow.xaml.cs** file inside the **BandsInTownTest** project. Here you will find the line with the **MyBitAPIKey**. Please replace with your key.

```C#
private BitClient bitClient = new BitClient("MyBitAPIKey");
```

## 3rd Party Libs
- Newtonsoft.Json.dll
- RestSharp.dll
- System.ValueTuple.dll
