<script>
import apiClient from "@/interceptors/authInterceptor";

export default {
  data() {
    return {
      cartItems: [],
      selectedCartItemIds: [],
      errorMessage: '',
      activeCartItemIndex: -1,
      cartId: '',
      countsToRemove: []
    }
  },
  computed: {
    selectAll: {
      get() {
        return this.selectedCartItemIds.length === this.cartItems.length;
      },
      set(value) {
        if (value) {
          this.selectedCartItemIds = this.cartItems.map(item => item.id);
        } else {
          this.selectedCartItemIds = [];
        }
      }
    },
    totalSelectedPrice() {
      return this.cartItems
          .filter(item => this.selectedCartItemIds.includes(item.id))
          .reduce((total, item) => total + item.itemPrice * item.itemsCount, 0);
    }
  },
  mounted() {
    this.cartId = this.$route.query.cartId
    this.fetchCartItemsData()
  },
  methods: {
    toggleSelectAll() {
    },
    async fetchCartItemsData() {
      try {
        const response = await apiClient.get(`/Cart/GetCartItemsByCartId?cartId=${this.cartId}`)
        this.cartItems = response.data
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    },
    setActiveCartItemIndex(i) {
      if (this.activeCartItemIndex === i) {
        this.activeCartItemIndex = -1;
      } else {
        this.activeCartItemIndex = i;
      }
    },
    async removeCartItems(i) {
      const cartItem = this.cartItems[i]
      const countToRemove = this.countsToRemove[i]

      if (countToRemove > cartItem.itemsCount) {
        alert('Нельзя удалить больше, чем есть в корзине!')
        return;
      }

      try {
        await apiClient.delete(`/Cart/DeleteCartItemByCartItemId?cartItemId=${cartItem.id}&count=${countToRemove}`)


        cartItem.itemsCount -= countToRemove

        if (cartItem.itemsCount === 0) {
          this.cartItems.splice(i, 1)
          this.countsToRemove.splice(i, 1)
        } else {
          this.countsToRemove[i] = 1
        }
        await this.fetchCartItemsData()
      } catch (error) {
        this.errorMessage = error.response.data.message
        alert(this.errorMessage)
      }
    },
    async goToCreateOrder() {
      if (this.selectedCartItemIds.length === 0) {
        alert('Выберите хотя бы один товар!');
        return;
      }

      const orderData = {
        customerId: this.cartId,
        selectedCartItemIds: this.selectedCartItemIds
      }
      try {
        await apiClient.post('/Order/CreateOrder', orderData)
        alert('Заказ успешно создан!');
        this.selectedCartItemIds = [];
        await this.fetchCartItemsData()
      } catch (error) {
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
  <div class="cart">
    <h1>Корзина</h1>
    <table>
      <tbody>
      <tr>
        <th><input
            type="checkbox"
            v-model="selectAll"
            @change="toggleSelectAll"
        /></th>
        <th>Название товара</th>
        <th>Код товара</th>
        <th>Цена за штуку</th>
        <th>Категория товара</th>
        <th>Количество товара</th>
        <th></th>
      </tr>
      <tr v-for="(cartItem, i) in cartItems"
          :key="cartItem.id">
        <td>
          <input type="checkbox"
                 :value="cartItem.id"
                 v-model="selectedCartItemIds"/>
        </td>
        <td>{{ cartItem.itemName }}</td>
        <td>{{ cartItem.itemCode }}</td>
        <td>{{ cartItem.itemPrice }}</td>
        <td>{{ cartItem.itemCategory }}</td>
        <td>{{ cartItem.itemsCount }}</td>
        <input
            type="number"
            v-model="countsToRemove[i]"
            :max="cartItem.itemsCount"
            min="1"
        />
        <td>
          <button class="buttonDelete" @click.stop="removeCartItems(i)">Удалить</button>
        </td>
      </tr>
      </tbody>
    </table>
    <div class="order-summary">
      <span class="total-price">
        Общая стоимость выбранных товаров: {{ totalSelectedPrice }} руб.
      </span>
    </div>
      <button class="buttonCreate" v-on:click="goToCreateOrder()">Оформить заказ</button>
      <button class="buttonHome" v-on:click="goToHome()">На главную</button>
    </div>
</template>

<style scoped>
table th, table td {
  border: 1px solid black;
}
</style>