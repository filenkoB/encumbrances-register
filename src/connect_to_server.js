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