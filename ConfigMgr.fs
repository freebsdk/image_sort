namespace picture_sort
open System.Collections.Generic





type ConfigMgr() =
    
    let dic = new Dictionary<string, string> ();
        
        
    let nextArgument(argv : string[]) (curIdx :int) =
        var nextIdx = curIdx + 1;
        if nextIdx >= argv.Length then
            None
        else
            if argv.[nextIdx].Length > 0 then
                

        
    let rec ParseArgument(argv : string[]) (idx : int) =
        let curArgv = argv.[idx]
        if curArgv.StartsWith("--") then
            if()
        ()
                    

    
            
    member _.HasArgument (key : string) =
        key |> dic.ContainsKey
        
        
        
    member _.Parse (argv : string[]) =
        let mutable stop = false
        
        
        
        while stop != false do
            if argv.[idx] = "--src" then
                if idx >= argv.Length || argv.[idx++]
        ()