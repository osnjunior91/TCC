import re
import pandas as pd

def CreateCSV(lista):
    print('Iniciando criação de arquivo')
    data = {
        'texto': lista
    }
    df = pd.DataFrame(data, columns=['texto'])
    df.to_csv('twitterCsv.csv', sep=';', encoding='utf-8', index=False)
    print('Finalizando criação de arquivo')

def ReadFile():
    return pd.read_csv('../twitterCsv.csv')