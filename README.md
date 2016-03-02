# ADP Client Connection Library for c#/.NET (Beta)

The ADP Client Connection Library is intended to simplify and aid the process of authenticating, authorizing and connecting to the ADP Marketplace API Gateway. The Library includes a sample application that can be run out-of-the-box to connect to the ADP Marketplace API **test** gateway.

There are two ways of installing and using this library:

  - Clone the repo from Github: This allows you to access the raw source code of the library as well as provides the ability to run the sample application and view the Library documentation
  - Search & Add the library as a NuGet library package to your Visual Studio solution. This is the recommended method when you are ready to develop amazing Apps for the ADP Marketplace store.

### Version
1.0.0

### Installation

**Clone from Github**

You can either use the links on Github or the command line git instructions below to clone the repo.

```sh
$ git clone https://github.com/adplabs/adp-connection-NET.git
```

followed by

```sh

$ cd adp-connection-NET

open the solution in VisualStudio
    adp-userinfo-NET.sln
    
run the demo client project ADPClientWebDemo

```

The build instruction should install the dependent packages from NuGet else get the packages from NuGet in the packages folder. If you run into errors you may need to open and run the solution in Visual Studio.

*Check out the configuration file*
```sh
type ADPClientDemo\bin\Debug\ADPClientDemo.exe.config
```
*Run the sample app*
```sh
$ cd adp-connection-NET
$ ADPClientDemo\bin\Debug\ADPClientDemo.exe
```

The results of the authentication Token received using the demo credentials is displayed.

***

## Examples
### Create Client Credentials ADP Connection

```c#
using ADPClient;
using System;
namespace ADPClientDemo {
    class Program {
        /// <summary>
        /// Demonstrating ADP Client connection library using a product url to get data
        /// after connecting
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // get new connection configuration
            // JSON config object placed in Web.config configuration or
            // set individual config object attributes

            string clientconfig = ADPClientDemo.Properties.Settings.Default.ClientCredentialConfiguration;
            ADPAccessToken token = null;
            if (String.IsNullOrEmpty(clientconfig)) {
                Console.WriteLine("Settings file or default options not available.");
            } else {
                ClientCredentialConfiguration connectionCfg = JSONUtil.Deserialize<ClientCredentialConfiguration>(clientconfig);
                ClientCredentialConnection connection = (ClientCredentialConnection)ADPApiConnectionFactory.createConnection(connectionCfg);
                try {
                    connection.connect();
                    if (connection.isConnectedIndicator()) {
                        token = connection.accessToken;
                        Console.WriteLine("Connected to API end point");
                        Console.WriteLine("Token:  ");
                        Console.WriteLine("         AccessToken: {0} ", token.AccessToken);
                        Console.WriteLine("         TokenType: {0} ", token.TokenType);
                        Console.WriteLine("         ExpiresIn: {0} ", token.ExpiresIn);
                        Console.WriteLine("         Scope: {0} ", token.Scope);
                        Console.WriteLine("         ExpiresOn: {0} ", token.ExpiresOn);
                    }
                } catch (Exception e)  { Console.WriteLine(e.Message); }
            }
        }
    }
}
```

## API Documentation ##

Documentation on the individual API calls provided by the library is automatically generated from the library code.

 
## Contributing ##

To contribute to the library, please generate a pull request. Before generating the pull request, please insure the following:

1. Appropriate unit tests have been updated or created.
2. Code coverage on the unit tests must be no less than 95%.
3. Your code updates have been fully tested and linted with no errors.
4. Update README.md and API documentation as appropriate.
 
## License ##

This library is available under the Apache 2 license (http://www.apache.org/licenses/LICENSE-2.0).


