<script>
import TokenService from "@/services/TokenService";

export default {
  name: 'AdminPage',
  
  data(){
    
  },
  methods:{
    goToLogout(){
      TokenService.logOut()
      this.$router.push({name: 'Home'})
    },
    goToUsers(){
      this.$router.push({name: 'Users_adm'})
    },
    goToOrders(){
      this.$router.push({name: 'Orders_adm'})
    },
    goToItems(){
      this.$router.push({name: 'Items_adm'})
    }
  }
}
</script>

<template>
  <button class="users" v-on:click="goToUsers()">Пользователи</button>
  <button class="items" v-on:click="goToItems()">Товары</button>
  <button class="items" v-on:click="goToOrders()">Заказы</button>
  <button class="logout" v-on:click="goToLogout()">Выйти</button>
</template>

<style scoped>

</style>