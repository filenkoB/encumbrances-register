export class StatmentsPageElement{
  visible_status = false;
  constructor(id, number, date, typeName){
    this.id = id;
    this.number = number;
    this.date = (new Date(Date.parse(date))).toLocaleDateString('en-GB');
    this.typeName = typeName;
  }
}

export class GeneralInfo{
  visible_status = false;
  constructor(number, registrationDate) {
    this.number = number;
    this.registrationDate = registrationDate;
  }
}

export class EncumbranceTier{
  visible_status = false;
  address = {
    visible_status: false,
    path:{
      country: "Оберіть ...",
      region: "Оберіть ...",
      district: "Оберіть ...",
      city: "Оберіть ...",
      index: "Оберіть ...",
      street: "Оберіть ...",
      build: "Оберіть ...",
      corps: "Оберіть ...",
      flat:"Оберіть ..."
    }
  }
  name = null;
  constructor(taxpayerAccountCardNumber, isForeigner, name) {
    this.taxpayerAccountCardNumber = taxpayerAccountCardNumber,
    this.isForeigner = isForeigner;
    this.name = name; 
  }
}
export class Debtor_Information{
  constructor() {
    this.visible_status = false;
    this.number = { data: "" },
    this.resident = {
      data: "",
      visible_status: false
    },
    this.obj_name = { data: ""  };
    this.address = {
      visible_status: false,
      path:{
        country: "Оберіть ...",
        region: "Оберіть ...",
        district: "Оберіть ...",
        city: "Оберіть ...",
        index: "Оберіть ...",
        street: "Оберіть ...",
        build: "Оберіть ...",
        corps: "Оберіть ...",
        flat:"Оберіть ..."
      }
    }
    
  }
  set_values(visible_status, number, resident, address){
    this.visible_status = visible_status;
    this.number.data = number;
    this.resident.data = resident;
    this.address = address;
  }
}

export class Basis_Document{
  constructor() {
    this.visible_status = false;
    this.name = {
      data: "alsdas"
    },
    this.number = {
      data: 2131221
    },
    this.date = {
      data: "12.12.2012"
    },
    this.publisher = {
      data: "lsaldlas"
    }
  }
}

export class Encumbrance_Information{
  constructor() {
    this.visible_status = false;
    this.encumbrance_type = {
      data: ["Публічне обтяження", "Приватне обтяження"],
      checked: "Приватне обтяження"
    },
    this.registration_type = {
      data: ["Поточна", "Попередня"],
      checked: "Поточна"
    },
    this.date = {
      data: "12.12.2012"
    },
    this.type_encumbrance = {
      data: [["Податкова застава", "Арешт"], ["Звернення стягнення", "Застава рухомого майна"], ["Заборона", "Інший"]],
      checked: "Арешт"
    },
    this.type_description = {
      data: "",
      visible_status: true
    },
    this.information = {
      data:["Дозволено відчужувати", "Відчужувати заборонено", "Відчужувати за погодженням з обтяжувачем"],
      checked: "Відчужувати заборонено"
    }
  }
  colour(){
    if(this.visible_status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.visible_status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Terms{
  constructor() {
    this.visible_status = false;
    this.currency_type = "Оберіть ...",
    this.number = {
      data: 2131221
    },
    this.date = {
      data: "12.12.2012"
    },
    this.publisher = {
      data: "lsaldlas",
      visible_status: true
    }
  }
}
/*
class Encumbrance_Description_Subject{
  constructor(element) {
    this.visible_status = false;
    this.name = "Опис предмета обтяження:";
    this.body = [
      new info_part("Рухоме майно що має серійні номери:", element.part_1, "text"),
      new info_part("Рухоме майно, крім описаного вище за серійними номерами:", element.part_2, "text")
    ]
  }
}

class More_Information{
  constructor(element) {
    this.visible_status = false;
    this.name = "Додаткові відомості:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}

class Service_Notes{
  constructor(element) {
    this.visible_status = false;
    this.name = "Службові відмітки:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}
*/