(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Colors.fs

    Title       : COLORS
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Colors.
                  Fornisce una lista di Colors out-of-the-box
                  accessibili tramite etichetta.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Colors =

    open Color

    let private colors = [|
        "INDIANRED",            (205, 092, 092), ("CD", "5C", "5C")
        "LIGHTCORAL",           (240, 128, 128), ("F0", "80", "80")
        "SALMON",               (250, 128, 114), ("FA", "80", "72")
        "DARKSALMON",           (233, 150, 122), ("E9", "96", "7A")
        "CRIMSON",              (220, 020, 060), ("DC", "14", "3C")
        "RED",                  (255, 000, 000), ("FF", "00", "00")
        "FIREBRICK",            (178, 034, 034), ("B2", "22", "22")
        "DARKRED",              (139, 000, 000), ("8B", "00", "00")
        "PINK",                 (255, 192, 203), ("FF", "C0", "CB")
        "LIGHTPINK",            (255, 182, 193), ("FF", "B6", "C1")
        "HOTPINK",              (255, 105, 180), ("FF", "69", "B4")
        "DEEPPINK",             (255, 020, 147), ("FF", "14", "93")
        "MEDIUMVIOLETRED",      (199, 021, 133), ("C7", "15", "85")
        "PALEVIOLETRED",        (219, 112, 147), ("DB", "70", "93")
        "LIGHTSALMON",          (255, 160, 122), ("FF", "A0", "7A")
        "CORAL",                (255, 127, 080), ("FF", "7F", "50")
        "TOMATO",               (255, 099, 071), ("FF", "63", "47")
        "ORANGERED",            (255, 069, 000), ("FF", "45", "00")
        "DARKORANGE",           (255, 140, 000), ("FF", "8C", "00")
        "ORANGE",               (255, 165, 000), ("FF", "A5", "00")
        "GOLD",                 (255, 215, 000), ("FF", "D7", "00")
        "YELLOW",               (255, 255, 000), ("FF", "FF", "00")
        "LIGHTYELLOW",          (255, 255, 224), ("FF", "FF", "E0")
        "LEMONCHIFFON",         (255, 250, 205), ("FF", "FA", "CD")
        "LIGHTGOLDENRODYELLOW", (250, 250, 210), ("FA", "FA", "D2")
        "PAPAYAWHIP",           (255, 239, 213), ("FF", "EF", "D5")
        "MOCCASIN",             (255, 228, 181), ("FF", "EF", "B5")
        "PEACHPUFF",            (255, 218, 185), ("FF", "DA", "B9")
        "PALEGOLDENROD",        (238, 232, 170), ("EE", "E8", "AA")
        "KHAKI",                (240, 230, 140), ("F0", "E6", "8C")
        "DARKKHAKI",            (189, 183, 107), ("BD", "B7", "6B")
        "LAVENDER",             (230, 230, 250), ("E6", "E6", "FA")
        "THISTLE",              (216, 191, 216), ("D8", "BF", "D8")
        "PLUM",                 (221, 160, 221), ("DD", "A0", "DD")
        "VIOLET",               (238, 130, 238), ("EE", "82", "EE")
        "ORCHID",               (218, 112, 214), ("DA", "70", "D6")
        "FUCHSIA",              (255, 000, 255), ("FF", "00", "FF")
        "MAGENTA",              (255, 000, 255), ("FF", "00", "FF")
        "MEDIUMORCHID",         (186, 085, 211), ("BA", "55", "D3")
        "MEDIUMPURPLE",         (147, 112, 219), ("93", "70", "DB")
        "REBECCAPURPLE",        (102, 051, 153), ("66", "33", "99")
        "BLUEVIOLET",           (138, 043, 226), ("8A", "2B", "E2")
        "DARKVIOLET",           (148, 000, 211), ("94", "00", "D3")
        "DARKORCHID",           (153, 050, 204), ("99", "32", "CC")
        "DARKMAGENTA",          (139, 000, 139), ("8B", "00", "8B")
        "PURPLE",               (128, 000, 128), ("80", "00", "80")
        "INDIGO",               (075, 000, 130), ("4B", "00", "82")
        "SLATEBLUE",            (106, 090, 205), ("6A", "5A", "CD")
        "DARKSLATEBLUE",        (072, 061, 139), ("48", "3D", "8B")
        "MEDIUMSLATEBLUE",      (123, 104, 238), ("7B", "68", "EE")
        "GREENYELLOW",          (173, 255, 047), ("AD", "FF", "2F")
        "CHARTREUSE",           (127, 255, 000), ("7F", "FF", "00")
        "LAWNGREEN",            (124, 252, 000), ("7C", "FC", "00")
        "LIME",                 (000, 255, 000), ("00", "FF", "00")
        "LIMEGREEN",            (050, 205, 050), ("32", "CD", "32")
        "PALEGREEN",            (152, 251, 152), ("98", "FB", "98")
        "LIGHTGREEN",           (144, 238, 144), ("90", "EE", "90")
        "MEDIUMSPRINGGREEN",    (000, 250, 154), ("00", "FA", "9A")
        "SPRINGGREEN",          (000, 255, 127), ("00", "FF", "7F")
        "MEDIUMSEAGREEN",       (060, 179, 113), ("3C", "B3", "71")
        "SEAGREEN",             (046, 139, 087), ("2E", "8B", "57")
        "FORESTGREEN",          (034, 139, 034), ("22", "8B", "22")
        "GREEN",                (000, 128, 000), ("00", "80", "00")
        "DARKGREEN",            (000, 100, 000), ("00", "64", "00")
        "YELLOWGREEN",          (154, 205, 050), ("9A", "CD", "32")
        "OLIVEDRAB",            (107, 142, 035), ("6B", "8E", "23")
        "OLIVE",                (128, 128, 000), ("80", "80", "00")
        "DARKOLIVEGREEN",       (085, 107, 047), ("55", "6B", "2F")
        "MEDIUMAQUAMARINE",     (102, 205, 170), ("66", "CD", "AA")
        "DARKSEAGREEN",         (143, 188, 139), ("8F", "BC", "8B")
        "LIGHTSEAGREEN",        (032, 178, 170), ("20", "B2", "AA")
        "DARKCYAN",             (000, 139, 139), ("00", "8B", "8B")
        "TEAL",                 (000, 128, 128), ("00", "80", "80")
        "AQUA",                 (000, 255, 255), ("00", "FF", "FF")
        "CYAN",                 (000, 255, 255), ("00", "FF", "FF")
        "LIGHTCYAN",            (224, 255, 255), ("E0", "FF", "FF")
        "PALETURQUOISE",        (175, 238, 238), ("AF", "EE", "EE")
        "AQUAMARINE",           (127, 255, 212), ("7F", "FF", "D4")
        "TURQUOISE",            (064, 224, 208), ("40", "E0", "D0")
        "MEDIUMTURQUOISE",      (072, 209, 204), ("48", "D1", "CC")
        "DARKTURQUOISE",        (000, 206, 209), ("00", "CE", "D1")
        "CADETBLUE",            (095, 158, 160), ("5F", "9E", "A0")
        "STEELBLUE",            (070, 130, 180), ("46", "82", "B4")
        "LIGHTSTEELBLUE",       (176, 196, 222), ("B0", "C4", "DE")
        "POWDERBLUE",           (176, 224, 230), ("B0", "E0", "E6")
        "LIGHTBLUE",            (173, 216, 230), ("AD", "D8", "E6")
        "SKYBLUE",              (135, 206, 235), ("87", "CE", "EB")
        "LIGHTSKYBLUE",         (135, 206, 250), ("87", "CE", "FA")
        "DEEPSKYBLUE",          (000, 191, 255), ("00", "BF", "FF")
        "DODGERBLUE",           (030, 144, 255), ("1E", "90", "FF")
        "CORNFLOWERBLUE",       (100, 149, 237), ("64", "95", "ED")
        "ROYALBLUE",            (065, 105, 225), ("41", "69", "E1")
        "BLUE",                 (000, 000, 255), ("00", "00", "FF")
        "MEDIUMBLUE",           (000, 000, 205), ("00", "00", "CD")
        "DARKBLUE",             (000, 000, 139), ("00", "00", "8B")
        "NAVY",                 (000, 000, 128), ("00", "00", "80")
        "MIDNIGHTBLUE",         (025, 025, 112), ("19", "19", "70")
        "CORNSILK",             (255, 248, 220), ("FF", "F8", "DC")
        "BLANCHEDALMOND",       (255, 235, 205), ("FF", "EB", "CD")
        "BISQUE",               (255, 228, 196), ("FF", "E4", "C4")
        "NAVAJOWHITE",          (255, 222, 173), ("FF", "DE", "AD")
        "WHEAT",                (245, 222, 179), ("F5", "DE", "B3")
        "BURLYWOOD",            (222, 184, 135), ("DE", "B8", "87")
        "TAN",                  (210, 180, 140), ("D2", "B4", "8C")
        "ROSYBROWN",            (188, 143, 143), ("BC", "8F", "8F")
        "SANDYBROWN",           (244, 164, 096), ("F4", "A4", "60")
        "GOLDENROD",            (218, 165, 032), ("DA", "A5", "20")
        "DARKGOLDENROD",        (184, 134, 011), ("B8", "86", "0B")
        "PERU",                 (205, 133, 063), ("CD", "85", "3F")
        "CHOCOLATE",            (210, 105, 030), ("D2", "69", "1E")
        "SADDLEBROWN",          (139, 069, 019), ("8B", "45", "13")
        "SIENNA",               (160, 082, 045), ("A0", "52", "2D")
        "BROWN",                (165, 042, 042), ("A5", "2A", "2A")
        "MAROON",               (128, 000, 000), ("80", "00", "00")
        "WHITE",                (255, 255, 255), ("FF", "FF", "FF")
        "SNOW",                 (255, 250, 250), ("FF", "FA", "FA")
        "HONEYDEW",             (240, 255, 240), ("F0", "FF", "F0")
        "MINTCREAM",            (245, 255, 250), ("F5", "FF", "FA")
        "AZURE",                (240, 255, 255), ("F0", "FF", "FF")
        "ALICEBLUE",            (240, 248, 255), ("F0", "F8", "FF")
        "GHOSTWHITE",           (248, 248, 255), ("F8", "F8", "FF")
        "WHITESMOKE",           (245, 245, 245), ("F5", "F5", "F5")
        "SEASHELL",             (255, 245, 238), ("FF", "F5", "EE")
        "BEIGE",                (245, 245, 220), ("F5", "F5", "DC")
        "OLDLACE",              (253, 245, 230), ("FD", "F5", "E6")
        "FLORALWHITE",          (255, 250, 240), ("FF", "FA", "F0")
        "IVORY",                (255, 255, 240), ("FF", "FF", "F0")
        "ANTIQUEWHITE",         (250, 235, 215), ("FA", "EB", "D7")
        "LINEN",                (250, 240, 230), ("FA", "F0", "E6")
        "LAVENDERBLUSH",        (255, 240, 245), ("FF", "F0", "F5")
        "MISTYROSE",            (255, 228, 225), ("FF", "E4", "E1")
        "GAINSBORO",            (220, 220, 220), ("DC", "DC", "DC")
        "LIGHTGRAY",            (211, 211, 211), ("D3", "D3", "D3")
        "SILVER",               (192, 192, 192), ("C0", "C0", "C0")
        "DARKGRAY",             (169, 169, 169), ("A9", "A9", "A9")
        "GRAY",                 (128, 128, 128), ("80", "80", "80")
        "DIMGRAY",              (105, 105, 105), ("69", "69", "69")
        "LIGHTSLATEGRAY",       (119, 136, 153), ("77", "88", "99")
        "SLATEGRAY",            (112, 128, 144), ("70", "80", "90")
        "DARKSLATEGRAY",        (047, 079, 079), ("2F", "4F", "4F")
        "BLACK",                (000, 000, 000), ("00", "00", "00")
    |]

    module RGB =

        type Format =
            | RGB
            | RGBColor

        let tryGet (color : string) format =
            let color = color.ToUpperInvariant()

            colors
            |> Array.tryFind (fun (name, _, _) ->
                name = color
            )
            |> Option.map (fun (_, rgb, _) ->
                let red, green, blue = rgb

                match format with
                | RGB -> Color.RGB (red, green, blue)
                | RGBColor ->
                    Color.RGBColor ({
                        red   = red
                        green = green
                        blue  = blue
                    })
                | format -> failwithf "%A: Not yet implemented!" format
            )

        let get color format =
            match tryGet color format with
            | Some color -> color
            | None -> failwithf "%s: Not found!" color

        let exists color =
            match tryGet color RGB with
            | Some _ -> true
            | None -> false

    module HEX =

        type Format =
            | HEX
            | HEXColor

        let tryGet (color : string) format =
            let color = color.ToUpperInvariant()

            colors
            |> Array.tryFind (fun (name, _, _) ->
                name = color
            )
            |> Option.map (fun (_, _, hex) ->
                let red, green, blue = hex

                match format with
                | HEX -> Color.HEX (red, green, blue)
                | HEXColor ->
                    Color.HEXColor ({
                        red   = red
                        green = green
                        blue  = blue
                    })
                | format -> failwithf "%A: Not yet implemented!" format
            )

        let get color format =
            match tryGet color format with
            | Some color -> color
            | None -> failwithf "%s: Not found!" color

        let exists color =
            match tryGet color HEX with
            | Some _ -> true
            | None -> false
