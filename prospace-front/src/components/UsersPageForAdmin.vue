<script>

import apiClient from "@/interceptors/authInterceptor";

export default {

  data() {
    return {
      users: [],
      activeUserIndex: -1,
      errorMessage: null,

    };
  },
  mounted() {
    this.fetchUsers();
  },
  methods: {
    async fetchUsers() {
      try {
        const response = await apiClient.get('/User/GetAllUsers');
        this.users = response.data;
      } catch (error) {
        this.errorMessage = error.response.data.message
      }
    },

    setActiveUserIndex(i) {
      if (this.activeUserIndex === i) {
        this.activeUserIndex = -1;
      } else {
        this.activeUserIndex = i;
      }
    },
    goToRedactUser(i) {
      let selectedUserId = this.users[i].id
      this.$router.push({name: 'Redact_user', query: {id: selectedUserId}})

    },
    goToDeleteUser(i) {
      let selectedUserId = this.users[i].id
      this.$router.push({name: 'Delete_user', query: {id: selectedUserId}})
    },
    goToCreateUser() {
      this.$router.push({name: 'Create_user'})
    },
    goToHome(){
      this.$router.push({name: 'Admin'})
    }

  }
}
</script>

<template>
  <div class="users">
    <h1>Пользователи</h1>
    <table>
      <tbody>
      <tr>
        <th>ID пользователя</th>
        <th>Роль</th>
        <th>Имя</th>
        <th>Код</th>
        <th>Адрес</th>
        <th>Скидка</th>
        <th></th>
      </tr>
      <tr v-for="(user, i) in users"
          :key="user.id"
          @click="setActiveUserIndex(i)">
        <td>{{ user.id }}</td>
        <td>{{ user.roleName }}</td>
        <td>{{ user.name }}</td>
        <td>{{ user.code }}</td>
        <td>{{ user.address }}</td>
        <td>{{ user.discount }}</td>
        <td>
          <button class="buttonRedact" @click.stop="goToRedactUser(i)">Редактировать</button>
          <button class="buttonDelete" @click.stop="goToDeleteUser(i)">Удалить</button>
        </td>
      </tr>
      </tbody>
    </table>
    <button class="buttonCreate" v-on:click="goToCreateUser()">Добавить пользователя</button>
    <button class="buttonHome" v-on:click="goToHome()">На главную</button>
  </div>
</template>

<style scoped>
table th, table td {
  border: 1px solid black;
}
</style>