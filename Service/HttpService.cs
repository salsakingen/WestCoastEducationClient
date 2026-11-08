using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WestCoastEducationClient.InterFace;

namespace WestCoastEducationClient.Service;

public class HttpService<T> : IHttpService<T> where T : class
{

    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };
    public HttpService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var apiKey = config.GetSection("Settings:ApiKey").Value!;
        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;

        _httpClient = new()
        {
            BaseAddress = new Uri(_baseUrl)
        };
        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "none");
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);


    }
    public async Task Delete(string resource, string id)
    {
        try
        {
            await _httpClient.DeleteAsync($"{_baseUrl}/{resource}/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<List<T>> Get(string resource)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}{resource}");

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{(int)response.StatusCode} {resource}: {result}");
            List<T> data = [];
            try
            {
                data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        Console.WriteLine($"Object Count: {data.Count}");
        return data;
    }


    public async Task<T> Get(string resource, string id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{resource}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(result))
                {
                    throw new Exception("Fanns ingenting");
                }

                var data = JsonSerializer.Deserialize<T>(result, _options)!;
                return data;
            }
            else
            {
                throw new Exception($"Error retrieving data: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving data: {ex.Message}");
        }
    }
    public async Task Post(string resource, T data)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await _httpClient.PostAsJsonAsync<T>($"{_baseUrl}/{resource}", data);
            var resultstring = await result.Content.ReadAsStringAsync();
            Console.WriteLine("Result: " + resultstring );
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task Put(string resource, T data, string objectId)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            await _httpClient.PutAsJsonAsync<T>($"{_baseUrl}/{resource}/{objectId}", data);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}