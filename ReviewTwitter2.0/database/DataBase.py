from pymongo import MongoClient
import pandas as pd
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
    return twitters.find().limit(1000);

def GetAllTwitterTitulo():
    print('Recuperando os dados\n')
    db = client['TCC']
    twitters = db['TwitterData']
    print('Dados recuperados\n')
    return twitters.find({
        'textSearch': 'bolsonaro',
        'textSearch': 'bolsonaro2018',
        'textSearch': 'jairbolsonaro'
    }).limit(10);

def SaveTraining(trainings):
    try:
        print('Salvando registros')
        db = client['TCC']
        data = db['Training']
        session.start_transaction()
        for training in trainings:
            data.save(training)
        session.commit_transaction()
    except:
        session.abort_transaction()

def SaveFeeling(feelings):
    try:
        print('Salvando registros')
        db = client['TCC']
        data = db['TwitterFeeling']
        session.start_transaction()
        for feeling in feelings:
            data.save(feeling)
        session.commit_transaction()
    except:
        session.abort_transaction()

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
        training = db['TwitterFeeling']
        result = training.find({'_id': twitterId}).limit(1).count()
        return result > 0
    except Exception as e:
        print('Error : {0}'.format(e))

def GetTrainingTwitter():
    db = client['TCC']
    training = db['Training']
    result = training.find()
    y = []
    for x in result:
        var = []
        var.append(str(re.sub('\\n','', x['textoAnalise'],flags=re.IGNORECASE)))
        var.append(x['feeling'])
        y.append(var)
    return y
    # return pd.DataFrame(y, columns=columns)

