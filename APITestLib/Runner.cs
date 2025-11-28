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
            // Parse lines once and reuse them for all parsing operations
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var response = GetRequest(lines, out r);

            return response;

        }

        private IRestResponse GetRequest(string[] lines, out RestRequest request)
        {
            var entPoint = GetEntPoint(lines);
            var client = new RestClient(entPoint);
            request = new RestRequest(GetRequestMethod(lines));


            IDictionary<string, string> headers = GetHeaders(lines);
            foreach (var key in headers.Keys)
            {
                request.AddHeader(key, headers[key]);
            }


            IDictionary<string, string> bodyParameter = GetBodyParameters(lines);
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
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return GetEntPoint(lines);
        }

        private string GetEntPoint(string[] lines)
        {
            var entpoint = string.Empty;

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
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return GetRequestMethod(lines);
        }

        private Method GetRequestMethod(string[] lines)
        {
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
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return GetHeaders(lines);
        }

        private IDictionary<string, string> GetHeaders(string[] lines)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

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
            string[] lines = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return GetBodyParameters(lines);
        }

        private IDictionary<string, string> GetBodyParameters(string[] lines)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

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
