# Учет пациентов
## Функциональные требования:
### Пациенты :
#### Типичный представитель сотрудник больницы:
* должен иметь возможность вести мониторинг всех пациентов(GET) и мониторинг 
конкретного пациента(GET by ID);
* должен иметь возможность добавлять пациента в базу данных пациентов(POST);
* должен иметь возможность вносить изменения в существующие записи (PUT и PATCH);
* должен иметь возможность удалять конкретные записи пациентов лентральной больницы(DELETE);
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
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
####  GET(id):
Url: /api/v1/patients/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
####  POST:
Url: /api/v1/patients
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
####  PUT(id):
Url: /api/v1/patients/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
#### DELETE(id) 
Url: /api/v1/patients
<br/>Входная модель: 
<br/>{ id: int}
<br/>Выходная модель:
<br/>{ isDeleted: string}

###  Описание больниц:
####  GET:
Url: /api/v1/hospitals
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int,
<br/>address: string,
<br/>}
####  GET(id):
Url: /api/v1/hospitals/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int,
<br/>address: string,
<br/>}}
####  POST:
Url: /api/v1/hospitals
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>address: string,
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
####  PUT(id):
Url: /api/v1/hospitals/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>address: string,
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
#### DELETE(id) 
Url: /api/v1/hospitals/{id}
<br/>Входная модель: 
<br/>{ id: int}
<br/>Выходная модель:
<br/>{ isDeleted: string}

###  Пациенты больниц:
####  GET:
Url: /api/v1/hospitals/{hospitalsId}/patients
<br/>Входная модель: {}
<br/>Выходная модель:
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
####  GET(id):
Url: /api/v1/hospitals/{hospitalsId}/patients/{id}
<br/>Входная модель: {id : int}
<br/>Выходная модель:
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
####  POST:
Url: /api/v1/hospitals/{hospitalsId}/patients
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
####  PUT(id):
Url: /api/v1/hospitals/{hospitalsId}/patients/{id}
<br/>Входная модель: 
<br/>{
<br/>id : int,
<br/>name: string,
<br/>surname: string,
<br/>birthday: float,
<br/>sex: string,
<br/>passport: string
<br/>}
<br/>Выходная модель:
<br/>{
<br/>id: int
<br/>status: string
<br/>}
#### DELETE(id) 
Url: /api/v1/hospitals/{hospitalsId}/patients
<br/>Входная модель: 
<br/>{ id: int}
<br/>Выходная модель:
<br/>{ isDeleted: string}



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
