using System;
using System.Collections.Generic;
using System.Threading;
using APITestLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace APITestLibTests
{
    [TestClass()]
    public class RunnerTests
    {
        //[TestMethod()]
        //public void SendRequestTest()
        //{
        //    //--Arrange
        //    Runner runner = new Runner();
        //    var inputText = @"var client = new RestClient(""http://localhost:7979/v1/games\"");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader(""postman-token"", ""e063b2e6-8186-e0a3-048a-681b461aac85"");
        //    request.AddHeader(""cache-control"", ""no-cache"");
        //    request.AddHeader(""token"", ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huRG9lIiwiUGFzc3dvcmQiOiJQYXNzd29yZDEyMyIsIm5iZiI6MTUxNjYyNDcxNywiZXhwIjoxNTE2NzExMTE3LCJpYXQiOjE1MTY2MjQ3MTcsImlzcyI6IkRpZ2lPdXRzb3VyY2UiLCJhdWQiOiJyZWNlaXZlclRlc3QifQ.yDA8fXPEpB7W45tAUuzjJQDuKzbuivcffZexkanth64"");
        //    request.AddHeader(""content-type"", ""application/json"");
        //    request.AddParameter(""application/json"", ""{\r\n\t\""country\"":\""france\"",\r\n\t\""clientCode\"":\""\"",\r\n\t\""language\"":\""\"",\r\n\t\""clientType\"":1,\r\n\t\""gamingServerId\"":42,\r\n\t\""casinoId\"":2234,\r\n\t\""playerId\"":7069169\r\n}\t"", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    ";

        //    IRestResponse restResponse = null;
        //    //--Act
        //    for (int i = 0; i < 3; i++)
        //    {
        //        restResponse = runner.SendRequest(inputText);
        //    }

        //    Console.WriteLine(restResponse.Content);

        //    //--Assert
        //    Assert.IsTrue(restResponse.IsSuccessful,"All good");
        //    Assert.IsTrue(restResponse.Content.Length>0);
        //}

        [TestMethod()]
        public void SendRequestMultiThreadTest()
        {
            //--Arrange
            Runner runner = new Runner();
            var inputText = "var client = new RestClient(\"http://localhost:7979/v1/games\");\r\nvar request = new RestRequest(Method.POST);\r\nrequest.AddHeader(\"postman-token\", \"2a98ad2f-72b6-0937-c9db-874ecafa7e8d\");\r\nrequest.AddHeader(\"cache-control\", \"no-cache\");\r\nrequest.AddHeader(\"token\", \"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huIiwiUGFzc3dvcmQiOiJEb2UiLCJuYmYiOjE1MTYxODA5OTcsImV4cCI6MTUxNjI2NzM5NywiaWF0IjoxNTE2MTgwOTk3LCJpc3MiOiJEaWdpT3V0c291cmNlIiwiYXVkIjoicmVjZWl2ZXJUZXN0In0.ksjpMY2GCUs_59GMaDx9wjdkbX-AAuZ8dlkRtCQi4tY\");\r\nrequest.AddHeader(\"content-type\", \"application/json\");\r\nrequest.AddParameter(\"application/json\", \"{\\r\\n\\t\\\"country\\\":\\\"\\\",\\r\\n\\t\\\"clientCode\\\":\\\"\\\",\\r\\n\\t\\\"language\\\":\\\"\\\",\\r\\n\\t\\\"clientType\\\":40,\\r\\n\\t\\\"gamingServerId\\\":312,\\r\\n\\t\\\"casinoId\\\":329,\\r\\n\\t\\\"playerId\\\":2772489\\r\\n}\\t\", ParameterType.RequestBody);\r\nIRestResponse response = client.Execute(request);";

            //--Act
            var restResponse = runner.SendRequest(0,50, inputText);

            Console.WriteLine(restResponse);

            //--Assert
            //Assert.AreEqual(restResponse,3);
        }

        [TestMethod()]
        public void GetEntPointTest()
        {
            //--Arrange
            Runner runner = new Runner();
            var expected = "http://localhost:7979/v1/games";
            var inputText = "var client = new RestClient(\"http://localhost:7979/v1/games\");\r\nvar request = new RestRequest(Method.POST);\r\nrequest.AddHeader(\"postman-token\", \"2a98ad2f-72b6-0937-c9db-874ecafa7e8d\");\r\nrequest.AddHeader(\"cache-control\", \"no-cache\");\r\nrequest.AddHeader(\"token\", \"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huIiwiUGFzc3dvcmQiOiJEb2UiLCJuYmYiOjE1MTYxODA5OTcsImV4cCI6MTUxNjI2NzM5NywiaWF0IjoxNTE2MTgwOTk3LCJpc3MiOiJEaWdpT3V0c291cmNlIiwiYXVkIjoicmVjZWl2ZXJUZXN0In0.ksjpMY2GCUs_59GMaDx9wjdkbX-AAuZ8dlkRtCQi4tY\");\r\nrequest.AddHeader(\"content-type\", \"application/json\");\r\nrequest.AddParameter(\"application/json\", \"{\\r\\n\\t\\\"country\\\":\\\"\\\",\\r\\n\\t\\\"clientCode\\\":\\\"\\\",\\r\\n\\t\\\"language\\\":\\\"\\\",\\r\\n\\t\\\"clientType\\\":40,\\r\\n\\t\\\"gamingServerId\\\":312,\\r\\n\\t\\\"casinoId\\\":329,\\r\\n\\t\\\"playerId\\\":2772489\\r\\n}\\t\", ParameterType.RequestBody);\r\nIRestResponse response = client.Execute(request);";

            //--Act
            string actual = runner.GetEntPoint(inputText);

            //--Assert
            Assert.AreEqual(expected,actual);

        }

        [TestMethod()]
        public void GetHeadersTest()
        {
            //--Arrange
            Runner runner = new Runner();
            var expected = 4;
            var inputText = "var client = new RestClient(\"http://localhost:7979/v1/games\");\r\nvar request = new RestRequest(Method.POST);\r\nrequest.AddHeader(\"postman-token\", \"2a98ad2f-72b6-0937-c9db-874ecafa7e8d\");\r\nrequest.AddHeader(\"cache-control\", \"no-cache\");\r\nrequest.AddHeader(\"token\", \"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huIiwiUGFzc3dvcmQiOiJEb2UiLCJuYmYiOjE1MTYxODA5OTcsImV4cCI6MTUxNjI2NzM5NywiaWF0IjoxNTE2MTgwOTk3LCJpc3MiOiJEaWdpT3V0c291cmNlIiwiYXVkIjoicmVjZWl2ZXJUZXN0In0.ksjpMY2GCUs_59GMaDx9wjdkbX-AAuZ8dlkRtCQi4tY\");\r\nrequest.AddHeader(\"content-type\", \"application/json\");\r\nrequest.AddParameter(\"application/json\", \"{\\r\\n\\t\\\"country\\\":\\\"\\\",\\r\\n\\t\\\"clientCode\\\":\\\"\\\",\\r\\n\\t\\\"language\\\":\\\"\\\",\\r\\n\\t\\\"clientType\\\":40,\\r\\n\\t\\\"gamingServerId\\\":312,\\r\\n\\t\\\"casinoId\\\":329,\\r\\n\\t\\\"playerId\\\":2772489\\r\\n}\\t\", ParameterType.RequestBody);\r\nIRestResponse response = client.Execute(request);";

            //--Act
            IDictionary<string,string> sut = runner.GetHeaders(inputText);
            var actual = sut.Count;

            //--Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetBodyParametersTest()
        {
            //--Arrange
            Runner runner = new Runner();
            var expected = 1;
            var inputText = "var client = new RestClient(\"http://localhost:7979/v1/games\");\r\nvar request = new RestRequest(Method.POST);\r\nrequest.AddHeader(\"postman-token\", \"2a98ad2f-72b6-0937-c9db-874ecafa7e8d\");\r\nrequest.AddHeader(\"cache-control\", \"no-cache\");\r\nrequest.AddHeader(\"token\", \"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNTFQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IkNhc2lubyIsIlBsYXRmb3JtIjoiIiwiTG9naW4iOiJKb2huIiwiUGFzc3dvcmQiOiJEb2UiLCJuYmYiOjE1MTYxODA5OTcsImV4cCI6MTUxNjI2NzM5NywiaWF0IjoxNTE2MTgwOTk3LCJpc3MiOiJEaWdpT3V0c291cmNlIiwiYXVkIjoicmVjZWl2ZXJUZXN0In0.ksjpMY2GCUs_59GMaDx9wjdkbX-AAuZ8dlkRtCQi4tY\");\r\nrequest.AddHeader(\"content-type\", \"application/json\");\r\nrequest.AddParameter(\"application/json\", \"{\\r\\n\\t\\\"country\\\":\\\"\\\",\\r\\n\\t\\\"clientCode\\\":\\\"\\\",\\r\\n\\t\\\"language\\\":\\\"\\\",\\r\\n\\t\\\"clientType\\\":40,\\r\\n\\t\\\"gamingServerId\\\":312,\\r\\n\\t\\\"casinoId\\\":329,\\r\\n\\t\\\"playerId\\\":2772489\\r\\n}\\t\", ParameterType.RequestBody);\r\nIRestResponse response = client.Execute(request);";

            //--Act
            IDictionary<string, string> sut = runner.GetBodyParameters(inputText);
            var actual = sut.Count;

            //--Assert
            Assert.AreEqual(expected, actual);

        }
    }
}