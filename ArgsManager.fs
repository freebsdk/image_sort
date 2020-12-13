namespace image_sort
open System.Collections.Generic







type ArgsManager () =

    let parseElems = List<ArgsParserElem>()    
    let dic = Dictionary<string, string>()
    
    
    
    let getParseElem (arg : string) =
        ArgsParserElem(ARGS_TYPE_REQUIRED, true, "--src") |> Some
        
    
    
    
    let rec findArgIdx (argv : string[]) (key : string) (idx : int) =
        if idx >= argv.Length then
            None
        else
            if argv.[idx] = key then
                idx |> Some
            else
                findArgIdx <| argv <| key <| idx+1
        
        
        
        
    let getArgValue (argv : string[]) (argIdx : int) =
        let arg = argv.[argIdx]
        if arg.StartsWith("\"") && arg.EndsWith("\"") then
            // Remove the double quotation marks at the front and back.
            arg.Substring(1, arg.Length-2)
        else
            arg
                
    
    
    
    member _.AddParser (parserElem : ArgsParserElem) =
        parseElems.Add(parserElem)

    
    
    
    member _.Parse(argv : string[]) =
        for elem in parseElems do
            match findArgIdx <| argv <| elem.Key <| 0 with
            | Some argIdx ->
                // Remove --
                let pureKey = elem.Key.Substring(2,elem.Key.Length-2)
                if elem.NeedVal then
                    let value = getArgValue <| argv <| argIdx+1
                    dic.Add(pureKey, value)
                else
                    dic.Add(pureKey, "")
            | None ->
                if elem.ArgsType = ARGS_TYPE_REQUIRED then
                    failwith "Cannot found the required argument."
