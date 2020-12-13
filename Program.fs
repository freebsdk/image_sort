open System
open System.Collections.Generic
open System.IO



let rec GetFileListInTheDirectory (root : DirectoryInfo) (fileList : List<FileInfo>) =
    try 
        let files = root.GetFiles("*.*")
        if files <> null then
            for file in files do
                file |> fileList.Add
            
            let subDirs = root.GetDirectories()
            for subDir in subDirs do
                GetFileListInTheDirectory <| subDir <| fileList 
    with 
    | _ ->
        ()




let GetAllFileList (basePath : string) =

    let fileList = List<FileInfo>()    
    let fullPath = Path.GetFullPath(basePath)
    
    if fullPath |> File.Exists then
        printfn "Directory not found. (specified base path : %s)" basePath
    else
        let dirInfo = DirectoryInfo(fullPath)
        GetFileListInTheDirectory <| dirInfo <| fileList
     
    fileList



let PadZeroStr(value : int) =
    if value < 10 then String.Format("0{0}",value)
    else String.Format("{0}", value)
    



let YearMonthDirName (date : DateTime) =
    date.Year.ToString()+PadZeroStr(date.Month)




// arguments > 0 src_dir, 1 dest_dir
// --src /path/to/src --dest /path/to/dest --destdirname "{YEAR}{MONTH}" --rename "{YEAR}{MONTH}{DAY}{HOUR}{MINUTE}{SECOND}_{DEVICE}" --overwrite --test 
[<EntryPoint>]
let main argv =
    let fileList = GetAllFileList <| argv.[0]
    for fileInfo in fileList do
        printfn "%s %s -> %s" (fileInfo.FullName) (fileInfo.CreationTime.ToString()) (fileInfo.CreationTime |> YearMonthDirName)
    printfn "Complete! %d files." (fileList.Count)
    
    0 // return an integer exit code
