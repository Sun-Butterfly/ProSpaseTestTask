<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      orders: [],
      activeOrderIndex: -1,
      errorMessage: '',
      selectedStatus: '',
      statusOptions: ['New', 'Processing', 'Completed'],
    }
  },
  computed: {
    expandedOrders() {
      return this.orders.filter(order => order.isExpanded);
    },
    filteredOrders() {
      if (!this.selectedStatus) {
        return this.orders;
      }
      return this.orders.filter(order => order.status === this.selectedStatus);
    }
  },

  mounted() {
    this.fetchOrders()
  },
  methods: {
    async fetchOrders() {
      try {
        const response = await apiClient.get(`/Order/GetAllOrders`)
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
    async goToAccept(i) {
      let orderId = this.orders[i].id
      const shipmentDateInput = prompt('Введите дату доставки (в формате ГГГГ-ММ-ДД):');
      if (!shipmentDateInput) {
        alert('Дата доставки не указана!');
        return;
      }

      const shipmentDate = new Date(shipmentDateInput + 'T00:00:00Z').toISOString();

      try {
        await apiClient.put('/Order/AcceptOrderById', {
          orderId: orderId,
          shipmentDate: shipmentDate,
        });
        
        alert('Заказ успешно подтвержден!');
        await this.fetchOrders()
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    async goToClose(i){
      let orderId = this.orders[i].id
      try {
        await apiClient.put('/Order/CloseOrderById', {
          orderId: orderId
        });

        alert('Заказ закрыт!');
        await this.fetchOrders()
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage);
      }
    },
    goToHome() {
      this.$router.push({name: 'Admin'})
    }
  }
}
</script>

<template>
  <div class="orders">
    <h1>Заказы</h1>
    <div class="filter">
      <label for="statusFilter">Фильтр по статусу:</label>
      <select id="statusFilter" v-model="selectedStatus">
        <option value="">Все</option>
        <option v-for="status in statusOptions" :key="status" :value="status">
          {{ status }}
        </option>
      </select>
    </div>
    <table>
      <thead>
      <tr>
        <th>Id заказчика</th>
        <th>Номер заказа</th>
        <th>Дата заказа</th>
        <th>Статус</th>
        <th>Дата доставки</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="(order, i) in filteredOrders"
          :key="order.id"
          @click="setActiveOrderIndex(i)">
        <td>{{ order.customerId }}</td>
        <td>{{ order.orderNumber }}</td>
        <td>{{ new Date(order.orderDate).toLocaleDateString() }}</td>
        <td>{{ order.status }}</td>
        <td>{{ order.shipmentDate ? new Date(order.shipmentDate).toLocaleDateString() : 'Не указана' }}</td>
        <td>
          <button
              @click.stop="setActiveOrderIndex(i)">
            {{ order.isExpanded ? 'Скрыть' : 'Подробности' }}
          </button>
        </td>
        <td>
          <button class="buttonAccept"
                  v-if="order.status === 'New'"
                  @click.stop="goToAccept(i)">Подтвердить заказ</button>
          <button class="buttonClose"
                  v-if="order.status === 'Processing'"
                  @click.stop="goToClose(i)">Закрыть заказ</button>
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