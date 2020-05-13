import requests
url = "https://api.trello.com/1/board/QnqeK3SC/name"
querystring = {"key":"e3b4128fd6d770a1f8c1de19803bb1f0","token":"e2824406108a9c7673c563bd9e0390e608f4b1950195a2510a6e6788bfac5572"}
response = requests.request("GET", url, params=querystring)
print((response.text).encode())