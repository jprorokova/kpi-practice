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
Url: /api/v1/patients
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}  
Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит  
####  GET(id):
Url: /api/v1/patients/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}


###  Описание больниц:
####  GET:
Url: /api/v1/hospitals
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}  
Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит  
####  GET(id):
Url: /api/v1/hospitals/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}}
####  POST:
Url: /api/v1/hospitals
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
####  PUT(id):
Url: /api/v1/hospitals/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>address: string, min=1/max=1000
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
#### DELETE(id) 
Url: /api/v1/hospitals/{id}
<br/>Входная модель: 
<br/>{ id: int, min=1/max=1000}
<br/>Выходная модель:
<br/>{ isDeleted: string, min=1/max=1000}

###  Пациенты больниц:
####  GET:
Url: /api/v1/hospitals/{hospitalsId}/patients
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}  
Метод передбачає реалізацію pagination у розмірі п'яти елементів за один запит  
####  GET(id):
Url: /api/v1/hospitals/{hospitalsId}/patients/{id}
<br/>Входная модель: {id : int, min=1/max=1000}
<br/>Выходная модель:
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}
####  POST:
Url: /api/v1/hospitals/{hospitalsId}/patients
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
####  PUT(id):
Url: /api/v1/hospitals/{hospitalsId}/patients/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int, min=1/max=1000
<br/>name: string, min=1/max=99
<br/>surname: string, min=1/max=99
<br/>birthday: date,  min=1800/max=2021
<br/>sex: string,min=1/max=20
<br/>passport: string,min=1000000/max=9999999
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int, min=1/max=1000
<br/>status: string, min=1/max=1000
<br/>}
#### DELETE(id) 
Url: /api/v1/hospitals/{hospitalsId}/patients
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
