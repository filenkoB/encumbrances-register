const requestOptions = {
  method: "GET",
  headers: {
    "Content-Type": "application/json",
    "Authorization": "Bearer " + window.sessionStorage.getItem('token')
  },
};

function requestOptionsPostBody(item){
  return {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": "Bearer " + window.sessionStorage.getItem('token')
    },
    body: JSON.stringify(item)
  }
}

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
export async function AuthorityPassport(){ return await create("/Authority/Passport", requestOptions) }

export async function Authority(){ return await create("/Authority", requestOptions) }

export async function RegistrationUserStatement(item){ return await create("/Registration/User/Statement", requestOptionsPostBody(item)) }

export async function RegistrationRegistratorStatement(item){ return await create("/Registration/Registrator/Statement", requestOptionsPostBody(item)) }

export async function RegistrationUserAccept(statementId){ return await create("/Registration/User/Accept/" + statementId, requestOptionsPostBody(null)) }

export async function RegistrationUserDecline(statementId, user_email, decline_reason){ return await create("/Registration/User/Decline/" + statementId, 
  requestOptionsPostBody(
    {
      email: user_email,
      reason: decline_reason
    })
  ) 
}

export async function RegistrationRegistratorAccept(statementId){ return await create("/Registration/Registrator/Accept/" + statementId, requestOptionsPostBody(null)) }

export async function RegistrationRegistratorDecline(statementId, registrator_email, decline_reason){ return await create("/Registration/Registrator/Decline/" + statementId, 
  requestOptionsPostBody({
    email: registrator_email,
    reason: decline_reason
  })
  ) 
}

export async function GetStatements(page, length){ return await create("/Statement?page=" + page + "&length=" + length, requestOptions) }

export async function GetStatement(id){ return await create("/Statement/"+id, requestOptions) }

export async function CreateStatement(item){ return await create("/Statement/Register", requestOptionsPostBody(item)) }

export async function EncumbranceStatementAccept(statementId){ return await create("/Encumbrance/Statement/"+statementId+"/Accept", requestOptionsPostBody(null)) }

export async function EncumbranceStatementDecline(statementId){ return await create("/Encumbrance/Statement/"+statementId+"/Decline", requestOptionsPostBody(null)) }

export async function EncumbranceRemoveStatementAccept(statementId){ return await create("/Encumbrance/Remove/Statement/"+statementId+"/Accept", requestOptionsPostBody(null)) }

export async function EncumbranceUpdateStatementAccept(statementId){ return await create("/Encumbrance/Update/Statement/"+statementId+"/Accept", requestOptionsPostBody(null)) }

export async function EncumbranceRegisterStatementAccept(statementId){ return await create("/Encumbrance/Register/Statement/"+statementId+"/Accept", requestOptionsPostBody(null)) }

export async function Encumbrance(item, page, length){ return await create("/Encumbrance?page=" + page + "&length=" + length, requestOptionsPostBody(item)) }

export async function UsersStatementsList(page, length){ return await create("/Statement/Registration/Users?page=" + page + "&length=" + length, requestOptions) }

export async function UserStatementsInfo(userId){ return await create("/Statement/Registration/Users/" + userId, requestOptions) }

export async function GetALLCountry(){ return await create("/Country", requestOptions) }

export async function GetRegionByCountry(country_id){ return await create("/Region/Country/" + country_id, requestOptions) }

export async function GetDistrictByRegion(region_id){ return await create("/District/Region/" + region_id, requestOptions) }

export async function GetCityByDistrict(district_id){ return await create("/City/District/" + district_id, requestOptions) }

export async function GetStreetByCity(city_id){ return await create("/Street/City/" + city_id, requestOptions) }

export async function GetIndexByCity(city_id){ return await create("/Index/City/" + city_id, requestOptions) }

export async function GetALLCurrency(){ return await create("/CurrencyType", requestOptions) }

export async function RegistrationNumber(statementId){ return await create("/RegistrationNumber/"+statementId, requestOptions) }

function GetRequestOptions(inmethod, item){
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

export class Admin{
  constructor(id){console.log(id)}
  async GetAllRegistrators(page, length){ 
    return await create("/Registrator?page=" + page + "&length=" + length, GetRequestOptions("GET", null))
  }
  async GetRegistratorById(registrator_id){ 
    return await create("/Registrator/" + registrator_id, GetRequestOptions("GET", null))
  }
  async UpdateRegistrator(item){
    return await create("/Registrator", GetRequestOptions("PUT", item))
  }
  async GetRegistratorActions(registrator_id, page, length){ 
    return await create("/Registrator/"+registrator_id+"/Actions?page=" + page + "&length=" + length, GetRequestOptions("GET", null))
  }
}