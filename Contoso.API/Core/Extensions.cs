using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace Contoso.API.Core
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // CORS
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
        public static long CardNoDecrypt(string cardNo)
        {
            var resultString = Regex.Match(cardNo, @"\d+").Value;
            return Convert.ToInt64(resultString);
        }
    }
}
