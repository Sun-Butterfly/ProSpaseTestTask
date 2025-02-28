<script>
import TokenService from "@/services/TokenService";

export default {
  name: 'HomePage',
  
  data(){
    
  },
  methods: {
    isAuthorize(){
      return TokenService.isAuthorized();
    },
    goToLogin(){
      this.$router.push({name: 'Login'})
    },
    goToLogout(){
      TokenService.logOut()
    }
  }
}
</script>

<template>
  <div class="nonAutorize" v-if="!isAuthorize()">
    <button class="login" v-on:click="goToLogin()">Войти</button>
  </div>
  <div class="autorize" v-if="isAuthorize()">
    <button class="logout" v-on:click="goToLogout()">Выйти</button>
  </div>
</template>

<style scoped>

</style>