# WaitForIt

`WaitForIt` is a templated Blazor component that removes repeated `try/catch/loading` UI boilerplate from pages.

```razor
<WaitForIt Operation="@LoadData" Context="data">
    <Loading>Loading...</Loading>
    <Loaded>@data.Name</Loaded>
    <Error Context="ex">@ex.Message</Error>
</WaitForIt>
```
