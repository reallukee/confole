namespace Reallukee.Confole

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main _ =
        let menu : Menu.Menu = {
            col   = 4
            row   = 2
            items = [
                {
                    itemType = Menu.Separator
                    enable   = true
                    visible  = true
                    style    = None
                }
                {
                    itemType = Menu.Value "Item 1"
                    enable   = true
                    visible  = true
                    style    = None
                }
                {
                    itemType = Menu.Value "Item 2"
                    enable   = true
                    visible  = true
                    style    = None
                }
                {
                    itemType = Menu.Value "Item 3"
                    enable   = true
                    visible  = true
                    style    = None
                }
                {
                    itemType = Menu.Separator
                    enable   = true
                    visible  = true
                    style    = None
                }
            ]
            currentItem  = 0
            selectedItem = 0
            style        = None
        }

        let menu = Menu.run menu

        0
