import requests
import json

# URL of the backend API endpoint to handle the SQL insertion
api_url = "https://localhost:7140/Stock/InsertOneStock"

# Load the data from the JSON file
with open("stock_data.json", "r") as file:
    data = json.load(file)

# Make the POST request to the API endpoint for each item in the data list
for item in data:
    response = requests.post(api_url, json=item, verify=False)
    print(item)
    # Check the response status code
    print(response.text)
    if response.status_code == 200:
        print("Data successfully added to the SQL database.")
    else:
        print("Error occurred while adding data to the SQL database.")
