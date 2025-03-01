<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      errorMessage: '',
      userId: ''
    }
  },
  mounted() {
    this.userId = this.$route.query.id
  },
  methods: {
    async goToDelete() {
      try {
        await apiClient.delete(`/User/DeleteUserById?id=${this.userId}`)
        alert("Готово!")
        this.$router.push({name: 'Users_adm'})
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    goToCancel() {
      this.$router.push({name: 'Users_adm'})
    }
  }
}
</script>

<template>
  <h1>Вы действительно хотите удалить пользователя с ID {{ userId }}?</h1>
  <button class="buttonRedact" @click.stop="goToDelete()">Удалить</button>
  <button class="buttonDelete" @click.stop="goToCancel()">Отмена</button>
</template>

<style scoped>

</style>