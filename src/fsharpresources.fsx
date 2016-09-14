#r "../node_modules/fable-core/Fable.Core.dll"
#load "./sources.fsx"

open Fable.Core
open Fable.Import
open Sources

Node.require.Invoke("core-js") |> ignore

let createElement = Browser.document.createElement

let setInnerHtml value (el:Browser.HTMLElement) =
    el.innerHTML <- value
    el

let appendChild el (parent:Browser.Node) =
    parent.appendChild el |> ignore
    parent

let setAttribute name value (el:Browser.HTMLElement) =
    el.setAttribute(name, value)
    el

let rec cleanNode (el:Browser.Node) =
    while not(isNull el.firstChild) do
        cleanNode el.firstChild
        el.removeChild(el.firstChild) |> ignore

let renderMedia mediaType =
    let iconName = 
        match mediaType with
        | Blog -> "pencil"
        | Documentation -> "document"
        | ExampleCode -> "code"
        | Slides -> "slides"
        | Tutorial -> "gear"
        | Twitter -> "twitter"
        | Video -> "video"

    let svgElement = 
        iconName 
        |> sprintf "%s-icon" 
        |> Browser.document.getElementById
    
    createElement "div"
    |> setAttribute "class" "media-icon"
    |> setInnerHtml svgElement.innerHTML

let renderTopics (topics:Topic list) =
    let convert t = 
        match t with
        | Architecture -> "Architecture"
        | Desktop -> "Desktop"
        | Introductory -> "Introductory"
        | Tooling -> "Tooling"
        | Web -> "Web"

    let stringTopics =
        match topics with 
        | [] -> ""
        | _ ->
            topics 
            |> List.map convert
            |> List.reduce (fun s1 s2 -> sprintf "%s, %s" s1 s2)
    
    createElement "div" 
    |> setAttribute "class" "item-topic"
    |> setInnerHtml stringTopics

let renderLink name url =
    createElement "div"
    |> setAttribute "class" "item-link"
    |> appendChild (createElement "a"
        |> setInnerHtml name
        |> setAttribute "href" url
        |> setAttribute "target" "_blank")

let renderDescription text =
    createElement "div"
    |> setAttribute "class" "item-desc"
    |> setInnerHtml text

let renderItem item =
    createElement "li"
    |> setAttribute "class" "item-box"
    |> appendChild (renderMedia item.Type)
    |> appendChild (createElement "div"
        |> setAttribute "class" "item-details"
        |> appendChild (renderLink item.Name item.Url)
        |> appendChild (renderDescription item.Description)
        |> appendChild (renderTopics item.Topics))

let renderTopicHeader topic =
    let name = topicToString topic
    createElement "li"
    |> setAttribute "class" "item-group-header"
    |> setInnerHtml name :> Browser.Node

let renderMediaHeader media =
    createElement "li"
    |> setAttribute "class" "item-group-header"
    |> setInnerHtml media :> Browser.Node

let render sort =
    let sortItemsByName = List.sortBy (fun s -> s.Name)
    let listRoot = Browser.document.getElementById "item-list"
    cleanNode listRoot

    let createNodes =
        match sort with
        | "title" -> 
            sortItemsByName >> List.map renderItem
        | "topic" ->
            (fun sources -> 
                [Architecture; Desktop; Introductory; Tooling; Web]
                |> List.map (fun t -> 
                    t, sources |> List.filter (fun s -> List.contains t s.Topics) |> sortItemsByName))
            >> List.collect (fun (g, s) -> renderTopicHeader g :: List.map renderItem s)
        | "type" -> 
            List.groupBy (fun s -> mediaToString s.Type) // unable to do equality with union type here... not sure why
            >> List.sortBy (fun (g, xs) -> g)
            >> List.map (fun (g, xs) -> (g, xs |> List.sortBy (fun x -> x.Name)))
            >> List.collect (fun (g, xs) -> renderMediaHeader g :: List.map renderItem xs)
        | _ -> failwith "Unknown sort type."

    sourceList |> createNodes |> List.iter (listRoot.appendChild >> ignore)

let changeSort (e:Browser.Event) =
    e.srcElement.getAttribute "value" |> render

let init _ =
    render "title"

    ["sort1"; "sort2"; "sort3"]
    |> List.map Browser.document.getElementById
    |> List.iter (fun el -> el.addEventListener ("change", unbox changeSort, false))

Browser.window.addEventListener ("DOMContentLoaded", unbox init, false)