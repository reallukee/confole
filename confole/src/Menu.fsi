(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Menu.fsi

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

    val draw : menu : Menu -> unit

    val selectable : menu : Menu -> bool

    val nextItem     : menu : Menu -> Menu
    val previousItem : menu : Menu -> Menu
    val topItem      : menu : Menu -> Menu
    val bottomItem   : menu : Menu -> Menu

    val call : menu : Menu -> Menu
