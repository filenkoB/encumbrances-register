export async function AuthorityPassport(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Authority/Passport");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}
export async function Authority(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Authority");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function RegistrationUserStatement(item){
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(item)
  };
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Registration/User/Statement", requestOptions);
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetStatements(page, length){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Statement?page=" + page + "&length=" + length);
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetStatement(id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Statement/"+id);
  console.log("responce", responce);
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    console.log(responce.status);
    return null;
  }
}

export async function GetALLCountry(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Country");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetRegionByCountry(country_id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Region/Country/" + country_id)
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetDistrictByRegion(region_id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/District/Region/" + region_id)
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetCityByDistrict(district_id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/City/District/" + district_id)
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetStreetByCity(city_id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Street/City/" + city_id)
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetIndexByCity(city_id){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Index/City/" + city_id)
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function GetALLCurrency(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/CurrencyType");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function EncumbranceType(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/EncumbranceType");
  if(responce.status == 200){
    const data = await responce.json()
    let info = [];
    info.push({id:1, data:data.slice(0, 2)});
    info.push({id:2, data:data.slice(2, 4)})
    info.push({id:3, data:data.slice(4, 6)})
    return info;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function EncumbranceKind(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/EncumbranceKind");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function RegistrationType(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/RegistrationType");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function AlienationLimit(){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/AlienationLimit");
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}

export async function AcceptStatementId(statementId){
  const responce = await fetch(process.env.VUE_APP_HEROKU_PATH + "/Registration/User/Accept/"+statementId);
  if(responce.status == 200){
    const data = await responce.json()
    return data;
  }
  else {
    //some mess
    return {
      maxStatements:0,
      statements:[]
    }
  }
}
