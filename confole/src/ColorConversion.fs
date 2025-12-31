(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : ColorConversion.fs

    Title       : COLOR CONVERSION
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo
                  ColorConversion.
                  Questo modulo parla da solo! Dai si
                  capisce cosa fa!!!
                  MIAO! MIAO! MIAO!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module ColorConversion =

    open System

    open Color

    (*
        ----------
        IMPORTANTE
        ----------

        Ecco a te, umile viaggiatore del Web, che per qualche
        oscuro motivo sei finito nel mio repository.

        Questi sono messaggi per me, ma anche per te, forse?

        L'attuale implementazione di questo modulo presenta
        delle criticità NOTE.

        1) Filosofia Imperativa.
           Confole, all'interno di Reallukee.Confole, cerca,
           per quanto possibile, di applicare un'implementazione
           functional-first. Tutto questo però senza sacrificare
           versatilità ed efficienza sintattica.

           Terminato il pippone filosofico. Questo modulo
           FUNZIONA (a quanto pare, il test xUnit non è
           ancora ultimato), MAAA, e dico MAAA, bisognerebbe
           rivedere sia la firma che l'implementazione delle
           funzioni, cercando qualcosa di più IDIOMATICO.
           Bella parola, vero?

        2) Assenza di controlli.
           Sì, mancano i controlli.
           Fine. Collegandosi al punto 1), bisognerebbe
           gestire al meglio questa componente. Metodi 'tryGet'
           e 'get'? Eccezioni? Eccezioni custom?
           Insomma, da vedere.

        Si dà per scontato che TU, sì, dico proprio TU,
        o anche IO in realtà, usi l'API non fornendo casi limite.

        VERIFICARE IL CORRETTO FUNZIONAMENTO DELL'API!

        L'autore pigro di codesta libreria.
    *)

    let hexToRGB hex =
        let red, green, blue = hex

        let parse hex =
            try
                Convert.ToInt32(hex, 16)
            with
            | :? FormatException ->
                failwithf "'%s' Invalid HEX value!" hex

        let red'   = parse red
        let green' = parse green
        let blue'  = parse blue

        red', green', blue'

    let rgbToHEX rgb =
        let red, green, blue = rgb

        let red'   = sprintf "%02X" red
        let green' = sprintf "%02X" green
        let blue'  = sprintf "%02X" blue

        red', green', blue'

    let hexColorToRGBColor (hexColor : HEXColor) : RGBColor =
        let parse hex =
            try
                Convert.ToInt32(hex, 16)
            with
            | :? FormatException ->
                failwithf "'%s' Invalid HEX value!" hex

        let red, green, blue = hexColorToHEX hexColor

        let red'   = parse red
        let green' = parse green
        let blue'  = parse blue

        {
            red   = red'
            green = green'
            blue  = blue'
        }

    let rgbColorToHEXColor (rgbColor : RGBColor) : HEXColor =
        let red, green, blue = rgbColorToRGB rgbColor

        let red'   = sprintf "%02X" red
        let green' = sprintf "%02X" green
        let blue'  = sprintf "%02X" blue

        {
            red   = red'
            green = green'
            blue  = blue'
        }



    let private baseColors = [|
        (000, 000, 000), ("00", "00", "00") // 00   Nero
        (205, 000, 000), ("CD", "00", "00") // 01   Rosso
        (000, 205, 000), ("00", "CD", "00") // 02   Verde
        (205, 205, 000), ("CD", "CD", "00") // 03   Giallo
        (000, 000, 238), ("00", "00", "EE") // 04   Blu
        (205, 000, 205), ("CD", "00", "CD") // 05   Magenta
        (000, 205, 205), ("00", "CD", "CD") // 06   Ciano
        (229, 229, 229), ("E5", "E5", "E5") // 07   Bianco
        (127, 127, 127), ("7F", "7F", "7F") // 08   Nero Brillante
        (255, 000, 000), ("FF", "00", "00") // 09   Rosso Brillante
        (000, 255, 000), ("00", "FF", "00") // 10   Verde Brillante
        (255, 255, 000), ("FF", "FF", "00") // 11   Giallo Brillante
        (092, 092, 255), ("5C", "5C", "FF") // 12   Blu Brillante
        (255, 000, 255), ("FF", "00", "FF") // 13   Magenta Brillante
        (000, 255, 255), ("00", "FF", "FF") // 14   Ciano Brillante
        (255, 255, 255), ("FF", "FF", "FF") // 15   Bianco Brillante
    |]

    let xTermToRGB id =
        match id with
        | id when id >= 0 && id <= 15 ->
            let (red, green, blue), _ = baseColors.[id]

            red, green, blue

        | id when id >= 16 && id <= 231 ->
            let id = id - 16

            let red'   = id / 36
            let green' = id / 6 % 6
            let blue'  = id % 6

            let scale = [|
                0; 95; 135; 175; 215; 255
            |]

            scale[red'], scale[green'], scale[blue']

        | id when id >= 232 && id <= 255 ->
            let gray = 8 + (id - 232) * 10

            gray, gray, gray

        | id -> failwithf "%A: Invalid id!" id

    let xTermToHEX id =
        id
        |> xTermToRGB
        |> rgbToHEX

    let xTermColorToRGBColor (xTermColor) : RGBColor =
        let id = xTermColorToXTerm xTermColor

        match id with
        | id when id >= 0 && id <= 15 ->
            let (red, green, blue), _ = baseColors.[id]

            {
                red   = red
                green = green
                blue  = blue
            }

        | id when id >= 16 && id <= 231 ->
            let id = id - 16

            let red'   = id / 36
            let green' = id / 6 % 6
            let blue'  = id % 6

            let scale = [|
                0; 95; 135; 175; 215; 255
            |]

            {
                red   = scale[red']
                green = scale[green']
                blue  = scale[blue']
            }

        | id when id >= 232 && id <= 255 ->
            let gray = 8 + (id - 232) * 10

            {
                red   = gray
                green = gray
                blue  = gray
            }

        | id -> failwithf "%A: Invalid id!" id

    let xTermColorToHEXColor (xTermColor) : HEXColor =
        xTermColor
        |> xTermColorToRGBColor
        |> rgbColorToHEXColor



    let rgbToXTerm rgb =
        let red, green, blue = rgb

        let distance rgb1 rgb2 =
            let red1, green1, blue1 = rgb1
            let red2, green2, blue2 = rgb2

            let redd   = red1   - red2
            let greend = green1 - green2
            let blued  = blue1  - blue2

            redd * redd + greend * greend + blued * blued

        let basei, based =
            baseColors
            |> Array.mapi (fun index (color, _) ->
                index, distance(red, green, blue) color
            )
            |> Array.minBy snd

        let cubei, cubed =
            let cubes = [|
                0; 95; 135; 175; 215; 255
            |]

            let closest value =
                cubes
                |> Array.indexed
                |> Array.minBy (fun (_, level) ->
                    abs (level - value)
                )

            let redi,   redd   = closest red
            let grenni, greend = closest green
            let bluei,  blued  = closest blue

            let index = 16 + 36 * redi + 6 * grenni + bluei
            let dist  = distance (red, green, blue) (redd, greend, blued)

            index, dist

        let grayi, grayd =
            let grays = [|
                for i in 0 .. 23 -> 8 + i * 10
            |]

            let closest () =
                grays
                |> Array.indexed
                |> Array.minBy (fun (_, gray) ->
                    distance (red, green, blue) (gray, gray, gray)
                )

            let grayi, grayd = closest ()

            let index = 232 + grayi
            let dist  = distance (red, green, blue) (grayd, grayd, grayd)

            index, dist

        let id, _ =
            [|
                // Disabilito pk a causa di problemi nel trovare il colore
                // RGB/HEX corrispondente.
                // Sostanzialmente, essendo i primi 16 colori variabili,
                // l'efficacia di questa funzione si riduce notevolmente.
                // Da rivedere!

                // basei, based
                cubei, cubed
                grayi, grayd
            |]
            |> Array.minBy snd

        id

    let hexToXTerm hex =
        hex
        |> hexToRGB
        |> rgbToXTerm

    let rgbColorToXTermColor rgbColor =
        let red, green, blue = rgbColorToRGB rgbColor

        let distance rgb1 rgb2 =
            let red1, green1, blue1 = rgb1
            let red2, green2, blue2 = rgb2

            let redd   = red1   - red2
            let greend = green1 - green2
            let blued  = blue1  - blue2

            redd * redd + greend * greend + blued * blued

        let basei, based =
            baseColors
            |> Array.mapi (fun index (color, _) ->
                index, distance(red, green, blue) color
            )
            |> Array.minBy snd

        let cubei, cubed =
            let cubes = [|
                0; 95; 135; 175; 215; 255
            |]

            let closest value =
                cubes
                |> Array.indexed
                |> Array.minBy (fun (_, level) ->
                    abs (level - value)
                )

            let redi,   redd   = closest red
            let grenni, greend = closest green
            let bluei,  blued  = closest blue

            let index = 16 + 36 * redi + 6 * grenni + bluei
            let dist  = distance (red, green, blue) (redd, greend, blued)

            index, dist

        let grayi, grayd =
            let grays = [|
                for i in 0 .. 23 -> 8 + i * 10
            |]

            let closest () =
                grays
                |> Array.indexed
                |> Array.minBy (fun (_, gray) ->
                    distance (red, green, blue) (gray, gray, gray)
                )

            let grayi, grayd = closest ()

            let index = 232 + grayi
            let dist  = distance (red, green, blue) (grayd, grayd, grayd)

            index, dist

        let id, _ =
            [|
                // Disabilito pk a causa di problemi nel trovare il colore
                // RGB/HEX corrispondente.
                // Sostanzialmente, essendo i primi 16 colori variabili,
                // l'efficacia di questa funzione si riduce notevolmente.
                // Da rivedere!

                // basei, based
                cubei, cubed
                grayi, grayd
            |]
            |> Array.minBy snd

        {
            id = id
        }

    let hexColorToXTermColor hexColor =
        hexColor
        |> hexColorToRGBColor
        |> rgbColorToXTermColor
