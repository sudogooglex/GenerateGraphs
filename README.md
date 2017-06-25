# Project Description
A software to generate graphs form a transaction file.  
With the generated file output.csv, you can create a Pie or an Histogram in Google docs or Excel.  
It will group transactions by "categories" and sum the associated amounts of each categories.  
A category is determined by a set of labels which looks identical.

# Installation
The transaction file path must be specified in the config.txt file which is in the root.  
You can rename configTemplate.txt to config.txt

### Example /config.txt :
/home/user/Download/transaction.csv

### Expected input format :
Date; Label; Amount  
23/06/2017; CB TRANSACTION Shop_**A**1  22.06.17 CARD; **-50,00**  
19/06/2017; BUY CB Shop_B1       17.06.17 CARD; 48,92  
08/06/2017; BUY CB Shop_**A**2 07.06.17 CARD; **-15,01**

The transaction.csv may contain positive or negative amounts.

# Output
The output file is output.csv.  
To generate the associated graph, use Google docs or Excel with the output.csv.
Create a Pie or an histogram.

### Expected output format :
Category; TotalAmount  
Category**A**; **-65,01**  
CategoryB; 48,92
