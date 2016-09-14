type Media =
    | Blog
    | Documentation
    | ExampleCode
    | Slides
    | Tutorial
    | Twitter
    | Video

type Topic =
    | Architecture
    | Desktop
    | Introductory
    | Tooling
    | Web

let topicToString t =
    match t with 
    | Architecture -> "Architecture / Functional Style"
    | Desktop -> "Desktop Applications"
    | Introductory -> "Introductory Topics"
    | Tooling -> "Tooling"
    | Web -> "Web Applications"

let mediaToString m =
    match m with 
    | Blog -> "Blog"
    | Documentation -> "Library Documentation"
    | ExampleCode -> "Example Code/Projects"
    | Slides -> "Presentation Slides"
    | Tutorial -> "Tutorials"
    | Twitter -> "Twitter Accounts"
    | Video -> "Videos"

type SourceItem = { Name:string; Url:string; Description:string; Type:Media; Topics:Topic list }

let sourceList = [
    {   Name="Thinking Functionally" 
        Url="http://fsharpforfunandprofit.com/posts/thinking-functionally-intro/"
        Description="The 'hows' and 'whys' of functional programming, and where it differs from object oriented programming."
        Type=Blog
        Topics= [Introductory] }
    {   Name="Understanding F# Types"
        Url="http://fsharpforfunandprofit.com/series/understanding-fsharp-types.html"
        Description="Overview of the F# type system, and using .NET types in F#."
        Type=Blog
        Topics=[Introductory]}
    {   Name="Getting started with Fable and Webpack"
        Url="http://kcieslak.io/Getting-Started-with-Fable-and-Webpack"
        Description="Setting up a simple Fable project that uses webpack to combine the resultings javascript modules."
        Type=Tutorial
        Topics=[Web]}
    {   Name="Ionide"
        Url="https://ionide.io"
        Description="Cross-platform Atom/VSCode plugins for F# development. Great alternative to Visual Studio."
        Type=Documentation
        Topics=[Tooling]}
    {   Name="Suave"
        Url="https://suave.io"
        Description="Simple web development library and server designed for F#."
        Type=Documentation
        Topics=[Web]}
    {   Name="Paket"
        Url="https://fsprojects.github.io/Paket/"
        Description="Package manager that can add packages from NuGet, GitHub, and HTTP."
        Type=Documentation
        Topics=[Tooling]}
    {   Name="F# Snippets"
        Url="http://www.fssnip.net/"
        Description="Collection of small code examples."
        Type=ExampleCode
        Topics=[Introductory]}
    {   Name="Functional Concurrence with the Actor Model"
        Url="https://www.youtube.com/watch?v=AMjcjXIMzmA"
        Description="Demonstration of how to apply the Actor Model to an F# game." 
        Type=Video
        Topics=[Architecture]}
    {   Name="Suave Music Store"
        Url="https://www.gitbook.com/book/theimowski/suave-music-store/details"
        Description="Detailed ebook on how to make an F# web application with Suave."
        Type=Tutorial
        Topics=[Web]}
    {   Name="Tomas Petricek"
        Url="https://twitter.com/tomaspetricek"
        Description="Author and speaker."
        Type=Twitter
        Topics=[]}
    {   Name="Alfonso Garcia-Caro"
        Url="https://twitter.com/alfonsogcnunez"
        Description="Creator of Fable compiler."
        Type=Twitter
        Topics=[]}
    {   Name="Functional Architecture: the Pit of Success"
        Url="https://skillsmatter.com/skillscasts/7355-functional-architecture-the-pit-of-success"
        Description="Presentation by Mark Seeman on how functional programming naturally leads to following best practices."
        Type=Video
        Topics=[Architecture]}
    {   Name="Reed Copsey"
        Url="https://twitter.com/ReedCopsey"
        Description="Executive Director of F# Foundation."
        Type=Twitter
        Topics=[]}
    {   Name="Suave Bootstrap Project"
        Url="https://github.com/mrange/mysuavebootstrap"
        Description="Project bootstrap for a Suave web app with FAKE and Azure deployment."
        Type=ExampleCode
        Topics=[Web; Tooling]}
    {   Name="Fable"
        Url="https://fable-compiler.github.io/docs.html"
        Description="F# to JavaScript compiler, compatible with Node or browser code."
        Type=Documentation
        Topics=[Web]}
    {   Name="Types + Properties = Software"
        Url="https://channel9.msdn.com/Events/FSharp-Events/fsharpConf-2016/Types-Properties-Software"
        Description="Mark Seeman shows how to use declarative types in F# to design your program, and make illegal states unrepresentable."
        Type=Video
        Topics=[Introductory; Architecture]}
    {   Name="Railway oriented programming: Error handling in functional languages"
        Url="https://vimeo.com/113707214"
        Description="Scott Wlaschin explains how to handle program errors in a functional style."
        Type=Video
        Topics=[Introductory; Architecture]}
    {   Name="FAKE"
        Url="http://fsharp.github.io/FAKE/"
        Description="A build task system created with F#."
        Type=Documentation
        Topics=[Tooling]}
    {   Name="F# Power Tools"
        Url="https://fsprojects.github.io/VisualFSharpPowerTools/"
        Description="Visual Studio extension that adds better syntax highlighting, code navigation, and context menus for F# source code files."
        Type=Documentation
        Topics=[Tooling]}
    {   Name="My Share"
        Url="https://github.com/mastoj/my-share"
        Description="Example web app for an expense system. Built with Suave and uses FAKE to build and run the F# code."
        Type=ExampleCode
        Topics=[Web]}
    {   Name="Try F#"
        Url="http://www.tryfsharp.org/Learn"
        Description="Interactive, online tutorials that take you from your first lines of F# code to writing complicated functions."
        Type=Tutorial
        Topics=[Introductory]}
    {   Name="WebSharper"
        Url="http://websharper.com/docs"
        Description="F# to JavaScript web framework. Provides functionality for both server side and client side F# code."
        Type=Documentation
        Topics=[Web]}
    {   Name="Forge"
        Url="http://fsprojects.github.io/Forge/"
        Description="Command-line tool for F# project setup, templates, running common functions like running FAKE or starting a Suave server."
        Type=Documentation
        Topics=[Tooling]}
    {   Name="Don Syme"
        Url="https://twitter.com/dsyme"
        Description="Principal designer of the F# language. Works for Microsoft Reserach designing F#."
        Type=Twitter
        Topics=[]}
    {   Name="Krzysztof Cieslak"
        Url="https://twitter.com/k_cieslak"
        Description="Lead developer of Ionide."
        Type=Twitter
        Topics=[]}
    {   Name="F# Web Application Templates"
        Url="https://visualstudiogallery.msdn.microsoft.com/39ae8dec-d11a-4ac9-974e-be0fdadec71b"
        Description="Visual Studio project templates for ASP.NET MVC 5 and WebAPI apps using F#."
        Type=Documentation
        Topics=[Web]}
    {   Name="F# WPF and the XAML type provider"
        Url="http://stevenpemberton.net/blog/2015/03/29/FSharp-WPF-and-the-XAML-type-provider/"
        Description="Tutorial on how to use FsXAML to create WPF apps with F#."
        Type=Tutorial
        Topics=[Desktop]}
    {   Name="Low Risk Ways to Use F# at Work"
        Url="https://fsharpforfunandprofit.com/series/low-risk-ways-to-use-fsharp-at-work.html"
        Description="Scott Wlaschin explores low-risk, high-impact areas where you can start adopting F# at your day job."
        Type=Blog
        Topics=[Introductory]}
    {   Name="A Recipe for a Functional App"
        Url="https://fsharpforfunandprofit.com/series/a-recipe-for-a-functional-app.html"
        Description="You can't organize an F# app like a C# app. This blog series shows how to organize your app correctly for functional programming."
        Type=Blog
        Topics=[Architecture]}
]