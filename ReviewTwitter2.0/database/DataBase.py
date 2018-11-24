from pymongo import MongoClient
from bson.objectid import ObjectId
import pandas as pd
from math import exp
import re

client = MongoClient('mongodb://localhost:27017')
session = client.start_session()

# session.start_transaction()
# session.commit_transaction()
# session.abort_transaction()

def GetAllTwitter():
    print('Recuperando os dados\n')
    db = client['TCC']
    twitters = db['TwitterData']
    print('Dados recuperados\n')
    return twitters.aggregate([{"$sample": {"size": 300}}])



def GetAllTwitterTitulo():
    print('Recuperando os dados\n')
    db = client['TCC']
    twitters = db['TwitterData']
    print('Dados recuperados\n')
    return twitters.find({
        "$or": [
            {'textSearch': 'bolsonaro'},
            {'textSearch': 'bolsonaro2018'},
            {'textSearch': 'jairbolsonaro'}
        ]
    }).limit(6000)

# def GetAllTwitterTitulo():
#     print('Recuperando os dados\n')
#     db = client['TCC']
#     twitters = db['TwitterData']
#     print('Dados recuperados\n')
#     return twitters.find({
#         "$or": [
#             {'textSearch': 'haddad'},
#             {'textSearch': 'fernandohaddad'},
#             {'textSearch': 'haddadpresidente'}
#         ]
#     }).limit(6000)

# def GetAllTwitterTitulo():
#     print('Recuperando os dados\n')
#     db = client['TCC']
#     twitters = db['TwitterData']
#     print('Dados recuperados\n')
#     return twitters.find({
#         "$or": [
#             {'textSearch': 'cirogomes'},
#             {'textSearch': 'ciro12'},
#             {'textSearch': 'ciropresidente'}
#         ]
#     }).limit(6000);
def SaveTraining(twitter):
     print('Salvando registros')
     db = client['TCC']
     data = db['Training']
     data.save(twitter)

def SaveFeeling(feelings):
    try:
        print('Salvando registros')
        db = client['TCC']
        data = db['TwitterFeeling2']
        session.start_transaction()
        for feeling in feelings:
            data.save(feeling)
        session.commit_transaction()
    except:
        session.abort_transaction()

def SaveFeeling2(feelings):
    try:
        print('Salvando registros')
        db = client['TCC']
        data = db['Training_copy']
        session.start_transaction()
        for feeling in feelings:
            data.save(feeling)
        session.commit_transaction()
    except:
        session.abort_transaction()

def RemoveTwitter(twitterId):
        print('Excluindo registros')
        db = client['TCC']
        data = db['TwitterData']
        data.delete_one({'_id': twitterId})

def ExistsTwitterTraining(twitterId):
    try:
        db = client['TCC']
        training = db['Training']
        result = training.find({'_id': twitterId}).limit(1).count()
        return result > 0
    except Exception as e:
        print('Error : {0}'.format(e))

def ExistsTwitterFeeling(twitterId):
    try:
        db = client['TCC']
        training = db['TwitterFeeling2']
        result = training.find({'_id': twitterId}).limit(1).count()
        return result > 0
    except Exception as e:
        print('Error : {0}'.format(e))

def GetTrainingTwitter():
    db = client['TCC']
    training = db['Training_copy']
    result = training.find()
    y = []
    for x in result:
        var = []
        var.append(str(re.sub('\\n','', x['textoAnalise'],flags=re.IGNORECASE)))
        var.append(x['feeling'])
        y.append(var)
    return y
    # return pd.DataFrame(y, columns=columns)

