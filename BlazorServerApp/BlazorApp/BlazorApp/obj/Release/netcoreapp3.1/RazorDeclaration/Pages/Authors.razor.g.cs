#pragma checksum "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a41fccd7dbaf74a79d106d851ffbac83ce501d0"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorServerApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using BlazorServerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using BlazorServerApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor"
using BlazorServerApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor"
using BlazorServerApp.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor"
using CuriousDriveRazorLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/authors")]
    public partial class Authors : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 100 "C:\Data\CuriousDrive\BookStores\BlazorServerApp\BlazorApp\BlazorApp\Pages\Authors.razor"
       

    public Author author { get; set; }
    public List<Author> authorList { get; set; }
    public string SelectedCity { get; set; }

    public bool IsVisible { get; set; }
    public bool Result { get; set; }
    public string RecordName { get; set; }
    public string[] Cities { get; set; }

    ElementReference firstNameTextBox;

    protected override void OnInitialized()
    {
        Console.WriteLine("Authors - OnInitialized");
        base.OnInitialized();        
    }

    protected override async Task OnInitializedAsync()
    {
        Console.WriteLine("Authors - OnInitializedAsync");

        author = new Author();
        authorList = new List<Author>();
        //authorList = await authorService.GetAuthors();

        await base.OnInitializedAsync();
    }

    protected override void OnParametersSet()
    {
        Console.WriteLine("Authors - OnParametersSet");
        base.OnParametersSet();
    }

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("Authors - OnParametersSetAsync");
        await base.OnParametersSetAsync();
    }

    protected override bool ShouldRender()
    {
        base.ShouldRender();
        Console.WriteLine("Authors - ShouldRender");

        return true;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        Console.WriteLine("Authors - OnAfterRender - firstRender = " + firstRender);
        base.OnAfterRender(firstRender);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Console.WriteLine("Authors - OnAfterRenderAsync - firstRender = " + firstRender);

        if (firstRender)
            await LoadAuthors();

        await base.OnAfterRenderAsync(firstRender);
    }

    public void Dispose()
    {
        Console.WriteLine("Authors - Dispose");
    }

    private async Task LoadAuthors()
    {
        authorList = await bookStoresService.GetAllAsync("authors/");

        if (authorList == null)
        {
            RefreshRequest refreshRequest = new RefreshRequest();
            refreshRequest.AccessToken = await localStorageService.GetItemAsync<string>("accessToken");
            refreshRequest.RefreshToken = await localStorageService.GetItemAsync<string>("refreshToken");

            var user1 = await userService.RefreshTokenAsync(refreshRequest);
            await localStorageService.SetItemAsync("accessToken", user1.AccessToken);

            authorList = await bookStoresService.GetAllAsync("authors/");
        }

        StateHasChanged();
    }

    private async Task SaveAuthor()
    {
        if (author.AuthorId == 0)
            await bookStoresService.SaveAsync("authors/", author);
        else
            await bookStoresService.UpdateAsync("authors/", author.AuthorId, author);

        await LoadAuthors();

        Result = true;
        IsVisible = true;

        var firstName = author.FirstName;
        var lastName = author.LastName;

        RecordName = firstName + " " + lastName;

        author = new Author();

        //await JSRuntime.InvokeVoidAsync("saveMessage", firstName, lastName);
        await JSRuntime.InvokeVoidAsync("setFocusOnElement", firstNameTextBox);
    }

    private async Task DeleteAuthor(int authorId)
    {
        await bookStoresService.DeleteAsync("authors/", authorId);
        await LoadAuthors();

        //throw new Exception("DeleteAuthor");
    }

    private void EditAuthor(Author argAuthor)
    {
        author = argAuthor;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService localStorageService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserService userService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBookStoresService<Author> bookStoresService { get; set; }
    }
}
#pragma warning restore 1591
