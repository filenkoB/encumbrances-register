(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["registration"],{"00b4":function(t,e,a){"use strict";a("ac1f");var r=a("23e7"),s=a("da84"),n=a("c65b"),i=a("e330"),o=a("1626"),c=a("861d"),l=function(){var t=!1,e=/[ac]/;return e.exec=function(){return t=!0,/./.exec.apply(this,arguments)},!0===e.test("abc")&&t}(),u=s.Error,d=i(/./.test);r({target:"RegExp",proto:!0,forced:!l},{test:function(t){var e=this.exec;if(!o(e))return d(this,t);var a=n(e,this,t);if(null!==a&&!c(a))throw new u("RegExp exec method returned something other than an Object or null");return!!a}})},"057f":function(t,e,a){var r=a("c6b6"),s=a("fc6a"),n=a("241c").f,i=a("4dae"),o="object"==typeof window&&window&&Object.getOwnPropertyNames?Object.getOwnPropertyNames(window):[],c=function(t){try{return n(t)}catch(e){return i(o)}};t.exports.f=function(t){return o&&"Window"==r(t)?c(t):n(s(t))}},"27fd":function(t,e,a){"use strict";a("662c")},"3fd1":function(t,e,a){"use strict";a.r(e);var r=function(){var t=this,e=t.$createElement,a=t._self._c||e;return t.registration?a("form",{staticClass:"row",on:{submit:function(e){return e.preventDefault(),t.regIn.apply(null,arguments)}}},[a("div",{staticClass:"col-2"}),a("div",{staticClass:"col-8"},[a("div",{staticClass:"row"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.lastName,expression:"lastName"}],staticClass:"form-control",attrs:{type:"text",pattern:t.patterns.lastName.str,required:"",placeholder:" "},domProps:{value:t.lastName},on:{input:function(e){e.target.composing||(t.lastName=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Прізвище")])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.firstName,expression:"firstName"}],staticClass:"form-control",attrs:{type:"text",pattern:t.patterns.names.str,required:"",placeholder:" "},domProps:{value:t.firstName},on:{input:function(e){e.target.composing||(t.firstName=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Ім'я")])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.parentName,expression:"parentName"}],staticClass:"form-control",attrs:{type:"text",pattern:t.patterns.names.str,required:"",placeholder:" "},domProps:{value:t.parentName},on:{input:function(e){e.target.composing||(t.parentName=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("По-батькові")])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.birthDate,expression:"birthDate"}],staticClass:"form-control",attrs:{type:"date",required:"",max:t.maxBirthDate,placeholder:" "},domProps:{value:t.birthDate},on:{input:function(e){e.target.composing||(t.birthDate=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Дата народження")])])]),a("div",{staticClass:"p-3 border border-secondary border-2 rounded mt-3"},[a("div",{staticClass:"input-group"},[a("label",{staticClass:"form-check-label me-1"},[t._v("Тип паспорта:")]),t._l(t.pasTypes,(function(e){return a("div",{key:e.id},[a("div",{staticClass:"form-check form-check-inline"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.chosenPassType,expression:"chosenPassType"}],staticClass:"form-check-input",attrs:{type:"radio"},domProps:{value:e.id,checked:t._q(t.chosenPassType,e.id)},on:{change:function(a){t.chosenPassType=e.id}}}),a("label",{staticClass:"form-check-label",attrs:{for:e.id}},[t._v(t._s(e.text))])])])}))],2),"pasType-Id"===t.chosenPassType?a("div",[a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.pasNumber,expression:"pasNumber"}],staticClass:"form-control",attrs:{type:"text",required:"",pattern:"\\d{9}",placeholder:" "},domProps:{value:t.pasNumber},on:{input:function(e){e.target.composing||(t.pasNumber=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Номер документа")])])]),a("div",{staticClass:"row mt-3"},[t._m(0),a("div",{staticClass:"col-auto"},[a("select",{directives:[{name:"model",rawName:"v-model",value:t.pasAgency,expression:"pasAgency"}],staticClass:"form-control",on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.pasAgency=e.target.multiple?a:a[0]}}},t._l(t.authorityPassport,(function(e){return a("option",{key:e.code,domProps:{value:e.code}},[t._v(t._s(e.code)+"-"+t._s(e.name))])})),0)])])]):a("div",[a("div",{staticClass:"input-group mt-3"},[a("span",{staticClass:"input-group-text"},[t._v("Серія")]),a("input",{directives:[{name:"model",rawName:"v-model",value:t.pasSeriaB,expression:"pasSeriaB"}],staticClass:"form-control",staticStyle:{"max-width":"55px"},attrs:{required:"",pattern:"[А-ЯІЇЄ]{2}"},domProps:{value:t.pasSeriaB},on:{input:function(e){e.target.composing||(t.pasSeriaB=e.target.value)}}}),a("span",{staticClass:"input-group-text"},[t._v("Номер")]),a("input",{directives:[{name:"model",rawName:"v-model",value:t.pasNumberB,expression:"pasNumberB"}],staticClass:"form-control",attrs:{required:"",pattern:"\\d{6}"},domProps:{value:t.pasNumberB},on:{input:function(e){e.target.composing||(t.pasNumberB=e.target.value)}}})]),a("div",{staticClass:"row mt-3"},[t._m(1),a("div",{staticClass:"col-auto"},[a("select",{directives:[{name:"model",rawName:"v-model",value:t.pasAgencyB,expression:"pasAgencyB"}],staticClass:"form-control",on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.pasAgencyB=e.target.multiple?a:a[0]}}},t._l(t.authorityPassport,(function(e){return a("option",{key:e.code,domProps:{value:e.code}},[t._v(t._s(e.name))])})),0)])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.pasDate,expression:"pasDate"}],staticClass:"form-control",attrs:{type:"date",required:"",min:t.minPasDate,max:t.today,placeholder:" "},domProps:{value:t.pasDate},on:{input:function(e){e.target.composing||(t.pasDate=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Дата видачі паспорта")])])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.idNumber,expression:"idNumber"}],staticClass:"form-control",attrs:{type:"text",required:"",pattern:t.patterns.idNumber.str,placeholder:" "},domProps:{value:t.idNumber},on:{input:function(e){e.target.composing||(t.idNumber=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Номер картки платника податків")])])]),a("div",{staticClass:"row mt-3"},[a("div",{staticClass:"form-floating"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.email,expression:"email"}],staticClass:"form-control",attrs:{type:"email",required:"",pattern:t.patterns.email.str,placeholder:" "},domProps:{value:t.email},on:{input:function(e){e.target.composing||(t.email=e.target.value)}}}),a("label",{staticClass:"ms-2 vertical-center"},[t._v("Електронна адреса")])])]),a("div",{staticClass:"row mt-3 text-start"},[t._m(2),a("div",{staticClass:"col"},t._l(t.roles,(function(e){return a("div",{key:e.id,staticClass:"row"},[a("div",{staticClass:"form-check"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.chosenRole,expression:"chosenRole"}],staticClass:"form-check-input",attrs:{type:"radio"},domProps:{value:e.id,checked:t._q(t.chosenRole,e.id)},on:{change:[function(a){t.chosenRole=e.id},t.clearRoleData]}}),a("label",{staticClass:"form-check-label",attrs:{for:e.id}},[t._v(t._s(e.value))])])])})),0)]),"user"===t.chosenRole?a("div",[a("div",{staticClass:"form-check mt-3"},[a("input",{directives:[{name:"model",rawName:"v-model",value:t.userIsAuthorized,expression:"userIsAuthorized"}],staticClass:"form-check-input",attrs:{type:"checkbox"},domProps:{checked:Array.isArray(t.userIsAuthorized)?t._i(t.userIsAuthorized,null)>-1:t.userIsAuthorized},on:{change:function(e){var a=t.userIsAuthorized,r=e.target,s=!!r.checked;if(Array.isArray(a)){var n=null,i=t._i(a,n);r.checked?i<0&&(t.userIsAuthorized=a.concat([n])):i>-1&&(t.userIsAuthorized=a.slice(0,i).concat(a.slice(i+1)))}else t.userIsAuthorized=s}}}),a("label",{staticClass:"form-check-label"},[t._v("Працюю в уповноваженому органі")])])]):t._e(),"user"!==t.chosenRole||t.userIsAuthorized||"registrar"===t.chosenRole?a("div",{staticClass:"mt-3 p-3 border border-secondary border-2 rounded"},[a("label",{staticClass:"mb-3"},[t._v("Державна установа:")]),a("select",{directives:[{name:"model",rawName:"v-model",value:t.authorityId,expression:"authorityId"}],staticClass:"form-control",on:{change:function(e){var a=Array.prototype.filter.call(e.target.options,(function(t){return t.selected})).map((function(t){var e="_value"in t?t._value:t.value;return e}));t.authorityId=e.target.multiple?a:a[0]}}},t._l(t.authority,(function(e){return a("option",{key:e.id,domProps:{value:e.id}},[t._v(t._s(e.name))])})),0)]):t._e(),t._m(3)]),a("div",{staticClass:"col"})]):a("div",[t._m(4)])},s=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-auto mt-2"},[a("label",{staticClass:"ms-2 vertical-center"},[t._v("Орган, що видав документ")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-auto mt-2"},[a("label",{staticClass:"ms-2 vertical-center"},[t._v("Орган, що видав документ")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-auto"},[a("label",{staticClass:"form-check-label me-1"},[t._v("Роль:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row mt-3"},[a("button",{staticClass:"w-100 btn btn-outline-dark",attrs:{type:"submit"}},[t._v("Подати заявку на реєстрацію")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"alert alert-success text-center",attrs:{role:"alert"}},[a("h4",{staticClass:"alert-heading "},[t._v("Заявка на реєстрацію була успішно відправлена!")]),a("p",[t._v('Заявка на реєстрацію профілю в "Державному реєстрі обтяженнь рухомого майна" була сформована на основі введенних вами даних та успішно відправлена для розгляду адміністраторами системи. Очікуйте результати реєстрації найближчим часом.')]),a("hr"),a("p",{staticClass:"mb-0"},[t._v("Результати реєстації будуть надіслані на вказану вами під час реєстрації електронну адресу.")])])}],n=a("b85c"),i=a("1da1"),o=(a("96cf"),a("f601")),c=a("6b59"),l={name:"registration",data:function(){return{authorityPassport:null,authority:null,authorityId:null,registration:!0,chosenPassType:"pasType-Id",chosenRole:"user",firstName:"",lastName:"",parentName:"",birthDate:"",pasNumber:"",pasNumberB:"",pasSeriaB:"",email:"",agency:"",idNumber:"",pasAgency:"",pasAgencyB:"",pasDate:"",userIsAuthorized:!1}},methods:{regIn:function(){var t=this;return Object(i["a"])(regeneratorRuntime.mark((function e(){var a,r,s,i,o,l,u;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:a=document.getElementsByTagName("input"),r=!0,s=Object(n["a"])(a),e.prev=3,s.s();case 5:if((i=s.n()).done){e.next=12;break}if(o=i.value,!1!==o.validity.valid){e.next=10;break}return r=!1,e.abrupt("break",12);case 10:e.next=5;break;case 12:e.next=17;break;case 14:e.prev=14,e.t0=e["catch"](3),s.e(e.t0);case 17:return e.prev=17,s.f(),e.finish(17);case 20:if(!r){e.next=32;break}if(t.registration=!1,l=null,l="pasType-Id"==t.chosenPassType?{passportNumber:t.pasNumber,SerialNumber:"",AuthorityId:t.pasAgency,date:t.pasDate}:{passportNumber:t.pasNumberB,SerialNumber:t.pasSeriaB,AuthorityId:t.pasAgencyB,date:t.pasDate},u={firstName:t.firstName,lastName:t.lastName,patronymic:t.parentName,birthDate:t.birthDate,email:t.email,passportInfo:l,taxpayerAccountCardNumber:t.idNumber,taxpayerACNAbsenceReason:"",authorityId:t.authorityId},"user"!=t.chosenRole){e.next=30;break}return e.next=28,Object(c["v"])(u);case 28:e.next=32;break;case 30:return e.next=32,Object(c["r"])(u);case 32:case"end":return e.stop()}}),e,null,[[3,14,17,20]])})))()},clearPasData:function(t){"pasType-Id"===t?(this.pasSeriaB="",this.pasNumberB="",this.pasAgencyB=""):(this.pasAgency="",this.pasNumber=""),this.pasDate=""},clearRoleData:function(){this.agency="",this.userIsAuthorized=!1}},watch:{chosenPassType:function(t){this.clearPasData(t),this.minPasDate="pasType-Id"===t?o["a"].minIdPasDate:o["a"].minBookPasDate}},created:function(){var t=this;return Object(i["a"])(regeneratorRuntime.mark((function e(){var a;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return a=window.sessionStorage,a.getItem("token")&&a.removeItem("token"),a.getItem("user_status")&&a.removeItem("user_status"),t.$root.$children[0].$children[0].user_status=null,t.patterns=o["a"].patterns,t.today=o["a"].today,t.maxBirthDate=o["a"].maxBirthDate,t.minPasDate=o["a"].minIdPasDate,t.roles=[{id:"user",value:"Користувач"},{id:"registrar",value:"Реєстратор"}],t.pasTypes=[{id:"pasType-Id",text:"ID-картка"},{id:"pasType-Book",text:"Зразка 1994р.(Книжка)"}],e.next=12,Object(c["d"])();case 12:return t.authorityPassport=e.sent,e.next=15,Object(c["c"])();case 15:t.authority=e.sent;case 16:case"end":return e.stop()}}),e)})))()}},u=l,d=(a("27fd"),a("2877")),m=Object(d["a"])(u,r,s,!1,null,null,null);e["default"]=m.exports},"428f":function(t,e,a){var r=a("da84");t.exports=r},"4df4":function(t,e,a){"use strict";var r=a("da84"),s=a("0366"),n=a("c65b"),i=a("7b0b"),o=a("9bdd"),c=a("e95a"),l=a("68ee"),u=a("07fa"),d=a("8418"),m=a("9a1f"),p=a("35a1"),f=r.Array;t.exports=function(t){var e=i(t),a=l(this),r=arguments.length,v=r>1?arguments[1]:void 0,h=void 0!==v;h&&(v=s(v,r>2?arguments[2]:void 0));var b,y,g,C,w,N,_=p(e),x=0;if(!_||this==f&&c(_))for(b=u(e),y=a?new this(b):f(b);b>x;x++)N=h?v(e[x],x):e[x],d(y,x,N);else for(C=m(e,_),w=C.next,y=a?new this:[];!(g=n(w,C)).done;x++)N=h?o(C,v,[g.value,x],!0):g.value,d(y,x,N);return y.length=x,y}},"662c":function(t,e,a){},"746f":function(t,e,a){var r=a("428f"),s=a("1a2d"),n=a("e538"),i=a("9bf2").f;t.exports=function(t){var e=r.Symbol||(r.Symbol={});s(e,t)||i(e,t,{value:n.f(t)})}},"9bdd":function(t,e,a){var r=a("825a"),s=a("2a62");t.exports=function(t,e,a,n){try{return n?e(r(a)[0],a[1]):e(a)}catch(i){s(t,"throw",i)}}},a4d3:function(t,e,a){"use strict";var r=a("23e7"),s=a("da84"),n=a("d066"),i=a("2ba4"),o=a("c65b"),c=a("e330"),l=a("c430"),u=a("83ab"),d=a("4930"),m=a("d039"),p=a("1a2d"),f=a("e8b5"),v=a("1626"),h=a("861d"),b=a("3a9b"),y=a("d9b5"),g=a("825a"),C=a("7b0b"),w=a("fc6a"),N=a("a04b"),_=a("577e"),x=a("5c6c"),A=a("7c73"),P=a("df75"),k=a("241c"),I=a("057f"),S=a("7418"),D=a("06cf"),O=a("9bf2"),B=a("d1e7"),j=a("f36a"),T=a("6eeb"),R=a("5692"),E=a("f772"),q=a("d012"),z=a("90e3"),$=a("b622"),J=a("e538"),F=a("746f"),M=a("d44e"),Q=a("69f3"),U=a("b727").forEach,W=E("hidden"),G="Symbol",H="prototype",K=$("toPrimitive"),L=Q.set,V=Q.getterFor(G),X=Object[H],Y=s.Symbol,Z=Y&&Y[H],tt=s.TypeError,et=s.QObject,at=n("JSON","stringify"),rt=D.f,st=O.f,nt=I.f,it=B.f,ot=c([].push),ct=R("symbols"),lt=R("op-symbols"),ut=R("string-to-symbol-registry"),dt=R("symbol-to-string-registry"),mt=R("wks"),pt=!et||!et[H]||!et[H].findChild,ft=u&&m((function(){return 7!=A(st({},"a",{get:function(){return st(this,"a",{value:7}).a}})).a}))?function(t,e,a){var r=rt(X,e);r&&delete X[e],st(t,e,a),r&&t!==X&&st(X,e,r)}:st,vt=function(t,e){var a=ct[t]=A(Z);return L(a,{type:G,tag:t,description:e}),u||(a.description=e),a},ht=function(t,e,a){t===X&&ht(lt,e,a),g(t);var r=N(e);return g(a),p(ct,r)?(a.enumerable?(p(t,W)&&t[W][r]&&(t[W][r]=!1),a=A(a,{enumerable:x(0,!1)})):(p(t,W)||st(t,W,x(1,{})),t[W][r]=!0),ft(t,r,a)):st(t,r,a)},bt=function(t,e){g(t);var a=w(e),r=P(a).concat(Nt(a));return U(r,(function(e){u&&!o(gt,a,e)||ht(t,e,a[e])})),t},yt=function(t,e){return void 0===e?A(t):bt(A(t),e)},gt=function(t){var e=N(t),a=o(it,this,e);return!(this===X&&p(ct,e)&&!p(lt,e))&&(!(a||!p(this,e)||!p(ct,e)||p(this,W)&&this[W][e])||a)},Ct=function(t,e){var a=w(t),r=N(e);if(a!==X||!p(ct,r)||p(lt,r)){var s=rt(a,r);return!s||!p(ct,r)||p(a,W)&&a[W][r]||(s.enumerable=!0),s}},wt=function(t){var e=nt(w(t)),a=[];return U(e,(function(t){p(ct,t)||p(q,t)||ot(a,t)})),a},Nt=function(t){var e=t===X,a=nt(e?lt:w(t)),r=[];return U(a,(function(t){!p(ct,t)||e&&!p(X,t)||ot(r,ct[t])})),r};if(d||(Y=function(){if(b(Z,this))throw tt("Symbol is not a constructor");var t=arguments.length&&void 0!==arguments[0]?_(arguments[0]):void 0,e=z(t),a=function(t){this===X&&o(a,lt,t),p(this,W)&&p(this[W],e)&&(this[W][e]=!1),ft(this,e,x(1,t))};return u&&pt&&ft(X,e,{configurable:!0,set:a}),vt(e,t)},Z=Y[H],T(Z,"toString",(function(){return V(this).tag})),T(Y,"withoutSetter",(function(t){return vt(z(t),t)})),B.f=gt,O.f=ht,D.f=Ct,k.f=I.f=wt,S.f=Nt,J.f=function(t){return vt($(t),t)},u&&(st(Z,"description",{configurable:!0,get:function(){return V(this).description}}),l||T(X,"propertyIsEnumerable",gt,{unsafe:!0}))),r({global:!0,wrap:!0,forced:!d,sham:!d},{Symbol:Y}),U(P(mt),(function(t){F(t)})),r({target:G,stat:!0,forced:!d},{for:function(t){var e=_(t);if(p(ut,e))return ut[e];var a=Y(e);return ut[e]=a,dt[a]=e,a},keyFor:function(t){if(!y(t))throw tt(t+" is not a symbol");if(p(dt,t))return dt[t]},useSetter:function(){pt=!0},useSimple:function(){pt=!1}}),r({target:"Object",stat:!0,forced:!d,sham:!u},{create:yt,defineProperty:ht,defineProperties:bt,getOwnPropertyDescriptor:Ct}),r({target:"Object",stat:!0,forced:!d},{getOwnPropertyNames:wt,getOwnPropertySymbols:Nt}),r({target:"Object",stat:!0,forced:m((function(){S.f(1)}))},{getOwnPropertySymbols:function(t){return S.f(C(t))}}),at){var _t=!d||m((function(){var t=Y();return"[null]"!=at([t])||"{}"!=at({a:t})||"{}"!=at(Object(t))}));r({target:"JSON",stat:!0,forced:_t},{stringify:function(t,e,a){var r=j(arguments),s=e;if((h(e)||void 0!==t)&&!y(t))return f(e)||(e=function(t,e){if(v(s)&&(e=o(s,this,t,e)),!y(e))return e}),r[1]=e,i(at,null,r)}})}if(!Z[K]){var xt=Z.valueOf;T(Z,K,(function(t){return o(xt,this)}))}M(Y,G),q[W]=!0},a630:function(t,e,a){var r=a("23e7"),s=a("4df4"),n=a("1c7e"),i=!n((function(t){Array.from(t)}));r({target:"Array",stat:!0,forced:i},{from:s})},b85c:function(t,e,a){"use strict";a.d(e,"a",(function(){return n}));a("a4d3"),a("e01a"),a("d3b7"),a("d28b"),a("3ca3"),a("ddb0"),a("fb6a"),a("b0c0"),a("a630"),a("ac1f"),a("00b4");function r(t,e){(null==e||e>t.length)&&(e=t.length);for(var a=0,r=new Array(e);a<e;a++)r[a]=t[a];return r}function s(t,e){if(t){if("string"===typeof t)return r(t,e);var a=Object.prototype.toString.call(t).slice(8,-1);return"Object"===a&&t.constructor&&(a=t.constructor.name),"Map"===a||"Set"===a?Array.from(t):"Arguments"===a||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(a)?r(t,e):void 0}}function n(t,e){var a="undefined"!==typeof Symbol&&t[Symbol.iterator]||t["@@iterator"];if(!a){if(Array.isArray(t)||(a=s(t))||e&&t&&"number"===typeof t.length){a&&(t=a);var r=0,n=function(){};return{s:n,n:function(){return r>=t.length?{done:!0}:{done:!1,value:t[r++]}},e:function(t){throw t},f:n}}throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}var i,o=!0,c=!1;return{s:function(){a=a.call(t)},n:function(){var t=a.next();return o=t.done,t},e:function(t){c=!0,i=t},f:function(){try{o||null==a["return"]||a["return"]()}finally{if(c)throw i}}}}},d28b:function(t,e,a){var r=a("746f");r("iterator")},e01a:function(t,e,a){"use strict";var r=a("23e7"),s=a("83ab"),n=a("da84"),i=a("e330"),o=a("1a2d"),c=a("1626"),l=a("3a9b"),u=a("577e"),d=a("9bf2").f,m=a("e893"),p=n.Symbol,f=p&&p.prototype;if(s&&c(p)&&(!("description"in f)||void 0!==p().description)){var v={},h=function(){var t=arguments.length<1||void 0===arguments[0]?void 0:u(arguments[0]),e=l(f,this)?new p(t):void 0===t?p():p(t);return""===t&&(v[e]=!0),e};m(h,p),h.prototype=f,f.constructor=h;var b="Symbol(test)"==String(p("test")),y=i(f.toString),g=i(f.valueOf),C=/^Symbol\((.*)\)[^)]+$/,w=i("".replace),N=i("".slice);d(f,"description",{configurable:!0,get:function(){var t=g(this),e=y(t);if(o(v,t))return"";var a=b?N(e,7,-1):w(e,C,"$1");return""===a?void 0:a}}),r({global:!0,forced:!0},{Symbol:h})}},e538:function(t,e,a){var r=a("b622");e.f=r}}]);
//# sourceMappingURL=registration.74f054e2.js.map