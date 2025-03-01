<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      user: {

      },
      showCustomerFields: true,
      errorMessage: '',
    }
  },
  methods: {
    
    toggleFields() {
      this.showCustomerFields = this.user.roleName === 'customer';
    },
    async createUser(){
      try{
        await apiClient.post(`/User/CreateUser`, this.user)
        alert("Готово!")
        this.$router.push({name:'Users_adm'})
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
      // alert("Готово!")
      // this.$router.push({name:'Users_adm'})
    },
    goToCancel(){
      this.$router.push({name:'Users_adm'})
    }
  }
}
</script>

<template>
  <form @submit.prevent="createUser">
    <input type="text" placeholder="Логин" v-model="user.login"/>
    <input type="password" placeholder="Пароль" v-model="user.password"/>
    <div>
      <label>
        <input type="radio" v-model="user.roleName" value="administrator" @change="toggleFields"/>
        Менеджер
      </label>
      <label>
        <input type="radio" v-model="user.roleName" value="customer" @change="toggleFields"/>
        Заказчик
      </label>
    </div>
    <div v-if="showCustomerFields">
      <input type="text" placeholder="Имя" v-model="user.name"/>
      <input type="text" placeholder="Адрес" v-model="user.address"/>
      <input type="text" placeholder="Скидка" v-model="user.discount"/>
    </div>
    <button type="submit">Сохранить</button>
  </form>
  <button v-on:click="goToCancel()">Отмена</button>
</template>

<style scoped>

</style>