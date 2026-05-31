# WaitForIt

[![NuGet](https://img.shields.io/nuget/v/WaitForIt.svg)](https://www.nuget.org/packages/WaitForIt/)
[![CI](https://github.com/agriffard/WaitForIt/actions/workflows/ci.yml/badge.svg)](https://github.com/agriffard/WaitForIt/actions/workflows/ci.yml)
[![GitHub Pages](https://img.shields.io/badge/docs-github%20pages-blue)](https://agriffard.github.io/WaitForIt/)

`WaitForIt` is a Blazor component library for .NET 10.

It collapses the async `try/loading/error/loaded` boilerplate most pages rewrite.

## Install

```bash
dotnet add package WaitForIt
```

## Usage

```razor
<WaitForIt Operation="@LoadData" Context="data">
    <Loading>Loading…</Loading>
    <Loaded>@data.Name</Loaded>
    <Error Context="ex">@ex.Message</Error>
</WaitForIt>
```

## Sample app

A sample Blazor WebAssembly app is in `/samples/WaitForIt.Sample` and demonstrates both success and error states.

Run locally:

```bash
dotnet run --project samples/WaitForIt.Sample/WaitForIt.Sample.csproj
```

## Docs

Documentation source is in `/docs`, and the sample app is deployed to GitHub Pages by workflow.

## Workflows

- **CI**: restore, build, and test on pushes/PRs.
- **NuGet**: package and publish on release (`NUGET_API_KEY` required).
- **GitHub Pages**: publish sample app to pages.
