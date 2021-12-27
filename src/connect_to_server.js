async function create(path, option){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + path, option);
  if(responce.status == 200) return await responce.json();
  else {
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export function GetRequestOptions(inmethod, item){
  if(inmethod == "GET") {
    return {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + window.sessionStorage.getItem('token')
      },
    }
  }
  else {
    return {
      method: inmethod,
      headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + window.sessionStorage.getItem('token')
      },
      body: JSON.stringify(item)
    }
  }
}

export class Encumbrance{
  constructor(){}
  //Пошук обтяження
  async Encumbrance(item, page, length){ return await create("/Encumbrance?page=" + page + "&length=" + length, GetRequestOptions("POST",item)) }
  
  //Пошук обтяження для створення заяви на зміну
  async EncumbranceRegistrationNumber(number){ return await create("/Encumbrance/RegistrationNumber/"+number, GetRequestOptions("GET", null)) }
}

export class Registration{
  constructor(){}
  //Подання заявок на реєстрацію в реєстрі
  async RegistrationUserStatement(item){ return await create("/Registration/User/Statement", GetRequestOptions("POST",item)) }
  async RegistrationRegistratorStatement(item){ return await create("/Registration/Registrator/Statement", GetRequestOptions("POST",item)) }
}
export class Address{
  constructor(){}
  async GetALLCountry(){ return await create("/Country", GetRequestOptions("GET", null)) }
  async GetRegionByCountry(country_id){ return await create("/Region/Country/" + country_id, GetRequestOptions("GET", null)) }
  async GetDistrictByRegion(region_id){ return await create("/District/Region/" + region_id, GetRequestOptions("GET", null)) }
  async GetCityByDistrict(district_id){ return await create("/City/District/" + district_id, GetRequestOptions("GET", null)) }
  async GetStreetByCity(city_id){ return await create("/Street/City/" + city_id, GetRequestOptions("GET", null)) }
  async GetIndexByCity(city_id){ return await create("/Index/City/" + city_id, GetRequestOptions("GET", null)) }
}

export class Admin{
  constructor(){}
  //Перегляд реєстраторів
  async GetAllRegistrators(page, length){ return await create("/Registrator?page=" + page + "&length=" + length, GetRequestOptions("GET", null)) }
  async GetRegistratorById(registrator_id){ return await create("/Registrator/" + registrator_id, GetRequestOptions("GET", null)) }
  async UpdateRegistrator(item){ return await create("/Registrator", GetRequestOptions("PUT", item)) }
  async GetRegistratorActions(registrator_id, page, length){ return await create("/Registrator/"+registrator_id+"/Actions?page=" + page + "&length=" + length, GetRequestOptions("GET", null)) }

  //Перегляд заявок на реєстрацію нового користувача системи
  async UsersStatementsList(page, length){ return await create("/Statement/Registration/Users?page=" + page + "&length=" + length, GetRequestOptions("GET", null)) }
  async UserStatementsInfo(userId){ return await create("/Statement/Registration/Users/" + userId, GetRequestOptions("GET", null)) }

  //Прийняття та відхилення заявок на реєстрацію нового користувача
  async RegistrationUserAccept(statementId){ return await create("/Registration/User/Accept/" + statementId,  GetRequestOptions("POST", null)) }
  async RegistrationUserDecline(statementId, user_email, decline_reason){ return await create("/Registration/User/Decline/" + statementId,  GetRequestOptions("POST", { email: user_email, reason: decline_reason})) }

  //Прийняття та відхилення заявок на реєстрацію нового реєстратора
  async RegistrationRegistratorAccept(statementId){ return await create("/Registration/Registrator/Accept/" + statementId,  GetRequestOptions("POST", null)) }
  async RegistrationRegistratorDecline(statementId, registrator_email, decline_reason){ return await create("/Registration/Registrator/Decline/" + statementId,  GetRequestOptions("POST", { email: registrator_email, reason: decline_reason})) }
}

export class User{
  constructor(){}
  async GetAllMyStatements(page, length){ return await create("/Statement/User?page=" + page + "&length=" + length, GetRequestOptions("GET", null)) }
}

export class Registrator{
  constructor(){}
  //Отримання витягу
  async StatementExtractAccept(statementId){ return await create("/Statement/Extract/" + statementId + "/Accept", GetRequestOptions("POST", null)) }
  async StatementExtractDecline(statementId){ return await create("/Statement/Extract/" + statementId + "/Decline", GetRequestOptions("POST", null)) }
  
  //Заяви на обтяження
  async EncumbranceRegisterStatementAccept(statementId){ return await create("/Encumbrance/Register/Statement/"+statementId+"/Accept", GetRequestOptions("POST", null)) }
  async EncumbranceUpdateStatementAccept(statementId){ return await create("/Encumbrance/Update/Statement/"+statementId+"/Accept", GetRequestOptions("POST", null)) }
  async EncumbranceRemoveStatementAccept(statementId){ return await create("/Encumbrance/Remove/Statement/"+statementId+"/Accept", GetRequestOptions("POST", null)) }
  async EncumbranceStatementDecline(statementId){ return await create("/Encumbrance/Statement/"+statementId+"/Decline", GetRequestOptions("POST", null)) }
 
  //Перегляд заяв
  async GetAllStatements(page, length){ return await create("/Statement?page=" + page + "&length=" + length, GetRequestOptions("GET", null)) }
  async GetStatementById(statementId){ return await create("/Statement/"+statementId, GetRequestOptions("GET", null)) }
}

export class Main{
  constructor(){}
  //Уповноважені органи
  async Authority(){ return await create("/Authority", GetRequestOptions("GET", null)) }
  async AuthorityPassport(){ return await create("/Authority/Passport", GetRequestOptions("GET", null)) }
  
  //Чи працює юзер в уповноваженому органі
  async UserAuthority(){ return await create("/User/Authority", GetRequestOptions("GET", null)) }

  //Створення заяв на обтяження
  async CreateStatement(item){ return await create("/Statement/Register", GetRequestOptions("POST", item)) }
  async StatementRegisterExtract(encumbranceId){ return await create("/Statement/Register/Extract/" + encumbranceId, GetRequestOptions("POST", null)) }
}