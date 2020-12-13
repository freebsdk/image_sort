namespace image_sort





type ARGS_TYPE =
    | ARGS_TYPE_REQUIRED
    | ARGS_TYPE_OPTION




type ArgsParserElem (argsType : ARGS_TYPE, needVal : bool, key : string) =

    let argsType = argsType
    let needVal = needVal
    let key = key
    
    
    member _.ArgsType =
        argsType
        
        
    member _.NeedVal =
        needVal
        
        
    member _.Key =
        key
