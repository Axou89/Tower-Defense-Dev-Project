from flask import Flask, jsonify, request
from flask_pymongo import PyMongo
from bson.objectid import ObjectId
from pymongo import MongoClient
from flask_pymongo import PyMongo
import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt
from dotenv import load_dotenv
import os

load_dotenv()
USERNAME = os.getenv('USERNAME')
PASSWORD = os.getenv('PASSWORD')

def get_database():
 

 
   # Create a connection using MongoClient. You can import MongoClient or use pymongo.MongoClient
   print(USERNAME,PASSWORD)
   client = MongoClient('mongodb+srv://admin:VjIPOBWbTGVDwl4V@quackochocolat.bsxbipg.mongodb.net/TowerDefense', 27017)
 #mongodb+srv://admin:VjIPOBWbTGVDwl4V@quackochocolat.bsxbipg.mongodb.net/
   # Create the database for our example (we will use the same database throughout the tutorial
   
   db = client['Tower_Defense']
   collection = db['Player']

   users = [{
       "username": "admin","password": "admin"
   }]
   collection.insert_many(users)  # Add user           
   print("Data inserted in the database")
 # 
get_database()

def InitialiseFlask():

    app = Flask(__name__)  # Pour initialiser l'application
    app.config["DEBUG"] = True # Pour activer le débogage et le rechargement automatique du code


    app.config['MONGO_DBNAME'] = 'final_exam'
    #app.config['MONGO_URI'] = 'mongodb://localhost:27017/final_exam'
    app.config['MONGO_URI'] = 'mongodb+srv://'+USERNAME+':'+PASSWORD+'@quackochocolat.bsxbipg.mongodb.net/' # TowerDefense

    mongo = PyMongo(app)
    
