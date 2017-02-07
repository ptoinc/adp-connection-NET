using ADPClient;
using System;


namespace ADPClientDemo
{
    class Program
    {

        /// <summary>
        /// Demonstrating ADP Client connection library using a product url to get data
        /// after connecting
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // get new connection configuration
            // JSON config object placed in Web.config configuration or
            // set individual config object attributes

            string clientconfig = ADPClientDemo.Properties.Settings.Default.ClientCredentialConfiguration;
            ADPAccessToken token = null;

            if (String.IsNullOrEmpty(clientconfig))
            {
                Console.WriteLine("Settings file or default options not available.");
            }
            else
            {
                ClientCredentialConfiguration connectionCfg = JSONUtil.Deserialize<ClientCredentialConfiguration>(clientconfig);
                ClientCredentialConnection connection = (ClientCredentialConnection)ADPApiConnectionFactory.createConnection(connectionCfg);

                try
                {
                    connection.connect();
                    if (connection.isConnectedIndicator())
                    {
                        token = connection.accessToken;

                        Console.WriteLine("Connected to API end point");
                        Console.WriteLine("Token:  ");
                        Console.WriteLine("         AccessToken: {0} ", token.AccessToken);
                        Console.WriteLine("         TokenType: {0} ", token.TokenType);
                        Console.WriteLine("         ExpiresIn: {0} ", token.ExpiresIn);
                        Console.WriteLine("         Scope: {0} ", token.Scope);
                        Console.WriteLine("         ExpiresOn: {0} ", token.ExpiresOn);

                        var eventsUrl = "https://iat-api.adp.com/events/core/v1/consumer-application-subscription-credentials.read";
                        var eventsBody = "{\"events\": [{}]}";
                        var eventsResults = connection.postADPEvent(eventsUrl, eventsBody);
                        Console.WriteLine("\r\nEvents Data: {0} ", eventsResults);

                        // String str = connection.getADPData("https://iat-api.adp.com/hr/v2/workers?limit=5");
                        // Console.WriteLine("\r\nData: {0} ",str);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Read();
            }
        }
    }
}
