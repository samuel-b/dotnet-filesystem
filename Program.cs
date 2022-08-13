using Newtonsoft.Json; 

//Stores the current directory's path in the currentDirectory variable
var currentDirectory = Directory.GetCurrentDirectory();

//Stores the stores directory's path (a sub-folder of the current path) in the storesDirectory variable
var storesDirectory = Path.Combine(currentDirectory, "stores");

//Stores the salesTotalDir directory's path (a sub-folder of the current path) in the salesTotalDir variable
var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");

//Creates the salesTotalDir directory using the variable created
Directory.CreateDirectory(salesTotalDir);   

//Takes a folder's path as a parameter and returns a list of file paths which extension == ".json"
IEnumerable<string> FindFiles(string folderPath)
{
    List<string> salesFiles = new List<string>();

    //Searches through the folderPath directory and it's sub-folders and returns file paths
    var foundFiles = Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories);

    //If the extension is the file is .json add it to salesFiles List
    foreach (var file in foundFiles)
    {
        if (Path.GetExtension(file) == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

//Calls the FindFiles function taking the stores directory as an argument and stores the returned output in the salesFiles variable
var salesFiles = FindFiles(storesDirectory);

//Takes the list of files returned from the FindFiles function and adds the Total field of each file and returns the total value
double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}
//Calls the CalculateSalesTotal function taking the salesFiles as an argument and stores the returned output in the salesTotal variable
var salesTotal = CalculateSalesTotal(salesFiles);

//Appends the value of salesTotal on a new line in salesTotalDir/totals.txt
File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");


//Used in the CalculateSalesTotal function - specifies the Total field in the salesFiles list and ignores anything else e.g. "OverallTotal" from the salestotals.json
record SalesData (double Total);