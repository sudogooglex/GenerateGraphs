# Project Description
A software to generate graphs form a transaction file.  
With the generated file output.csv, you can create a Pie or an Histogram in Google docs or Excel.  
It will group transactions by "categories" and sum the associated amounts of each categories.  
A category is determined by a set of labels which looks identical.

# Installation
`git clone https://github.com/sudogooglex/GenerateGraphs`  
`cd GenerateGraphs/`  
`cp config.txt configTemplate.txt`  
The transaction file path must be specified at the first line of the config.txt file.  
`dotnet restore # Restore Nuget packages`  
`dotnet clean`  
`dotnet run`

### Example /config.txt :
/home/user/Download/transaction.csv  
Word1  
((\d{2})([\.\/]{1})(\d{2})([\.\/]{1})(\d{2}))

### Expected input format /transaction.csv :
Date; Label; Amount  
23/06/2017; CB TRANSACTION Shop_**A**1  22.06.17 CARD; **-50,00**  
19/06/2017; BUY CB Shop_B1       17.06.17 CARD; 48,92  
08/06/2017; BUY CB Shop_**A**2 07.06.17 CARD; **-15,01**

The transaction.csv may contain positive or negative amounts.

# Output
The output file is output.csv, at the root of the project.  
To generate the associated graph, use Google docs or Excel with the output.csv.
Create a Pie or an histogram.

### Expected output format :
Category; TotalAmount  
Category**A**; **-65,01**  
CategoryB; 48,92

# Filter
To filter some words before making categories, you can add regex in the config.txt.
