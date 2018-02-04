using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APITestLib
{
    public class Runner
    {
        public Runner()
        {

        }
        public IRestResponse SendRequest(string inputText)
        {
            RestRequest r;
            var response = GetRequest(inputText, out r);


            //var client = new RestClient("http://localhost:7979/v1/games");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("postman-token", "1e1d7a74-b682-8031-1d0e-d4915e81761c");
            //request.AddHeader("cache-control", "no-cache");
            //request.AddHeader("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJFZGdlTG9jYXRpb24iOiJNSVQiLCJCcmFuZCI6IiIsIlByb3ZpZGVyIjoiIiwiUHJvZHVjdCI6IlZlZ2FzIiwiUGxhdGZvcm0iOiIiLCJMb2dpbiI6IkpvaG5Eb2UiLCJQYXNzd29yZCI6IlBhc3N3b3JkMTIzIiwibmJmIjoxNTE2Njk3OTk2LCJleHAiOjE1MTY3ODQzOTYsImlhdCI6MTUxNjY5Nzk5NiwiaXNzIjoiRGlnaU91dHNvdXJjZSIsImF1ZCI6InJlY2VpdmVyVGVzdCJ9.-svAG7IgxJH_js7y2K2ph1t3-E-AGur0YzLg3Gsw2X0");
            //request.AddHeader("content-type", "application/json");
            //request.AddParameter("application/json", "{\r\n\t\"country\":\"\",\r\n\t\"clientCode\":\"\",\r\n\t\"language\":\"\",\r\n\t\"clientType\":1,\r\n\t\"gamingServerId\":312,\r\n\t\"casinoId\":329,\r\n\t\"playerId\":2772489\r\n}\t", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            return response;

        }

        private IRestResponse GetRequest(string inputText, out RestRequest request)
        {
            var entPoint = GetEntPoint(inputText);
            var client = new RestClient(entPoint);
            request = new RestRequest(GetRequestMethod(inputText));


            IDictionary<string, string> headers = GetHeaders(inputText);
            foreach (var key in headers.Keys)
            {
                request.AddHeader(key, headers[key]);
            }


            IDictionary<string, string> bodyParameter = GetBodyParameters(inputText);
            foreach (var key in bodyParameter.Keys)
            {
                //TODO: fixed GetBodyParameters first
                request.AddParameter(key, bodyParameter[key], ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        public int SendRequest(int maxThreads, int maxRequests, string inputText)
        {
            Parallel.For(maxThreads, maxRequests, i =>
            {
                SendRequest(inputText);
            });
            return 0;
        }

        public string GetEntPoint(string inputText)
        {
            var entpoint = string.Empty;

            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var identifier = "var client = new RestClient(";

            var startIndexValue = "(";
            var startIndexOffset = 2;

            var endIndexValue = ")";
            var endIndexOffset = 3;

            foreach (var line in lines)
            {
                if (line.StartsWith(identifier))
                {
                    var startIndex = line.IndexOf(startIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    var endIndex = line.IndexOf(endIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    entpoint = line.Substring(startIndex + startIndexOffset, endIndex - (startIndex + endIndexOffset));
                }

            }

            return entpoint;
        }
        public Method GetRequestMethod(string inputText)
        {
            var entpoint = string.Empty;

            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var identifier = "var request = new RestRequest(Method.";

            foreach (var line in lines)
            {
                if (line.StartsWith(identifier))
                {
                    switch (line)
                    {
                        case "var request = new RestRequest(Method.GET);": return Method.GET;
                        case "var request = new RestRequest(Method.POST);": return Method.POST;
                        case "var request = new RestRequest(Method.DELETE);": return Method.DELETE;
                        case "var request = new RestRequest(Method.PUT);": return Method.PUT;
                        case "var request = new RestRequest(Method.MERGE);": return Method.MERGE;
                        case "var request = new RestRequest(Method.HEAD);": return Method.HEAD;
                        case "var request = new RestRequest(Method.OPTIONS);": return Method.OPTIONS;
                        case "var request = new RestRequest(Method.PATCH);": return Method.PATCH;
                    }
                }
            }
            return Method.GET;
        }

        public IDictionary<string, string> GetHeaders(string inputText)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var identifier = "request.AddHeader(";

            var startIndexValue = "(";
            var startIndexOffset = 2;

            var endIndexValue = ")";
            var endIndexOffset = 3;

            foreach (var line in lines)
            {
                if (line.StartsWith(identifier))
                {
                    var startIndex = line.IndexOf(startIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    var endIndex = line.IndexOf(endIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    var l = line.Substring(startIndex + startIndexOffset, endIndex - (startIndex + endIndexOffset));
                    var d = l.Split(',');
                    result.Add(d[0].Replace("\"", "").Trim(), d[1].Replace("\"", "").Trim());
                }
            }

            return result;
        }

        public IDictionary<string, string> GetBodyParameters(string inputText)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var identifier = "request.AddParameter(";

            var startIndexValue = "(";
            var startIndexOffset = 2;

            var endIndexValue = ")";
            var endIndexOffset = 3;

            foreach (var line in lines)
            {
                if (line.StartsWith(identifier))
                {
                    var startIndex = line.IndexOf(startIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    var endIndex = line.IndexOf(endIndexValue, StringComparison.InvariantCultureIgnoreCase);
                    var l = line.Substring(startIndex + startIndexOffset, endIndex - (startIndex + endIndexOffset));
                    var d = l.Split(new[] { ", " }, StringSplitOptions.None);

                    var openBracket = d[1].IndexOf("{", StringComparison.InvariantCultureIgnoreCase);
                    var closedBracket = d[1].IndexOf("}", StringComparison.InvariantCultureIgnoreCase);

                    var bodyParam = d[1].Substring(openBracket, closedBracket + 1 - openBracket);


                    result.Add(d[0].Replace("\"", ""), bodyParam.Replace("\\r", "").Replace("\\n", "").Replace("\\t", "").Replace("\\", ""));
                }
            }

            return result;
        }
    }
}
