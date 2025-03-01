<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      errorMessage: '',
      itemId: ''
    }
  },
  mounted() {
    this.itemId = this.$route.query.id
  },
  methods: {
    async goToDelete() {
      try {
        await apiClient.delete(`/Item/DeleteItem?id=${this.itemId}`)
        alert("Готово!")
        this.$router.push({name: 'Items_adm'})
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    goToCancel() {
      this.$router.push({name: 'Items_adm'})
    }
  }
}
</script>

<template>
  <h1>Вы действительно хотите удалить товар с ID {{ itemId }}?</h1>
  <button class="buttonRedact" @click.stop="goToDelete()">Удалить</button>
  <button class="buttonDelete" @click.stop="goToCancel()">Отмена</button>
</template>

<style scoped>

</style>