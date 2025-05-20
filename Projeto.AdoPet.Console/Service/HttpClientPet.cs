using System;
using System.Net.Http.Json;
using Projeto.AdoPet.Console.Model;

namespace Projeto.AdoPet.Console.Service;

public class HttpClientPet
{
    private HttpClient _client;

    public HttpClientPet()
    {
        this._client = ConfigureHttpClient("http://localhost:5059");
    }

    private HttpClient ConfigureHttpClient(string url)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        client.BaseAddress = new Uri(url);

        return client;
    }

    public Task CreatePetAsync(Pet pet)
    {
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    public async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
