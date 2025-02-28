<script>
import TokenService from "@/services/TokenService";

export default {
  name: 'CustomerPage',

  data(){

  },
  methods:{
    goToLogout(){
      TokenService.logOut()
      this.$router.push({name: 'Home'})
    }
  }
}
</script>

<template>
  <button class="logout" v-on:click="goToLogout()">Выйти</button>
</template>

<style scoped>

</style>