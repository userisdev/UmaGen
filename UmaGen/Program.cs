var baseUrl = "https://tabbotdev-umamusume.netlify.app/";

var dir = new DirectoryInfo(args.FirstOrDefault());

var files = dir.GetFiles("*",SearchOption.TopDirectoryOnly);

var list = new List<string>();  

foreach(var (file,index) in files.Select((e, i) => (e, i)))
{
    list.Add($"umamusume,{Path.GetFileNameWithoutExtension(file.Name)},{baseUrl}{index:000}.jpg");
    var movedPath = Path.Combine(file.DirectoryName, $"{index:000}.jpg");
    file.MoveTo(movedPath);
}

File.WriteAllLines("list.csv", list);