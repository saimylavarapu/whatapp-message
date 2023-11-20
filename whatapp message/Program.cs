using Newtonsoft.Json;
using RestSharp;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using static whatapp_message.Model;

public class WhatsAppApiHelper
{
    static async Task Main(string[] args)
    {

        //  string verificationUrl = $"http://bestdotnettraining.com/Signin/verify?token={user.EmailVerficationCode}";
        string bearerToken = "EAADQBIhkcXQBO0zpSq2dSe5ZBVNdUACKLjJmgu0lTrXhD9Smwb4hFa9hze9vDnzaZCiimglMN6TvyQxu0EqZCHthqiknowFuCbq2ZBpkzUAl0IOZBseEGKW42qZCXvmWh7J6pC1AHDqAkS0ebZBDxojlUZBTAbGDIZCOVvjJlTY6pk8qXsbR9th8AngkSf9BlbFrWn2g7G4mJGSYfrXf9sUgZD";
        string apiUrl = "https://graph.facebook.com/v17.0/126727037183495/messages";
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);


        var data = new WhatsAppTemplate
        {
            MessagingProduct = "whatsapp",
            To = "919380083822",
            Type = "template",

            Template = new Template
            {
                Name = "account_confirmation",
                Language = new Language { Code = "en_US" },
                Components = new List<Component1>
                    {
                            new Component1
                            {
                            Type = "body",
                            Parameters = new List<Parameter>
                            {
                                new Parameter()
                                {
                                    Type="text",
                                    Text="dgdgs"
                                },
                                new Parameter()
                                {
                                    Type="text",
                                    Text= "dgsd"
                                }


                            }
                            }
                    }

            }
        };



        string Jsonpayload = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        HttpContent content = new StringContent(Jsonpayload, Encoding.UTF8, "application/json");

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
        request.Content = content;

        HttpResponseMessage response = client.SendAsync(request).Result;


        if (response.IsSuccessStatusCode)
        {
            string responseBody = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine("Response: " + responseBody);
        }
        else
        {
            Console.WriteLine("Request failed with status code: " + response.StatusCode);
        }


    }
    public class Parameter
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Component1
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }
    }
    public class Language
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public class Template
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("language")]
        public Language Language { get; set; }
        [JsonProperty("components")]
        public List<Component1> Components { get; set; }
    }

    public class WhatsAppTemplate
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("template")]
        public Template Template { get; set; }
    }
}
