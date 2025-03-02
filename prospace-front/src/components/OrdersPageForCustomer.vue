<script>
import apiClient from "@/interceptors/authInterceptor";
import TokenService from "@/services/TokenService";

export default {
  data() {
    return {
      orders: [],
      activeOrderIndex: -1,
      errorMessage: ''
    }
  },
  computed: {
    expandedOrders() {
      return this.orders.filter(order => order.isExpanded);
    }
  },

  mounted() {
    this.fetchOrders()
  },
  methods: {
    async fetchOrders() {
      try {
        let customerId = TokenService.getId()
        const response = await apiClient.get(`/Order/GetAllOrdersByCustomerId?customerId=${customerId}`)
        this.orders = response.data.map(order => ({
          ...order,
          isExpanded: false
        }))
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    },
    setActiveOrderIndex(i) {
      this.orders[i].isExpanded = !this.orders[i].isExpanded;
    },
    async goToDelete(i){
      try{
        let orderId = this.orders[i].id
        await apiClient.delete(`/Order/DeleteOrderById?orderId=${orderId}`)
        alert("Заказ удален!")
        await this.fetchOrders()
      } catch (error){
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    },
    goToHome() {
      this.$router.push({name: 'Customer'})
    }
  }
}
</script>

<template>
  <div class="orders">
    <h1>Заказы</h1>
    <table>
      <thead>
      <tr>
        <th>Номер заказа</th>
        <th>Дата заказа</th>
        <th>Статус</th>
        <th>Дата доставки</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="(order, i) in orders"
          :key="order.id"
          @click="setActiveOrderIndex(i)">
        <td>{{ order.orderNumber }}</td>
        <td>{{ new Date(order.orderDate).toLocaleDateString() }}</td>
        <td>{{ order.status }}</td>
        <td>{{ order.shipmentDate ? new Date(order.shipmentDate).toLocaleDateString() : 'Не указана' }}</td>
        <td>
          <button @click.stop="setActiveOrderIndex(i)">
            {{ order.isExpanded ? 'Скрыть' : 'Подробности' }}
          </button>
        </td>
        <td>
          <button class="buttonDelete" @click.stop="goToDelete(i)">Удалить</button>
        </td>
      </tr>
      </tbody>
    </table>
    <button class="buttonHome" v-on:click="goToHome()">На главную</button>
    <tr v-for="order in expandedOrders" :key="order.id + '-details'">
      <td colspan="5">
        <table class="nested-table">
          <thead>
          <tr>
            <th>Название товара</th>
            <th>Категория</th>
            <th>Количество</th>
            <th>Цена за единицу</th>
          </tr>
          </thead>
          <tbody>
          <tr v-for="element in order.orderElements" :key="element.id">
            <td>{{ element.itemName }}</td>
            <td>{{ element.category }}</td>
            <td>{{ element.itemsCount }}</td>
            <td>{{ element.itemPrice }} руб.</td>
          </tr>
          </tbody>
        </table>
      </td>
    </tr>
  </div>
</template>

<style scoped>
table th, table td {
  border: 1px solid black;
}
</style>