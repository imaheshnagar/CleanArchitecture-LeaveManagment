﻿using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace LeaveManagement.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected ILocalStorageService _localStorage;

        public BaseHttpService(IClient client,ILocalStorageService localStorage) 
        {
            this._client = client;
            this._localStorage = localStorage;
        }

        protected async Task AddBearerToken()
        {
            if (await _localStorage.ContainKeyAsync("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The record was not found.", Success = false };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }
    }
}
