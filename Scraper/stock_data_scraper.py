import requests
from bs4 import BeautifulSoup
import json

# URL of the webpage to scrape
url = "https://indiancompanies.in/listed-companies-in-nse-with-symbol/"

# Send a GET request to the URL
response = requests.get(url)

# Create a BeautifulSoup object
soup = BeautifulSoup(response.content, "html.parser")

# Find the table containing the stock data
table = soup.find("table", class_="")
if table is None:
    print("Error: Table not found on the webpage.")

# Extract symbol name and stock name from the table rows
rows = table.find_all("tr")
data = []
for row in rows:
    columns = row.find_all("td")
    if len(columns) >= 3:
        symbol = columns[2].text.strip()
        stock_name = columns[1].text.strip()
        data.append({"StockSymbol": symbol, "StockName": stock_name})
        print("Symbol:", symbol)
        print("Stock Name:", stock_name)

# Write the data to a JSON file
with open("stock_data.json", "w") as file:
    json.dump(data, file, indent=4)

print("Data saved to stock_data.json file.")
