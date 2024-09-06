import requests
from bs4 import BeautifulSoup
import json

url = 'https://www.imdb.com/chart/top/'
headers = {
     "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36" 
 }

response = requests.get(url, headers=headers)
response.raise_for_status()

soup = BeautifulSoup(response.text, 'html.parser')

 # IMDb Top 10 Filmlerini Bul
movie_items = soup.find_all('li', class_='ipc-metadata-list-summary-item')[:10]

top_10_movies = []

for movie in movie_items:
     title = movie.find('h3', class_='ipc-title__text').text.strip()
     rating = movie.find('span', class_='ipc-rating-star--rating').text.strip()
    
     # Poster URL'sini Bul
     poster_tag = movie.find('img', class_='ipc-image')
     poster_url = poster_tag['src'] if poster_tag else 'No Image Available'
    
     top_10_movies.append({
         'title': title,
         'rating': rating,
         'poster': poster_url
     })

 # JSON Dosyasına Yaz
with open('top_10_movies.json', 'w') as f:
     json.dump(top_10_movies, f, indent=4)

print("Top 10 movies saved to 'top_10_movies.json'")
