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
    return twitters.find().limit(5);

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

def ExistsTwitterTraining(twitterId):
    try:
        db = client['TCC']
        training = db['Training']
        result = training.find({'_id': twitterId})
        return result.count() > 0
    except Exception as e:
        print('Error : {0}'.format(e))

def GetTrainingTwitter():
    db = client['TCC']
    training = db['Training']
    result = training.find()
    y = []
    for x in result:
        var = []
        var.append(str(re.sub('\\n','', x['texto'],flags=re.IGNORECASE)))
        var.append(x['feeling'])
        y.append(var)
    return y
    # return pd.DataFrame(y, columns=columns)
