<script>

import TokenService from "@/services/TokenService";
import apiClient from "@/interceptors/authInterceptor";

export default {
  name: 'LoginPage',
  data(){
    return {
      login: '',
      password: '',
      errorMessage: '',
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
    <button class="register" v-on:click="goToRegister()">Регистрация</button>
  </form>
</template>

<style scoped>

</style>