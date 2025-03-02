<script>

import apiClient from "@/interceptors/authInterceptor";
import TokenService from "@/services/TokenService";

export default {
  data(){
    return{
      items: [],
      activeItemIndex: -1,
      errorMessage: null,
      countToAdd: []
    }
  },
  mounted() {
    this.fetchItems();
    this.countToAdd = this.items.map(() => null);
  },
  methods:{
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
    async goToAddToCart(i){
      const item = this.items[i]
      const count = this.countToAdd[i]
      if (!count || count < 1) {
        alert('Укажите количество товара!');
        return;
      }
      try{
        await apiClient.post('/Item/AddItemToCart', {
          customerId: TokenService.getId(),
          itemId: item.id,
          itemCount: count
        })
        alert("Товар добавлен в корзину!")
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    goToHome(){
      this.$router.push({name: 'Customer'})
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
        <th>Код</th>
        <th>Название</th>
        <th>Цена</th>
        <th>Категория</th>
        <th></th>
      </tr>
      <tr v-for="(item, i) in items"
          :key="item.id"
          @click="setActiveItemIndex(i)">
        <td>{{ item.code }}</td>
        <td>{{ item.name }}</td>
        <td>{{ item.price }}</td>
        <td>{{ item.category }}</td>
        <td>
          <input
              type="number"
              v-model="countToAdd[i]"
              min="1"
          />
          <button class="buttonRedact" @click.stop="goToAddToCart(i)">Добавить в корзину</button>
        </td>
      </tr>
      </tbody>
    </table>
    <button class="buttonHome" v-on:click="goToHome()">На главную</button>
  </div>
</template>

<style scoped>
table th, table td {
  border: 1px solid black;
}
</style>