(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Menu.fs

    Title       : MENU
    Description : Menu

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open System

open Color
open Position

open Rule
open Cursor
open Action
open Format

module Menu =
    type MenuItemStyle = {
        foregroundColor         : Color option
        backgroundColor         : Color option
        currentForegroundColor  : Color option
        currentBackgroundColor  : Color option
        selectedForegroundColor : Color option
        selectedBackgroundColor : Color option
        disabledForegroundColor : Color option
        disabledBackgroundColor : Color option
    }

    type MenuItemType =
        | Value     of string
        | Separator

    type MenuItem = {
        itemType : MenuItemType
        enable   : bool
        visible  : bool
        style    : MenuItemStyle option
    }

    type Menu = {
        col          : int
        row          : int
        items        : MenuItem list
        currentItem  : int
        selectedItem : int
        style        : MenuItemStyle option
    }



    let private defaultStyle = {
        foregroundColor         = Some (RGB (255, 255, 255))
        backgroundColor         = Some (RGB (0,   0,   0  ))
        currentForegroundColor  = Some (RGB (0,   255, 255))
        currentBackgroundColor  = Some (RGB (0,   0,   255))
        selectedForegroundColor = Some (RGB (0,   0,   255))
        selectedBackgroundColor = Some (RGB (0,   255, 255))
        disabledForegroundColor = Some (RGB (128, 128, 128))
        disabledBackgroundColor = Some (RGB (64,  64,  64 ))
    }

    let private resolveStyle menu index =
        let item = List.item index menu.items

        let resolve getter defaultValue =
            let itemValue = Option.bind getter item.style

            let menuValue = Option.bind getter menu.style

            match itemValue, menuValue, defaultValue with
            | Some color, _,          _     -> Some color
            | None,       Some color, _     -> Some color
            | None,       None,       color -> color

        {
            foregroundColor         = resolve (fun style -> style.foregroundColor)         defaultStyle.foregroundColor
            backgroundColor         = resolve (fun style -> style.backgroundColor)         defaultStyle.backgroundColor
            currentForegroundColor  = resolve (fun style -> style.currentForegroundColor)  defaultStyle.currentForegroundColor
            currentBackgroundColor  = resolve (fun style -> style.currentBackgroundColor)  defaultStyle.currentBackgroundColor
            selectedForegroundColor = resolve (fun style -> style.selectedForegroundColor) defaultStyle.selectedForegroundColor
            selectedBackgroundColor = resolve (fun style -> style.selectedBackgroundColor) defaultStyle.selectedBackgroundColor
            disabledForegroundColor = resolve (fun style -> style.disabledForegroundColor) defaultStyle.disabledForegroundColor
            disabledBackgroundColor = resolve (fun style -> style.disabledBackgroundColor) defaultStyle.disabledBackgroundColor
        }

    let private format menu index =
        let style = resolveStyle menu index

        let item = List.item index menu.items

        match item.enable, index = menu.currentItem, index = menu.selectedItem with
        | false, _, _ ->
            builder {
                foregroundColor (Option.defaultValue (RGB (128, 128, 128)) style.disabledForegroundColor)
                backgroundColor (Option.defaultValue (RGB (64,  64,  64 )) style.disabledBackgroundColor)
            }
        | true, true, false ->
            builder {
                foregroundColor (Option.defaultValue (RGB (0, 0,   255)) style.selectedForegroundColor)
                backgroundColor (Option.defaultValue (RGB (0, 255, 255)) style.selectedBackgroundColor)
            }
        | true, _, true ->
            builder {
                foregroundColor (Option.defaultValue (RGB (0, 255, 255)) style.currentForegroundColor)
                backgroundColor (Option.defaultValue (RGB (0, 0,   255)) style.currentBackgroundColor)
            }
        | true, false, false ->
            builder {
                foregroundColor (Option.defaultValue (RGB (255, 255, 255)) style.foregroundColor)
                backgroundColor (Option.defaultValue (RGB (0,   0,   0  )) style.backgroundColor)
            }

    let draw menu =
        let lengths =
            menu.items
            |> List.choose (fun item ->
                match item.itemType with
                | Value value -> Some (String.length value)
                | Separator -> None
            )

        let gap =
            if List.isEmpty lengths then
                failwith "Error!"
            else
                List.max lengths

        menu.items
        |> List.iteri (fun index item ->
            doMove (ColRow (menu.col, menu.row + index))

            let item =
                match item.itemType with
                | Value value -> value.PadRight(gap)
                | Separator -> String('-', gap)

            let format = format menu index

            applyAll item format
        )



    let selectable menu =
        menu.items
        |> List.exists (fun item ->
            match item with
            | { itemType = Value _; enable = true } -> true
            | _ -> false
        )

    let private incrementCurrentItem menu =
        let selectable = selectable menu

        if not selectable then
            ()

        let rec loop currentItem =
            let next =
                if currentItem + 1 > List.length menu.items - 1 then
                    0
                else
                    currentItem + 1

            match List.item next menu.items with
            | { itemType = Value _; enable = true } -> next
            | _ -> loop next

        loop menu.currentItem

    let private decrementCurrentItem menu =
        let selectable = selectable menu

        if not selectable then
            ()

        let rec loop currentItem =
            let previous =
                if currentItem - 1 < 0 then
                    List.length menu.items - 1
                else
                    currentItem - 1

            match List.item previous menu.items with
            | { itemType = Value _; enable = true } -> previous
            | _ -> loop previous

        loop menu.currentItem

    let private currentItemToTop menu =
        let rec loop index =
            if index > List.length menu.items - 1 then
                None
            else
                match List.item index menu.items with
                | { itemType = Value _; enable = true } -> Some index
                | _ -> loop (index + 1)

        loop 0

    let private currentItemToBottom menu =
        let rec loop index =
            if index < 0 then
                None
            else
                match List.item index menu.items with
                | { itemType = Value _; enable = true } -> Some index
                | _ -> loop (index - 1)

        loop (List.length menu.items - 1)



    let nextItem menu =
        let next = incrementCurrentItem menu

        { menu with
            currentItem  = next
            selectedItem = next
        }

    let previousItem menu =
        let previous = decrementCurrentItem menu

        { menu with
            currentItem  = previous
            selectedItem = previous
        }

    let topItem menu =
        let top = currentItemToTop menu

        match top with
        | Some index ->
            { menu with
                currentItem  = index
                selectedItem = index
            }
        | None -> menu

    let bottomItem menu =
        let bottom = currentItemToBottom menu

        match bottom with
        | Some index ->
            { menu with
                currentItem  = index
                selectedItem = index
            }
        | None -> menu



    let call menu =
        doHideCursor ()

        let rec loop menu =
            draw menu

            doMove (ColRow (0, 0))

            let key = Console.ReadKey(true)

            let menu, exit =
                match key.Key with
                | ConsoleKey.W | ConsoleKey.UpArrow   -> previousItem menu, false
                | ConsoleKey.S | ConsoleKey.DownArrow -> nextItem     menu, false
                | ConsoleKey.T | ConsoleKey.PageUp    -> topItem      menu, false
                | ConsoleKey.B | ConsoleKey.PageDown  -> bottomItem   menu, false
                | ConsoleKey.X | ConsoleKey.Enter     -> menu,              true
                | _ -> menu, false

            if exit then
                menu
            else
                loop menu

        let menu = loop menu

        doShowCursor ()

        menu
