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