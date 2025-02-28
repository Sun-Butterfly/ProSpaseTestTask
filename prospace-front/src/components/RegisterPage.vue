<script>

import apiClient from "@/interceptors/authInterceptor";
export default {
  name: 'RegisterPage',
  data(){
    return{
      login: null,
      password: null,
      name: null,
      address: null,
      errorMessage: null,
    }
  },
  methods:{
    async register(){
      try{
        await apiClient.post('/Register/Register',{
          login: this.login,
          password: this.password,
          name: this.name,
          address: this.address
        });
        alert('Добро пожаловать!');
        this.$router.push({name: 'Login'})
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    }
  }
}
</script>

<template>
  <form @submit.prevent="register">
    <input type="text" placeholder="Логин" v-model="login" />
    <input type="password" placeholder="Пароль" v-model="password" />
    <input type="text" placeholder="Имя" v-model="name" />
    <input type="text" placeholder="Адрес" v-model="address" />
    <button type="submit">Регистрация</button>
  </form>
</template>

<style scoped>

</style>