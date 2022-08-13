# Working with files and directories in .NET

## Scenario

Tailwind Traders has each of its stores write its sales total to a file and send that file to a central location. To use those files, the company needs to create a batch process that can work with the file system.

Tailwind Traders has a root folder called stores. In that folder are subfolders organized by store number and inside those folders are the sales-total and inventory files. The structure looks like this example:

```
stores
│   
└───201
|   |   inventory.text
│   │   sales.json
│   │   salestotals.json
|
└───202
    │   inventory.text
    │   sales.json
    |   salestotals.json
```

## Requirements

Working with the file system in .NET:
- Create a new directory called salesTotalDir at the root level
- Create a new totals.txt file inside the newly created salesTotalDir directory
- Find all *.json files the stores directory and its sub-folders
- Create a SalesData record so only the Total field in sales.json files are added and the OverallTotal field in the salestotals.json are not
- Add the value of the Total field of each *.json file to the salesTotal variable
- Append the salesTotal to the totals.txt file created earlier
