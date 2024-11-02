import yaml
import requests
import json

requests.packages.urllib3.disable_warnings()

def main():
    # 1. Ler o arquivo YAML
    with open('dados_pessoa.yaml', 'r', encoding='utf-8') as file:
        yaml_data = yaml.safe_load(file)
        person_data = yaml_data['pessoa']
    
    # 2. Preparar o dados no formato correto para a API
    api_data = {
        "nome": person_data['Nome'],
        "idade": person_data['Idade'],
        "nif": person_data['Nif'],
        "telefone": person_data['Telefone'],
        "email": person_data['Email'],
        "endereco": {
            "rua": person_data['Endereco']['rua'],
            "numero": person_data['Endereco']['numero'],
            "complemento": person_data['Endereco']['complemento']
        }
    }

    # 3. Enviar para a API (POST)
    api_url = 'https://localhost:7068/api/person'  # Use a URL que funciona no Swagger
    try:
        # Salvar pessoa - Note o verify=False aqui
        response = requests.post(api_url, json=api_data, verify=False)
        if response.status_code == 201:
            print("Pessoa salva com sucesso!")
            saved_person = response.json()
            person_id = saved_person['id']
            
            # Buscar a pessoa salva (GET) - Note o verify=False aqui também
            get_response = requests.get(f'{api_url}/{person_id}', verify=False)
            if get_response.status_code == 200:
                print("\nDados recuperados do banco:")
                print(json.dumps(get_response.json(), indent=2))
        else:
            print(f"Erro ao salvar: {response.status_code}")
            print(response.text)
    
    except requests.exceptions.RequestException as e:
        print(f"Erro de conexão: {e}")

if __name__ == "__main__":
    main()