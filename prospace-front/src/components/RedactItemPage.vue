<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      item: {},
      errorMessage: '',
      itemId: ''
    }
  },
  mounted() {
    this.itemId = this.$route.query.id;
    this.fetchItemData(this.itemId)
  },
  methods: {
    async fetchItemData() {
      try {
        const response = await apiClient.get(`/Item/GetById/?id=${encodeURIComponent(this.itemId)}`);
        this.item = response.data;
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    async saveItem() {
      try {
        await apiClient.put(`/Item/RedactItem`, {id: this.itemId, ...this.item})
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
      alert("Готово!")
      this.$router.push({name: 'Items_adm'})
    },
    goToCancel() {
      this.$router.push({name: 'Items_adm'})
    }
  }
}


</script>

<template>
  <form @submit.prevent="saveItem">
    <input type="text" placeholder="Название" v-model="item.name"/>
    <input type="text" placeholder="Цена" v-model="item.price"/>
    <input type="text" placeholder="Категория" v-model="item.category"/>
    <button type="submit">Сохранить</button>
  </form>
  <button v-on:click="goToCancel()">Отмена</button>
</template>

<style scoped>

</style>