using System;
using RestSharp;
using Leaf.xNet;

namespace RecaptchaBypass
{
    class Bypass
    {
        public static void getTk()
        {
            string url = "your recaptcha get url (anchor)";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string tk = response.Content.Substring("id=\"recaptcha-token\" value=\"", "\"");
            Colorful.Console.WriteLine(tk, System.Drawing.Color.Red);
            postTK(tk);
        }
        public static void postTK(string tk)
        {
            string url = "your recaptcha get url (reload)";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            client.UserAgent = " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36";
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "_GRECAPTCHA= The cookies");
            request.AddParameter("v", "the v key");
            request.AddParameter("reason", "q");
            request.AddParameter("c", tk);
            request.AddParameter("k", "the k data");
            request.AddParameter("co", "the co data");
            request.AddParameter("hl", "en");
            request.AddParameter("size", "invisible");
            request.AddParameter("chr", "the chr data");
            request.AddParameter("vh", "the vh data");
            request.AddParameter("bg", "the bg data");
            IRestResponse response = client.Execute(request);
            tr = response.Content.Substring("[\"rresp\",\"", "\"");
            Colorful.Console.WriteLine(tr, System.Drawing.Color.Green);
        }
        public static string tr;
    }
}
