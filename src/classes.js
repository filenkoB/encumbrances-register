export class StatmentsPageElement{
  visible_status = false;
  constructor(id, number, date, typeName){
    this.id = id;
    this.number = number;
    this.date = (new Date(Date.parse(date))).toLocaleDateString('en-GB');
    this.typeName = typeName;
  }
}

export class RegistrarsPageElement{
  info_visible_status = false;
  logs_visible_status = false;
  constructor(id, name, email, registeredAt, status){
    this.id = id;
    this.name = name;
    this.email = email;
    this.registeredAt = (new Date(Date.parse(registeredAt))).toLocaleDateString('en-GB');
    this.status = status;
  }
}

export class Registrator{
  constructor(id, firstName, lastName, patronymic, birthDate, email, registeredAt, status, authority){
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.patronymic = patronymic;
    this.birthDate = birthDate.split('T')[0];
    this.email = email;
    this.registeredAt = registeredAt.split('T')[0];
    this.status = status;
    this.authority = authority;
  }
  get_info(){
    const current_time = new Date();
    return {
      id: this.id,
      firstName: this.firstName,
      lastName: this.lastName,
      patronymic: this.patronymic,
      birthDate: (new Date(this.birthDate+'T'+current_time.toISOString().split('T')[1])).toISOString(),
      email: this.email,
      status: this.status,
      authorityId: this.authority.id
    }
  }
}

export class GeneralInfo{
  visible_status = false;
  constructor(number, registrationDate) {
    this.number = number;
    this.registrationDate = registrationDate.split('T')[0];
  }
}

export class EncumbranceTierDebtor{
  visible_status = false;
  short_info = false;
  typeDescription = null
  address = {
    visible_status: true,
    path:{}
  }
  name = null;
  constructor(taxpayerAccountCardNumber, isForeigner, name, additionalInfo, address, id) {
    this.taxpayerAccountCardNumber = taxpayerAccountCardNumber,
    this.isForeigner = isForeigner;
    this.name = name; 
    this.typeDescription = additionalInfo;
    this.address.path.country = address.countryId;
    this.address.path.region = address.regionId;
    this.address.path.district = address.districtId;
    this.address.path.city = address.cityId;
    this.address.path.index = address.indexCode;
    this.address.path.street = address.streetId;
    this.address.path.build = address.building;
    this.address.path.corps = address.corps;
    this.address.path.flat = address.flat;
    this.id = id;
  }
  get_info(){
    return {
      taxpayerAccountCardNumber: this.taxpayerAccountCardNumber,
      isForeigner: this.isForeigner,
      name: this.name,
      address: {
        countryId: this.address.path.country,
        regionId: this.address.path.region,
        districtId: this.address.path.district,
        cityId: this.address.path.city,
        indexCode: this.address.path.index,
        streetId: this.address.path.street,
        building: this.address.path.build,
        corps: this.address.path.corps,
        flat: this.address.path.flat
      },
      id: this.id,
      additionalInfo: this.typeDescription
    }
  }
}

export class BasisDocument{
  visible_status = false;
  constructor(name, number, issuer, issueDate, id) {
    this.name =name;
    this.number = number;
    this.issuer = issuer;
    this.issueDate = issueDate.split('T')[0];
    this.id = id;
  }
  get_info(){
    const current_time = new Date();
    return {
      name: this.name,
      number: this.number,
      issuer: this.issuer,
      issueDate: (new Date(this.issueDate+'T'+current_time.toISOString().split('T')[1])).toISOString(),
      id: this.id,
    }
  }
}

export class EncumbranceInfo{
  visible_status = false;
  constructor(encumbranceKindId, registrationTypeId, lastEncumbranceOccurrenceDate, encumbranceTypeId, 
    alienationLimitId, typeDescription, id) {
    this.encumbranceKindId = encumbranceKindId;
    this.registrationTypeId = registrationTypeId;
    this.lastEncumbranceOccurrenceDate = lastEncumbranceOccurrenceDate.split('T')[0];
    this.encumbranceTypeId = encumbranceTypeId;
    this.alienationLimitId = alienationLimitId;
    this.typeDescription = typeDescription;
    this.id = id;
  }
  get_info(){
    const current_time = new Date();
    return {
      encumbranceKindId : this.encumbranceKindId,
      registrationTypeId : this.registrationTypeId,
      lastEncumbranceOccurrenceDate:(new Date(this.lastEncumbranceOccurrenceDate+'T'+current_time.toISOString().split('T')[1])).toISOString(),
      encumbranceTypeId: this.encumbranceTypeId,
      alienationLimitId: this.alienationLimitId,
      typeDescription: this.typeDescription,
      id: this.id,
    }
  }
}

export class EncumbranceTerm{
  visible_status = false;
  constructor(obligationAmount, termTo, additionalTerms, currencyTypeId, id) {
    this.obligationAmount = obligationAmount;
    this.termTo = termTo.split('T')[0];
    this.additionalTerms = additionalTerms;
    this.currencyTypeId = currencyTypeId;
    this.id = id;
  }
  get_info(){
    const current_time = new Date();
    return {
      obligationAmount: this.obligationAmount,
      termTo:(new Date(this.termTo+'T'+current_time.toISOString().split('T')[1])).toISOString(),
      additionalTerms: this.additionalTerms,
      currencyTypeId: this.currencyTypeId,
      id: this.id,
    }
  }
}

export class DescriptionSubject{
  name = null;
  number = null;
  number_2 = null;
  value = null;
  visible_status = false;
  constructor(objectDescription, serialNumber, stateRegistrationNumber, anotherObjectsDesc, id) {
    this.name = objectDescription;
    this.number = serialNumber;
    this.number_2 = stateRegistrationNumber;
    this.value = anotherObjectsDesc;
    this.id = id;
  }
  get_info(){
    return {
      objectDescription: this.name,
      serialNumber: this.number,
      stateRegistrationNumber: this.number_2,
      anotherObjectsDesc: this.value,
      id: this.id,
    }
  }
}

export class Changes{
  changes_checked = 2;
  changeTypechecked = 1
  constructor() {
  }
}
/*
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