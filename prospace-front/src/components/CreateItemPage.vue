<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      item: {

      },
      errorMessage: '',
    }
  },
  methods: {
    
    async createItem(){
      try{
        await apiClient.post(`/Item/CreateItem`, this.item)
        alert("Готово!")
        this.$router.push({name:'Items_adm'})
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    },
    goToCancel(){
      this.$router.push({name:'Items_adm'})
    }
  }
}
</script>

<template>
  <form @submit.prevent="createItem">
    <input type="text" placeholder="Название" v-model="item.name"/>
    <input type="text" placeholder="Цена" v-model="item.price"/>
    <input type="text" placeholder="Категория" v-model="item.category"/>
    <button type="submit">Создать</button>
  </form>
  <button v-on:click="goToCancel()">Отмена</button>
</template>

<style scoped>

</style>