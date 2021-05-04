# Учет пациентов
## Функциональные требования:
### Пациенты :
#### Типичный представитель сотрудник больницы:
* должен иметь возможность вести мониторинг всех пациентов(GET) и мониторинг 
конкретного пациента(GET by ID);  
* должен иметь возможность мониторить переполнение центральной больницы пациентами.

### Больницы:
#### Типичный представитель сотрудник больницы:
* должен иметь возможность вести мониторинг всех пациентов определенной больницы(GET) и мониторинг 
конкретного пациента(GET by ID);
* должен иметь возможность добавлять пациента в базу данных пациентов определенной больницы(POST);
* должен иметь возможность вносить изменения в существующие записи пациентов определенной больницы(PUT и PATCH);
* должен иметь возможность удалять конкретные записи пациентов определенной больницы(DELETE);
* должен иметь возможность мониторить переполнение определенной больницы пациентами.
##  Методы
###  Пациенты:
####  GET:
Url: /api/v1/patient
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}  
Метод предусматривает реализацию pagination в розмере пяти элементов за один запрос  
####  GET(id):
Url: /api/v1/patient/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}


###  Описание больниц:
####  GET:
Url: /api/v1/hospital
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}  
Метод предусматривает реализацию pagination в розмере пяти элементов за один запрос    
####  GET(id):
Url: /api/v1/hospital/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}}
####  POST:
Url: /api/v1/hospital
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>}
####  PUT(id):
Url: /api/v1/hospital/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>}
#### DELETE(id) 
Url: /api/v1/hospital/{id}
<br/>Входная модель: 
<br/>{ id: int, min=1/max=1000}
<br/>Выходная модель:
<br/>{ isDeleted: string, min=1/max=1000}

###  Пациенты больниц:
####  GET:
Url: /api/v1/hospital/{hospitalId}/patient
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}  
Метод предусматривает реализацию pagination в розмере пяти элементов за один запрос   
####  GET(id):
Url: /api/v1/hospital/{hospitalId}/patient/{id}
<br/>Входная модель: {id : int, min=1/max=1000}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}
####  POST:
Url: /api/v1/hospital/{hospitalId}/patient
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
####  PUT(id):
Url: /api/v1/hospital/{hospitalId}/patient/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
#### DELETE(id) 
Url: /api/v1/hospital/{hospitalId}/patient
<br/>Входная модель: 
<br/>{ id: int, min=1/max=1000}
<br/>Выходная модель:
<br/>{ isDeleted: string, min=1/max=1000}



## Нефункциональные требования:
* использование БД в качестве постоянного хранилища данных
* сохранение данных в нештатных ситуациях
* безопасность при работе с личными данными
* удобство в использовании
* продуктивность
* надежность
## Acceptace criteria:
* правильная работа системы
* защищенность 
