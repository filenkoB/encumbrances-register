(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["regapplications"],{"00b4":function(t,e,a){"use strict";a("ac1f");var r=a("23e7"),n=a("da84"),i=a("c65b"),s=a("e330"),o=a("1626"),c=a("861d"),l=function(){var t=!1,e=/[ac]/;return e.exec=function(){return t=!0,/./.exec.apply(this,arguments)},!0===e.test("abc")&&t}(),u=n.Error,f=s(/./.test);r({target:"RegExp",proto:!0,forced:!l},{test:function(t){var e=this.exec;if(!o(e))return f(this,t);var a=i(e,this,t);if(null!==a&&!c(a))throw new u("RegExp exec method returned something other than an Object or null");return!!a}})},"057f":function(t,e,a){var r=a("c6b6"),n=a("fc6a"),i=a("241c").f,s=a("4dae"),o="object"==typeof window&&window&&Object.getOwnPropertyNames?Object.getOwnPropertyNames(window):[],c=function(t){try{return i(t)}catch(e){return s(o)}};t.exports.f=function(t){return o&&"Window"==r(t)?c(t):i(n(t))}},"428f":function(t,e,a){var r=a("da84");t.exports=r},"4df4":function(t,e,a){"use strict";var r=a("da84"),n=a("0366"),i=a("c65b"),s=a("7b0b"),o=a("9bdd"),c=a("e95a"),l=a("68ee"),u=a("07fa"),f=a("8418"),d=a("9a1f"),b=a("35a1"),p=r.Array;t.exports=function(t){var e=s(t),a=l(this),r=arguments.length,v=r>1?arguments[1]:void 0,m=void 0!==v;m&&(v=n(v,r>2?arguments[2]:void 0));var _,h,g,C,y,w,x=b(e),O=0;if(!x||this==p&&c(x))for(_=u(e),h=a?new this(_):p(_);_>O;O++)w=m?v(e[O],O):e[O],f(h,O,w);else for(C=d(e,x),y=C.next,h=a?new this:[];!(g=i(y,C)).done;O++)w=m?o(C,v,[g.value,O],!0):g.value,f(h,O,w);return h.length=O,h}},"746f":function(t,e,a){var r=a("428f"),n=a("1a2d"),i=a("e538"),s=a("9bf2").f;t.exports=function(t){var e=r.Symbol||(r.Symbol={});n(e,t)||s(e,t,{value:i.f(t)})}},"816a":function(t,e,a){"use strict";a("dfc5")},"9bdd":function(t,e,a){var r=a("825a"),n=a("2a62");t.exports=function(t,e,a,i){try{return i?e(r(a)[0],a[1]):e(a)}catch(s){n(t,"throw",s)}}},a4d3:function(t,e,a){"use strict";var r=a("23e7"),n=a("da84"),i=a("d066"),s=a("2ba4"),o=a("c65b"),c=a("e330"),l=a("c430"),u=a("83ab"),f=a("4930"),d=a("d039"),b=a("1a2d"),p=a("e8b5"),v=a("1626"),m=a("861d"),_=a("3a9b"),h=a("d9b5"),g=a("825a"),C=a("7b0b"),y=a("fc6a"),w=a("a04b"),x=a("577e"),O=a("5c6c"),S=a("7c73"),j=a("df75"),E=a("241c"),A=a("057f"),$=a("7418"),k=a("06cf"),I=a("9bf2"),R=a("d1e7"),N=a("f36a"),P=a("6eeb"),T=a("5692"),J=a("f772"),D=a("d012"),F=a("90e3"),M=a("b622"),q=a("e538"),Q=a("746f"),U=a("d44e"),W=a("69f3"),z=a("b727").forEach,B=J("hidden"),G="Symbol",H="prototype",K=M("toPrimitive"),L=W.set,V=W.getterFor(G),X=Object[H],Y=n.Symbol,Z=Y&&Y[H],tt=n.TypeError,et=n.QObject,at=i("JSON","stringify"),rt=k.f,nt=I.f,it=A.f,st=R.f,ot=c([].push),ct=T("symbols"),lt=T("op-symbols"),ut=T("string-to-symbol-registry"),ft=T("symbol-to-string-registry"),dt=T("wks"),bt=!et||!et[H]||!et[H].findChild,pt=u&&d((function(){return 7!=S(nt({},"a",{get:function(){return nt(this,"a",{value:7}).a}})).a}))?function(t,e,a){var r=rt(X,e);r&&delete X[e],nt(t,e,a),r&&t!==X&&nt(X,e,r)}:nt,vt=function(t,e){var a=ct[t]=S(Z);return L(a,{type:G,tag:t,description:e}),u||(a.description=e),a},mt=function(t,e,a){t===X&&mt(lt,e,a),g(t);var r=w(e);return g(a),b(ct,r)?(a.enumerable?(b(t,B)&&t[B][r]&&(t[B][r]=!1),a=S(a,{enumerable:O(0,!1)})):(b(t,B)||nt(t,B,O(1,{})),t[B][r]=!0),pt(t,r,a)):nt(t,r,a)},_t=function(t,e){g(t);var a=y(e),r=j(a).concat(wt(a));return z(r,(function(e){u&&!o(gt,a,e)||mt(t,e,a[e])})),t},ht=function(t,e){return void 0===e?S(t):_t(S(t),e)},gt=function(t){var e=w(t),a=o(st,this,e);return!(this===X&&b(ct,e)&&!b(lt,e))&&(!(a||!b(this,e)||!b(ct,e)||b(this,B)&&this[B][e])||a)},Ct=function(t,e){var a=y(t),r=w(e);if(a!==X||!b(ct,r)||b(lt,r)){var n=rt(a,r);return!n||!b(ct,r)||b(a,B)&&a[B][r]||(n.enumerable=!0),n}},yt=function(t){var e=it(y(t)),a=[];return z(e,(function(t){b(ct,t)||b(D,t)||ot(a,t)})),a},wt=function(t){var e=t===X,a=it(e?lt:y(t)),r=[];return z(a,(function(t){!b(ct,t)||e&&!b(X,t)||ot(r,ct[t])})),r};if(f||(Y=function(){if(_(Z,this))throw tt("Symbol is not a constructor");var t=arguments.length&&void 0!==arguments[0]?x(arguments[0]):void 0,e=F(t),a=function(t){this===X&&o(a,lt,t),b(this,B)&&b(this[B],e)&&(this[B][e]=!1),pt(this,e,O(1,t))};return u&&bt&&pt(X,e,{configurable:!0,set:a}),vt(e,t)},Z=Y[H],P(Z,"toString",(function(){return V(this).tag})),P(Y,"withoutSetter",(function(t){return vt(F(t),t)})),R.f=gt,I.f=mt,k.f=Ct,E.f=A.f=yt,$.f=wt,q.f=function(t){return vt(M(t),t)},u&&(nt(Z,"description",{configurable:!0,get:function(){return V(this).description}}),l||P(X,"propertyIsEnumerable",gt,{unsafe:!0}))),r({global:!0,wrap:!0,forced:!f,sham:!f},{Symbol:Y}),z(j(dt),(function(t){Q(t)})),r({target:G,stat:!0,forced:!f},{for:function(t){var e=x(t);if(b(ut,e))return ut[e];var a=Y(e);return ut[e]=a,ft[a]=e,a},keyFor:function(t){if(!h(t))throw tt(t+" is not a symbol");if(b(ft,t))return ft[t]},useSetter:function(){bt=!0},useSimple:function(){bt=!1}}),r({target:"Object",stat:!0,forced:!f,sham:!u},{create:ht,defineProperty:mt,defineProperties:_t,getOwnPropertyDescriptor:Ct}),r({target:"Object",stat:!0,forced:!f},{getOwnPropertyNames:yt,getOwnPropertySymbols:wt}),r({target:"Object",stat:!0,forced:d((function(){$.f(1)}))},{getOwnPropertySymbols:function(t){return $.f(C(t))}}),at){var xt=!f||d((function(){var t=Y();return"[null]"!=at([t])||"{}"!=at({a:t})||"{}"!=at(Object(t))}));r({target:"JSON",stat:!0,forced:xt},{stringify:function(t,e,a){var r=N(arguments),n=e;if((m(e)||void 0!==t)&&!h(t))return p(e)||(e=function(t,e){if(v(n)&&(e=o(n,this,t,e)),!h(e))return e}),r[1]=e,s(at,null,r)}})}if(!Z[K]){var Ot=Z.valueOf;P(Z,K,(function(t){return o(Ot,this)}))}U(Y,G),D[B]=!0},a630:function(t,e,a){var r=a("23e7"),n=a("4df4"),i=a("1c7e"),s=!i((function(t){Array.from(t)}));r({target:"Array",stat:!0,forced:s},{from:n})},b85c:function(t,e,a){"use strict";a.d(e,"a",(function(){return i}));a("a4d3"),a("e01a"),a("d3b7"),a("d28b"),a("3ca3"),a("ddb0"),a("fb6a"),a("b0c0"),a("a630"),a("ac1f"),a("00b4");function r(t,e){(null==e||e>t.length)&&(e=t.length);for(var a=0,r=new Array(e);a<e;a++)r[a]=t[a];return r}function n(t,e){if(t){if("string"===typeof t)return r(t,e);var a=Object.prototype.toString.call(t).slice(8,-1);return"Object"===a&&t.constructor&&(a=t.constructor.name),"Map"===a||"Set"===a?Array.from(t):"Arguments"===a||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(a)?r(t,e):void 0}}function i(t,e){var a="undefined"!==typeof Symbol&&t[Symbol.iterator]||t["@@iterator"];if(!a){if(Array.isArray(t)||(a=n(t))||e&&t&&"number"===typeof t.length){a&&(t=a);var r=0,i=function(){};return{s:i,n:function(){return r>=t.length?{done:!0}:{done:!1,value:t[r++]}},e:function(t){throw t},f:i}}throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}var s,o=!0,c=!1;return{s:function(){a=a.call(t)},n:function(){var t=a.next();return o=t.done,t},e:function(t){c=!0,s=t},f:function(){try{o||null==a["return"]||a["return"]()}finally{if(c)throw s}}}}},d28b:function(t,e,a){var r=a("746f");r("iterator")},dfc5:function(t,e,a){},e01a:function(t,e,a){"use strict";var r=a("23e7"),n=a("83ab"),i=a("da84"),s=a("e330"),o=a("1a2d"),c=a("1626"),l=a("3a9b"),u=a("577e"),f=a("9bf2").f,d=a("e893"),b=i.Symbol,p=b&&b.prototype;if(n&&c(b)&&(!("description"in p)||void 0!==b().description)){var v={},m=function(){var t=arguments.length<1||void 0===arguments[0]?void 0:u(arguments[0]),e=l(p,this)?new b(t):void 0===t?b():b(t);return""===t&&(v[e]=!0),e};d(m,b),m.prototype=p,p.constructor=m;var _="Symbol(test)"==String(b("test")),h=s(p.toString),g=s(p.valueOf),C=/^Symbol\((.*)\)[^)]+$/,y=s("".replace),w=s("".slice);f(p,"description",{configurable:!0,get:function(){var t=g(this),e=h(t);if(o(v,t))return"";var a=_?w(e,7,-1):y(e,C,"$1");return""===a?void 0:a}}),r({global:!0,forced:!0},{Symbol:m})}},e538:function(t,e,a){var r=a("b622");e.f=r},f95c:function(t,e,a){"use strict";a.r(e);var r=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row"},[t.applications.length>0?a("div",{attrs:{id:"applications_area"}},t._l(t.applications,(function(e){return a("div",{key:e.number,staticClass:"row m-1 border border-2 border-secondary rounded"},[a("div",{staticClass:"col-auto text-start pt-3"},[t._v("Вихідний номер: ")]),a("div",{staticClass:"col-2 text-start border-end border-4 pt-3"},[t._v(t._s(e.number))]),a("div",{staticClass:"col-auto text-start pt-3"},[t._v("Дата заявки: ")]),a("div",{staticClass:"col-2 text-start border-end border-4 pt-3"},[t._v(t._s(e.date))]),a("div",{staticClass:"col m-1 text-end"},[a("button",{staticClass:"btn btn-outline-info m-1",attrs:{type:"button"},on:{click:function(a){return t.get_application_info(e)}}},[t._v("Переглянути дані заявки")]),a("button",{staticClass:"btn btn-outline-success m-1",attrs:{type:"button",disabled:!e.visible_status},on:{click:function(a){return t.accept(e)}}},[t._v("Підтвердити")]),a("button",{staticClass:"btn btn-outline-danger m-1",attrs:{type:"button",disabled:!e.visible_status},on:{click:function(a){return t.decline(e)}}},[t._v("Відхилити")])]),e.visible_status?a("div",[a("system-reg-application",{attrs:{item:e}})],1):t._e()])})),0):a("div",{staticClass:"row border border-2 p-3 border-info rounded"},[a("div",{staticClass:"col text-center fs-5"},[t._v(" Наразі в системі відсутні заявки на реєстрацію користувачів. ")])]),t.applications.length>0?a("div",{staticClass:"row my-3"},[a("pagination",{attrs:{pagination:t.pagination,fun:t.get_applications}})],1):t._e()])},n=[],i=a("b85c"),s=a("1da1"),o=(a("96cf"),a("d3b7"),a("159b"),a("6b59")),c=a("6b15"),l=a("1799"),u=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row"},[a("div",{staticClass:"border border-4 col"},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-4 border-end border-4"},[t._m(0),a("div",{staticClass:"row border-bottom border-2"},[t._m(1),a("div",{staticClass:"col-7 "},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.lastName))])])]),a("div",{staticClass:"row border-bottom border-2"},[t._m(2),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.firstName))])])]),a("div",{staticClass:"row border-bottom border-2"},[t._m(3),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.patronymic))])])]),a("div",{staticClass:"row "},[t._m(4),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.birthDate.split("T")[0]))])])])]),a("div",{staticClass:"col"},[t._m(5),a("div",{staticClass:"row border-bottom border-2"},[t._m(6),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.passportInfo.passportNumber))])])]),t.application.passportInfo.serialNumber?a("div",{staticClass:"row border-bottom border-2"},[t._m(7),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.passportInfo.serialNumber))])])]):t._e(),a("div",{staticClass:"row border-bottom border-2"},[t._m(8),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.passportInfo.date.split("T")[0]))])])]),a("div",{staticClass:"row"},[t._m(9),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.passportInfo.authorityId))])])])])]),t._m(10),a("div",{staticClass:"row border-bottom border-2"},[t._m(11),a("div",{staticClass:"col-7"},[a("label",{staticClass:"col-form-label"},[t._v(t._s(t.application.email))])])]),a("div",{staticClass:"row border-bottom border-2"},[t._m(12),a("div",{staticClass:"col-7"},[2==t.application.userType?a("label",{staticClass:"col-form-label"},[t._v("Реєстратор")]):3==t.application.userType?a("label",{staticClass:"col-form-label"},[t._v("Користувач")]):t._e()])]),a("div",{staticClass:"row border-bottom border-2"},[t.application.authorityAddress?a("div",{staticClass:"col"},[a("label",{staticClass:"col-form-label"},[t._v("Працює в уповноваженому органі:")])]):a("div",{staticClass:"col"},[a("label",{staticClass:"col-form-label"},[t._v("Не працює в уповноваженому органі")])])]),t.application.authorityAddress?a("div",{staticClass:"row mt-2"},[a("p",[t._v("Адреса уповноваженого органу:")])]):t._e(),t.application.authorityAddress?a("Address",{attrs:{path:t.address.address.path,editing_status:!0}}):t._e()],1)])},f=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row border-bottom border-2 border-warning"},[a("div",{staticClass:"col text-center"},[a("label",{staticClass:"col-form-label"},[t._v("ПІБ та Дата народження")])])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Прізвище:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Ім'я:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("По-батькові:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Дата народження:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row border-bottom border-2 border-warning"},[a("div",{staticClass:"col text-center"},[a("label",{staticClass:"col-form-label"},[t._v("Паспортні дані")])])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Номер документа:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Серія:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Дата видачі документа:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Орган, що видав документ:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"row border-secondary border-top border-2"},[a("div",{staticClass:"col text-center border-bottom border-2 border-warning"},[a("label",{staticClass:"col-form-label"},[t._v("Інформація про користувача системи")])])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Електронна адреса:")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"col-5"},[a("label",{staticClass:"col-form-label"},[t._v("Роль у Реєстрі:")])])}],d=a("33c1"),b={data:function(){return{application:null,address:null}},name:"SystemRegApplication",props:["item"],components:{Address:d["a"]},created:function(){var t=this;return Object(s["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,Object(o["w"])(t.item.id);case 2:t.application=e.sent,console.log(t.application),null!=t.application.authorityAddress&&(console.log("hi"),t.address=new c["f"](null,null,null,null,t.application.authorityAddress));case 5:case"end":return e.stop()}}),e)})))()}},p=b,v=a("2877"),m=Object(v["a"])(p,u,f,!1,null,null,null),_=m.exports,h={name:"SystemRegApplications",data:function(){return{pagination:{active_page:0,max_items_count:5,count_page:0},applications:[]}},components:{SystemRegApplication:_,Pagination:l["a"]},methods:{pagination_page:function(t){this.pagination.active_page=t-1},get_applications:function(){var t=this;return Object(s["a"])(regeneratorRuntime.mark((function e(){var a;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return t.pagination.max_items_count=parseInt(t.pagination.max_items_count),t.pagination.max_items_count<1&&(t.pagination.max_items_count=1),t.pagination.max_items_count>7&&(t.pagination.max_items_count=7),e.next=5,Object(o["x"])(t.pagination.active_page+1,t.pagination.max_items_count);case 5:a=e.sent,a.maxStatements<t.pagination.max_items_count&&(t.pagination.max_items_count=a.maxStatements),t.pagination.count_page=Math.ceil(a.maxStatements/t.pagination.max_items_count),t.applications=[],a.statements.forEach((function(e){return t.applications.push(new c["i"](e.id,e.number,e.date,null))}));case 10:case"end":return e.stop()}}),e)})))()},get_application_info:function(t){this.closeInfo(t),t.visible_status=!t.visible_status},accept:function(t){return Object(s["a"])(regeneratorRuntime.mark((function e(){var a;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,Object(o["w"])(t.id);case 2:if(a=e.sent,2!=a.userType){e.next=8;break}return e.next=6,Object(o["t"])(t.id);case 6:e.next=10;break;case 8:return e.next=10,Object(o["p"])(t.id);case 10:case"end":return e.stop()}}),e)})))()},decline:function(t){return Object(s["a"])(regeneratorRuntime.mark((function e(){var a,r;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,Object(o["w"])(t.id);case 2:if(a=e.sent,r="Шановний '"+a.lastName+" "+a.firstName+" "+a.patronymic+". Вам відмовлено в наданні доступу для використання ресурсів Державного реєстру обтяжень рухомого майна. Для вирішення непорозуміння перевірте актуальність данних необхідних для реєстрації та повторіть спробу.",2!=a.userType){e.next=9;break}return e.next=7,Object(o["u"])(t.id,a.email,r);case 7:e.next=11;break;case 9:return e.next=11,Object(o["q"])(t.id,a.email,r);case 11:case"end":return e.stop()}}),e)})))()},closeInfo:function(t){var e,a=Object(i["a"])(this.applications);try{for(a.s();!(e=a.n()).done;){var r=e.value;r!==t&&(r.visible_status=!1)}}catch(n){a.e(n)}finally{a.f()}}},mounted:function(){this.user_status=window.sessionStorage.getItem("user_status"),this.user_status&&"admin"==this.user_status||this.$router.push({name:"Info"}).catch((function(){}))},created:function(){var t=this;return Object(s["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:t.get_applications();case 1:case"end":return e.stop()}}),e)})))()}},g=h,C=(a("816a"),Object(v["a"])(g,r,n,!1,null,null,null));e["default"]=C.exports}}]);
//# sourceMappingURL=regapplications.28692a70.js.map