(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["Statments~regapplications~registration"],{"0b42":function(e,t,r){var n=r("da84"),a=r("e8b5"),c=r("68ee"),o=r("861d"),i=r("b622"),u=i("species"),s=n.Array;e.exports=function(e){var t;return a(e)&&(t=e.constructor,c(t)&&(t===s||a(t.prototype))?t=void 0:o(t)&&(t=t[u],null===t&&(t=void 0))),void 0===t?s:t}},"0cb2":function(e,t,r){var n=r("e330"),a=r("7b0b"),c=Math.floor,o=n("".charAt),i=n("".replace),u=n("".slice),s=/\$([$&'`]|\d{1,2}|<[^>]*>)/g,f=/\$([$&'`]|\d{1,2})/g;e.exports=function(e,t,r,n,l,d){var v=r+e.length,p=n.length,g=f;return void 0!==l&&(l=a(l),g=s),i(d,g,(function(a,i){var s;switch(o(i,0)){case"$":return"$";case"&":return e;case"`":return u(t,0,r);case"'":return u(t,v);case"<":s=l[u(i,1,-1)];break;default:var f=+i;if(0===f)return a;if(f>p){var d=c(f/10);return 0===d?a:d<=p?void 0===n[d-1]?o(i,1):n[d-1]+o(i,1):a}s=n[f-1]}return void 0===s?"":s}))}},"107c":function(e,t,r){var n=r("d039"),a=r("da84"),c=a.RegExp;e.exports=n((function(){var e=c("(?<a>b)","g");return"b"!==e.exec("b").groups.a||"bc"!=="b".replace(e,"$<a>c")}))},"14c3":function(e,t,r){var n=r("da84"),a=r("c65b"),c=r("825a"),o=r("1626"),i=r("c6b6"),u=r("9263"),s=n.TypeError;e.exports=function(e,t){var r=e.exec;if(o(r)){var n=a(r,e,t);return null!==n&&c(n),n}if("RegExp"===i(e))return a(u,e,t);throw s("RegExp#exec called on incompatible receiver")}},"159b":function(e,t,r){var n=r("da84"),a=r("fdbc"),c=r("785a"),o=r("17c2"),i=r("9112"),u=function(e){if(e&&e.forEach!==o)try{i(e,"forEach",o)}catch(t){e.forEach=o}};for(var s in a)a[s]&&u(n[s]&&n[s].prototype);u(c)},"17c2":function(e,t,r){"use strict";var n=r("b727").forEach,a=r("a640"),c=a("forEach");e.exports=c?[].forEach:function(e){return n(this,e,arguments.length>1?arguments[1]:void 0)}},"1dde":function(e,t,r){var n=r("d039"),a=r("b622"),c=r("2d00"),o=a("species");e.exports=function(e){return c>=51||!n((function(){var t=[],r=t.constructor={};return r[o]=function(){return{foo:1}},1!==t[e](Boolean).foo}))}},5319:function(e,t,r){"use strict";var n=r("2ba4"),a=r("c65b"),c=r("e330"),o=r("d784"),i=r("d039"),u=r("825a"),s=r("1626"),f=r("5926"),l=r("50c4"),d=r("577e"),v=r("1d80"),p=r("8aa5"),g=r("dc4a"),b=r("0cb2"),x=r("14c3"),h=r("b622"),y=h("replace"),m=Math.max,E=Math.min,I=c([].concat),w=c([].push),$=c("".indexOf),R=c("".slice),A=function(e){return void 0===e?e:String(e)},S=function(){return"$0"==="a".replace(/./,"$0")}(),k=function(){return!!/./[y]&&""===/./[y]("a","$0")}(),_=!i((function(){var e=/./;return e.exec=function(){var e=[];return e.groups={a:"7"},e},"7"!=="".replace(e,"$<a>")}));o("replace",(function(e,t,r){var c=k?"$":"$0";return[function(e,r){var n=v(this),c=void 0==e?void 0:g(e,y);return c?a(c,e,n,r):a(t,d(n),e,r)},function(e,a){var o=u(this),i=d(e);if("string"==typeof a&&-1===$(a,c)&&-1===$(a,"$<")){var v=r(t,o,i,a);if(v.done)return v.value}var g=s(a);g||(a=d(a));var h=o.global;if(h){var y=o.unicode;o.lastIndex=0}var S=[];while(1){var k=x(o,i);if(null===k)break;if(w(S,k),!h)break;var _=d(k[0]);""===_&&(o.lastIndex=p(i,l(o.lastIndex),y))}for(var D="",M=0,O=0;O<S.length;O++){k=S[O];for(var N=d(k[0]),T=m(E(f(k.index),i.length),0),Y=[],F=1;F<k.length;F++)w(Y,A(k[F]));var B=k.groups;if(g){var C=I([N],Y,T,i);void 0!==B&&w(C,B);var j=d(n(a,void 0,C))}else j=b(N,i,T,Y,B,a);T>=M&&(D+=R(i,M,T)+j,M=T+N.length)}return D+R(i,M)}]}),!_||!S||k)},"65f0":function(e,t,r){var n=r("0b42");e.exports=function(e,t){return new(n(e))(0===t?0:t)}},8418:function(e,t,r){"use strict";var n=r("a04b"),a=r("9bf2"),c=r("5c6c");e.exports=function(e,t,r){var o=n(t);o in e?a.f(e,o,c(0,r)):e[o]=r}},"8aa5":function(e,t,r){"use strict";var n=r("6547").charAt;e.exports=function(e,t,r){return t+(r?n(e,t).length:1)}},9263:function(e,t,r){"use strict";var n=r("c65b"),a=r("e330"),c=r("577e"),o=r("ad6d"),i=r("9f7f"),u=r("5692"),s=r("7c73"),f=r("69f3").get,l=r("fce3"),d=r("107c"),v=u("native-string-replace",String.prototype.replace),p=RegExp.prototype.exec,g=p,b=a("".charAt),x=a("".indexOf),h=a("".replace),y=a("".slice),m=function(){var e=/a/,t=/b*/g;return n(p,e,"a"),n(p,t,"a"),0!==e.lastIndex||0!==t.lastIndex}(),E=i.BROKEN_CARET,I=void 0!==/()??/.exec("")[1],w=m||I||E||l||d;w&&(g=function(e){var t,r,a,i,u,l,d,w=this,$=f(w),R=c(e),A=$.raw;if(A)return A.lastIndex=w.lastIndex,t=n(g,A,R),w.lastIndex=A.lastIndex,t;var S=$.groups,k=E&&w.sticky,_=n(o,w),D=w.source,M=0,O=R;if(k&&(_=h(_,"y",""),-1===x(_,"g")&&(_+="g"),O=y(R,w.lastIndex),w.lastIndex>0&&(!w.multiline||w.multiline&&"\n"!==b(R,w.lastIndex-1))&&(D="(?: "+D+")",O=" "+O,M++),r=new RegExp("^(?:"+D+")",_)),I&&(r=new RegExp("^"+D+"$(?!\\s)",_)),m&&(a=w.lastIndex),i=n(p,k?r:w,O),k?i?(i.input=y(i.input,M),i[0]=y(i[0],M),i.index=w.lastIndex,w.lastIndex+=i[0].length):w.lastIndex=0:m&&i&&(w.lastIndex=w.global?i.index+i[0].length:a),I&&i&&i.length>1&&n(v,i[0],r,(function(){for(u=1;u<arguments.length-2;u++)void 0===arguments[u]&&(i[u]=void 0)})),i&&S)for(i.groups=l=s(null),u=0;u<S.length;u++)d=S[u],l[d[0]]=i[d[1]];return i}),e.exports=g},"9f7f":function(e,t,r){var n=r("d039"),a=r("da84"),c=a.RegExp,o=n((function(){var e=c("a","y");return e.lastIndex=2,null!=e.exec("abcd")})),i=o||n((function(){return!c("a","y").sticky})),u=o||n((function(){var e=c("^r","gy");return e.lastIndex=2,null!=e.exec("str")}));e.exports={BROKEN_CARET:u,MISSED_STICKY:i,UNSUPPORTED_Y:o}},a640:function(e,t,r){"use strict";var n=r("d039");e.exports=function(e,t){var r=[][e];return!!r&&n((function(){r.call(null,t||function(){throw 1},1)}))}},ac1f:function(e,t,r){"use strict";var n=r("23e7"),a=r("9263");n({target:"RegExp",proto:!0,forced:/./.exec!==a},{exec:a})},ad6d:function(e,t,r){"use strict";var n=r("825a");e.exports=function(){var e=n(this),t="";return e.global&&(t+="g"),e.ignoreCase&&(t+="i"),e.multiline&&(t+="m"),e.dotAll&&(t+="s"),e.unicode&&(t+="u"),e.sticky&&(t+="y"),t}},b0c0:function(e,t,r){var n=r("83ab"),a=r("5e77").EXISTS,c=r("e330"),o=r("9bf2").f,i=Function.prototype,u=c(i.toString),s=/function\b(?:\s|\/\*[\S\s]*?\*\/|\/\/[^\n\r]*[\n\r]+)*([^\s(/]*)/,f=c(s.exec),l="name";n&&!a&&o(i,l,{configurable:!0,get:function(){try{return f(s,u(this))[1]}catch(e){return""}}})},b64b:function(e,t,r){var n=r("23e7"),a=r("7b0b"),c=r("df75"),o=r("d039"),i=o((function(){c(1)}));n({target:"Object",stat:!0,forced:i},{keys:function(e){return c(a(e))}})},b727:function(e,t,r){var n=r("0366"),a=r("e330"),c=r("44ad"),o=r("7b0b"),i=r("07fa"),u=r("65f0"),s=a([].push),f=function(e){var t=1==e,r=2==e,a=3==e,f=4==e,l=6==e,d=7==e,v=5==e||l;return function(p,g,b,x){for(var h,y,m=o(p),E=c(m),I=n(g,b),w=i(E),$=0,R=x||u,A=t?R(p,w):r||d?R(p,0):void 0;w>$;$++)if((v||$ in E)&&(h=E[$],y=I(h,$,m),e))if(t)A[$]=y;else if(y)switch(e){case 3:return!0;case 5:return h;case 6:return $;case 2:s(A,h)}else switch(e){case 4:return!1;case 7:s(A,h)}return l?-1:a||f?f:A}};e.exports={forEach:f(0),map:f(1),filter:f(2),some:f(3),every:f(4),find:f(5),findIndex:f(6),filterReject:f(7)}},d784:function(e,t,r){"use strict";r("ac1f");var n=r("e330"),a=r("6eeb"),c=r("9263"),o=r("d039"),i=r("b622"),u=r("9112"),s=i("species"),f=RegExp.prototype;e.exports=function(e,t,r,l){var d=i(e),v=!o((function(){var t={};return t[d]=function(){return 7},7!=""[e](t)})),p=v&&!o((function(){var t=!1,r=/a/;return"split"===e&&(r={},r.constructor={},r.constructor[s]=function(){return r},r.flags="",r[d]=/./[d]),r.exec=function(){return t=!0,null},r[d](""),!t}));if(!v||!p||r){var g=n(/./[d]),b=t(d,""[e],(function(e,t,r,a,o){var i=n(e),u=t.exec;return u===c||u===f.exec?v&&!o?{done:!0,value:g(t,r,a)}:{done:!0,value:i(r,t,a)}:{done:!1}}));a(String.prototype,e,b[0]),a(f,d,b[1])}l&&u(f[d],"sham",!0)}},e8b5:function(e,t,r){var n=r("c6b6");e.exports=Array.isArray||function(e){return"Array"==n(e)}},f601:function(e,t,r){"use strict";r.d(t,"a",(function(){return n})),r.d(t,"b",(function(){return a})),r.d(t,"c",(function(){return d}));r("d3b7"),r("159b"),r("b64b"),r("fb6a"),r("ac1f"),r("5319");var n=[{type:"success",visible_status:!1,header:"Вікно підтвердження відповідності даних.",title:"title",footer:'Після підтвердження даного вікна, даний запис "Відомості про заяву" будуть вилучені зі сторінки "Активних заяв".'},{type:"danger",visible_status:!1,header:"Вікно відхилиння наданих даних",title:"title",footer:'Після підтвердження даного вікна, даний запис "Відомості про заяву" будуть вилучені зі сторінки "Активних заяв".',values:["Недостовірність даних","бла бла бла","Інше"],checked:"Інше"}],a=[{type:"success",visible_status:!0,header:"Вікно підтвердження реєстрації користувача системи",title:"title",footer:'Після підтвердження даного вікна, даний запис "Відомості про заяву" будуть вилучені зі сторінки "Активних заяв".'},{type:"danger",visible_status:!1,header:"Вікно відхилиння реєстрації користувача системи",title:"title",footer:'Після підтвердження даного вікна, даний запис "Відомості про заяву" будуть вилучені зі сторінки "Активних заяв".',values:["Недостовірність даних","бла бла бла","Інше"],checked:"Інше"}],c={names:{var:/[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?/},lastName:{var:/[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?(-[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?)*/},email:{var:/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/},building:{var:/[1-9][0-9]?[0-9]?/},corps:{var:/([1-9][0-9]?)|[А-Я]/},flat:{var:/[1-9][0-9]?[0-9]?[а-яА-Я]?/},text:{var:/[^^=[\]{}@!&~$;:%?*_+\\/]/},money:{var:/[1-9][0-9]*(\.[0-9]|\.[0-9][0-9])?/},number:{var:/\d+/},serialNum:{var:/[\s]+/},idNumber:{var:/\d{12}/}};Object.keys(c).forEach((function(e){return c[e].str=String(c[e].var).slice(1,String(c[e].var).length-1)}));var o=new Date(Date.now()),i="yyyy-mm-dd",u=i.replace("yyyy",o.getFullYear()-18).replace("mm",o.getMonth()+1).replace("dd",o.getDate()),s=i.replace("yyyy",o.getFullYear()).replace("mm",o.getMonth()+1).replace("dd",o.getDate()+1),f=i.replace("yyyy",o.getFullYear()+10).replace("mm",o.getMonth()+1).replace("dd",o.getDate()),l=i.replace("yyyy",o.getFullYear()).replace("mm",o.getMonth()+1).replace("dd",o.getDate()),d={patterns:c,today:l,maxBirthDate:u,tomorrow:s,decadeAfter:f}},fb6a:function(e,t,r){"use strict";var n=r("23e7"),a=r("da84"),c=r("e8b5"),o=r("68ee"),i=r("861d"),u=r("23cb"),s=r("07fa"),f=r("fc6a"),l=r("8418"),d=r("b622"),v=r("1dde"),p=r("f36a"),g=v("slice"),b=d("species"),x=a.Array,h=Math.max;n({target:"Array",proto:!0,forced:!g},{slice:function(e,t){var r,n,a,d=f(this),v=s(d),g=u(e,v),y=u(void 0===t?v:t,v);if(c(d)&&(r=d.constructor,o(r)&&(r===x||c(r.prototype))?r=void 0:i(r)&&(r=r[b],null===r&&(r=void 0)),r===x||void 0===r))return p(d,g,y);for(n=new(void 0===r?x:r)(h(y-g,0)),a=0;g<y;g++,a++)g in d&&l(n,a,d[g]);return n.length=a,n}})},fce3:function(e,t,r){var n=r("d039"),a=r("da84"),c=a.RegExp;e.exports=n((function(){var e=c(".","s");return!(e.dotAll&&e.exec("\n")&&"s"===e.flags)}))}}]);
//# sourceMappingURL=Statments~regapplications~registration.f6e028a6.js.map