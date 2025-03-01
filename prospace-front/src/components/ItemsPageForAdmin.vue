<script>

import apiClient from "@/interceptors/authInterceptor";

export default {

  data() {
    return {
      items: [],
      activeItemIndex: -1,
      errorMessage: null,

    };
  },
  mounted() {
    this.fetchItems();
  },
  methods: {
    async fetchItems() {
      try {
        const response = await apiClient.get('/Item/GetAll');
        this.items = response.data;
      } catch (error) {
        this.errorMessage = error.response.data.message
      }
    },

    setActiveItemIndex(i) {
      if (this.activeItemIndex === i) {
        this.activeItemIndex = -1;
      } else {
        this.activeItemIndex = i;
      }
    },
    goToRedactItem(i) {
      let selectedItemId = this.items[i].id
      this.$router.push({name: 'Redact_item', query: {id: selectedItemId}})

    },
    goToDeleteItem(i){
      let selectedItemId = this.items[i].id
      this.$router.push({name: 'Delete_item', query: {id: selectedItemId}})
    },
    goToCreateItem() {
      this.$router.push({name: 'Create_item'})
    },
    goToHome(){
      this.$router.push({name: 'Admin'})
    }

  }
}
</script>

<template>
  <div class="items">
    <h1>Товары</h1>
    <table>
      <tbody>
      <tr>
        <th>ID товара</th>
        <th>Код</th>
        <th>Название</th>
        <th>Цена</th>
        <th>Категория</th>
        <th></th>
      </tr>
      <tr v-for="(item, i) in items"
          :key="item.id"
          @click="setActiveItemIndex(i)">
        <td>{{ item.id }}</td>
        <td>{{ item.code }}</td>
        <td>{{ item.name }}</td>
        <td>{{ item.price }}</td>
        <td>{{ item.category }}</td>
        <td>
          <button class="buttonRedact" @click.stop="goToRedactItem(i)">Редактировать</button>
          <button class="buttonDelete" @click.stop="goToDeleteItem(i)">Удалить</button>
        </td>
      </tr>
      </tbody>
    </table>
    <button class="buttonCreate" v-on:click="goToCreateItem()">Добавить товар</button>
    <button class="buttonHome" v-on:click="goToHome()">На главную</button>
  </div>
</template>

<style scoped>
table th, table td {
  border: 1px solid black;
}
</style>