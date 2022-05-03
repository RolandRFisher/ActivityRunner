using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using APITestLib;

namespace APITestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test
            var inputText = @"var client = new RestClient(""http://localhost:7979/v1/games"");var request = new RestRequest(Method.POST);request.AddHeader(""postman-token"", ""e063b2e6-8186-e0a3-048a-681b461aac85"");request.AddHeader(""cache-control"", ""no-cache"");request.AddHeader(""token"", ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huRG9lIiwiUGFzc3dvcmQiOiJQYXNzd29yZDEyMyIsIm5iZiI6MTUxNjYyNDcxNywiZXhwIjoxNTE2NzExMTE3LCJpYXQiOjE1MTY2MjQ3MTcsImlzcyI6IkRpZ2lPdXRzb3VyY2UiLCJhdWQiOiJyZWNlaXZlclRlc3QifQ.yDA8fXPEpB7W45tAUuzjJQDuKzbuivcffZexkanth64"");request.AddHeader(""content-type"", ""application/json"");request.AddParameter(""application/json"", ""{\r\n\t\""country\"":\""france\"",\r\n\t\""clientCode\"":\""\"",\r\n\t\""language\"":\""\"",\r\n\t\""clientType\"":1,\r\n\t\""gamingServerId\"":42,\r\n\t\""casinoId\"":2234,\r\n\t\""playerId\"":7069169\r\n}\t"", ParameterType.RequestBody);IRestResponse response = client.Execute(request);";
            Runner lib = new Runner();
            var response = lib.SendRequest(inputText);
        }
    }
}
