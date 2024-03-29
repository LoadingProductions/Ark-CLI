﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Library
{
    public class Requests
    {
        private static HttpClient createJsonHttpClient()
        {
            HttpClient client = new HttpClient();

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static Response<T> post<T>(string url, FormUrlEncodedContent parameters)
        {
            HttpClient client = createJsonHttpClient();

            //HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Task<HttpResponseMessage> response = client.PostAsync(url, parameters);
            
            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public static Response<T> post<T>(string url, JsonObject json)
        {
            HttpClient client = createJsonHttpClient();

            //HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PostAsync(url, content);

            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public static Response<T> get<T>(string url)
        {
            HttpClient client = createJsonHttpClient();

            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Task<HttpResponseMessage> response = client.GetAsync(url);
            
            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public static Response<T> patch<T>(string url, FormUrlEncodedContent parameters)
        {
            HttpClient client = createJsonHttpClient();

            //HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Task<HttpResponseMessage> response = client.PatchAsync(url, parameters);

            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public static Response<T> patch<T>(string url, JsonObject json)
        {
            HttpClient client = createJsonHttpClient();

            //HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> response = client.PatchAsync(url, content);

            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }

        public static Response<T> delete<T>(string url)
        {
            HttpClient client = createJsonHttpClient();

            //HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Task<HttpResponseMessage> response = client.DeleteAsync(url);

            Response<T> result = new Response<T>(response);

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of;
            // for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return result;
        }
    }
}
