import requests
from bs4 import BeautifulSoup
from flask import Flask, jsonify


import requests
from bs4 import BeautifulSoup
from flask import Flask, jsonify

def fetch_top_10_movies():
    url = 'https://www.imdb.com/list/ls003992425/'
    response = requests.get(url)
    
    if response.status_code != 200:
        print(f"Error: Unable to fetch page, status code {response.status_code}")
        return []

    soup = BeautifulSoup(response.content, 'html.parser')

    if not soup.select('.lister-item'):
        print("Error: Could not find any lister-item elements")
        return []

    movies = []
    for item in soup.select('.lister-item'):
        title = item.h3.a.text.strip()
        img_url = item.find('img')['src']
        movies.append({'title': title, 'image_url': img_url})
    
    return movies

app = Flask(__name__)

@app.route('/top10', methods=['GET'])
def top10():
    movies = fetch_top_10_movies()
    return jsonify(movies)

if __name__ == '__main__':
    app.run(port=5000)


app = Flask(__name__)

@app.route('/top10', methods=['GET'])
def top10():
    movies = fetch_top_10_movies()
    return jsonify(movies)

if __name__ == '__main__':
    app.run(port=5000)

    