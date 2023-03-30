using Newtonsoft.Json;
using System.Dynamic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace AkilliTicaretCase

{
    class Sabitler
    {
        public static string userToken ;
        public static dynamic PostMessageToServer(Object requestBody,string urlEk)
        {

            string jsonWS = "";
            var url = ("https://api.akilliticaretim.com");
            try
            {
                // HttpClient örneðini oluþtur
                var client = new HttpClient();

                // Ýstek için baþlýk deðerlerini ayarla
                client.DefaultRequestHeaders.Add("GUID", "5252-C88C-2911-DBF8");

                // Ýstek için URI'yi belirle
                var requestUri = new Uri("https://api.akilliticaretim.com/api"+urlEk);
                // Ýsteði oluþtur
                
                var requestDataJson = JsonConvert.SerializeObject(requestBody);
                var requestDataContent = new StringContent(requestDataJson, Encoding.UTF8, "application/json");

                // Ýsteði gönder ve yanýtý al
                var response = client.PostAsync(requestUri, requestDataContent).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    // Yanýtýn içeriðini oku
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("API yanýtý:");
                    Console.WriteLine(responseContent);
                    return response;
                }
                else
                {
                    Console.WriteLine("API isteði baþarýsýz oldu.");
                } 
            }
            catch (Exception ex) { }
            return null;
        }
        public static dynamic GetMessageFromServer(string urlEk)
        {

            string jsonWS = "";
            var url = ("https://api.akilliticaretim.com");

            if(urlEk == "/Product/ListProducts/1")
            {
                return ReadYedekProductList();
            }
            try
            {
                // HttpClient örneðini oluþtur
                var client = new HttpClient();

                // Ýstek için baþlýk deðerlerini ayarla
                client.DefaultRequestHeaders.Add("GUID", "5252-C88C-2911-DBF8");

                // Ýstek için URI'yi belirle
                var requestUri = new Uri("https://api.akilliticaretim.com/api" + urlEk);
                // Ýsteði oluþtur

                var requestDataContent = new StringContent("application/json");

                // Ýsteði gönder ve yanýtý al
                var response = client.GetAsync(requestUri).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Yanýtýn içeriðini oku
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    userToken = responseData.data.token;
                    Console.WriteLine("API yanýtý:");
                    Console.WriteLine(responseContent);
                    return response;
                }
                else
                {
                    Console.WriteLine("API isteði baþarýsýz oldu.");
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public static dynamic Login(string userName, string password)
        {
            string urlEk = "/auth/login";
            dynamic request = new ExpandoObject();
            request.username = userName;
            request.password = password;
            dynamic response = Sabitler.PostMessageToServer(request,urlEk);
            
            return (response);
        }
        public static dynamic ReadYedekProductList()
        {
            using (StreamReader r = new StreamReader("Products.json"))
            {
                string json = r.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);
                return data;
            }
        }

    }
}
