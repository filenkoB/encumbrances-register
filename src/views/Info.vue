<template>
    <div class="row">
        <Admin v-if="user_status == 'admin'"/>
        <Registrar v-if="user_status == 'registrar'"/>
        <User v-if="user_status == 'user'"/>
    </div>
</template>
<script>
import Admin from "../components/Info/Admin.vue";
import Registrar from "../components/Info/Registrar.vue";
import User from "../components/Info/User.vue";
export default {
    data(){
        return {
            user_status: null
        }
    },
    components:{
        Admin,
        Registrar,
        User
    },
    mounted(){
        this.user_status = window.sessionStorage.getItem('user_status');
        if(!this.user_status){
            this.$router.push({ name: "SignIn"}).catch(() => {});
        }
        this.$root.$children[0].$children[0].page = 'info';
    }
}
</script>
