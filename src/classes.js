
export class General_Information{
  constructor(number) {
    this.status = false;
    this.number = {
      data: number
    };
    this.date = {
      data: "12.12.2012"
    };
  }
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Weightlifter_Information{
  constructor() {
    this.status = false;
    this.number = {
      data: "21312312",
    },
    this.resident = {
      data: "",
      status: false
    },
    this.obj_name = {
      data: "lsaldlasl"
    };
    this.address = {
      status: false,
      country:{
        data: "Ukraine",
      },
      index:{
        data: 16300,
      },
      region:{
        data: "asfsadsa "
      },
      area:{
        data: "asdasas"
      },
      city:{
        data: "Kiev"
      },
      street:{
        data: "sllslsl"
      },
      build: {
        data: 123
      },
      corps:{
        data: "b"
      },
      flat:{
        data: 14
      }
    }
  }
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Debtor_Information{
  constructor() {
    this.status = false;
    this.number = {
      data: "1111111111",
    },
    this.resident = {
      data: "asdasdasd",
      status: true
    },
    this.obj_name = {
      data: "adsdasasd"
    };
    this.address = {
      status: false,
      country:{
        data: "Ukraineasdas",
      },
      index:{
        data: 163001231,
      },
      region:{
        data: "asfsadsa "
      },
      area:{
        data: "asdasas"
      },
      city:{
        data: "Kiev"
      },
      street:{
        data: "sllslsl"
      },
      build: {
        data: 123
      },
      corps:{
        data: "b"
      },
      flat:{
        data: 14
      }
    }
  }
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Basis_Document{
  constructor() {
    this.status = false;
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
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Encumbrance_Information{
  constructor() {
    this.status = false;
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
      status: true
    },
    this.information = {
      data:["Дозволено відчужувати", "Відчужувати заборонено", "Відчужувати за погодженням з обтяжувачем"],
      checked: "Відчужувати заборонено"
    }
  }
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Terms{
  constructor() {
    this.status = false;
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
      data: "lsaldlas",
      status: true
    }
  }
  colour(){
    if(this.status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}
/*
class Encumbrance_Description_Subject{
  constructor(element) {
    this.status = false;
    this.name = "Опис предмета обтяження:";
    this.body = [
      new info_part("Рухоме майно що має серійні номери:", element.part_1, "text"),
      new info_part("Рухоме майно, крім описаного вище за серійними номерами:", element.part_2, "text")
    ]
  }
}

class More_Information{
  constructor(element) {
    this.status = false;
    this.name = "Додаткові відомості:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}

class Service_Notes{
  constructor(element) {
    this.status = false;
    this.name = "Службові відмітки:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}
*/