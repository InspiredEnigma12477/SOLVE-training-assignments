import requests
from bs4 import BeautifulSoup

url = "https://www.google.com/finance/quote/SBIN:NSE"
print("searching", url)

# Send a GET request to the URL
response = requests.get(url)
# print(response.text)

# Parse the HTML content using BeautifulSoup
soup = BeautifulSoup(response.content, "html.parser")

# Find the element that contains the stock price
price_element = soup.find("div", class_="YMlKec fxKbKc")

# Extract the stock price
stock_price = price_element.get_text()

# Print the stock price
print("TCS Stock Price:", stock_price)
