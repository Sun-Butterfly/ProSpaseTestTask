<script>

import TokenService from "@/services/TokenService";
import apiClient from "@/interceptors/authInterceptor";

export default {
  name: 'LoginPage',
  data(){
    return {
      login: null,
      password: null,
      errorMessage: null,
    };
  },
  methods:{
    async logIn(){
      try{
        const response = await apiClient.post('/Auth/LogIn',{
          login: this.login,
          password: this.password,
        });
        
        const token = response.data.token;
        TokenService.setToken(token);
        
        if(TokenService.getRole(token) === 'administrator'){
          this.$router.push({name: 'Admin'})
        }
        if(TokenService.getRole(token) === 'customer'){
          this.$router.push({name: 'Customer'})
        }
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
      
    },
    goToRegister(){
      this.$router.push({name: 'Register'})
    },
  }
}
</script>

<template>
  
  <form @submit.prevent="logIn">
    <input type="text" placeholder="Логин" v-model="login" />
    <input type="password" placeholder="Пароль" v-model="password" />
    <button type="submit">Войти</button>
  </form>
  <button class="register" v-on:click="goToRegister()">Регистрация</button>
</template>

<style scoped>

</style>