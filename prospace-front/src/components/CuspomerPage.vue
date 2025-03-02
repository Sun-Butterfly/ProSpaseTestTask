<script>
import TokenService from "@/services/TokenService";

export default {
  name: 'CustomerPage',

  data() {
  },
  methods: {
    goToItems() {
      this.$router.push({name: 'Items_cust'})
    },
    goToCart() {
      let id = TokenService.getId()
      this.$router.push({name: 'Cart', query: {cartId: id}})
    },
    goToLogout() {
      TokenService.logOut()
      this.$router.push({name: 'Home'})
    }
  }
}
</script>

<template>
  <button class="items" v-on:click="goToItems()">Товары</button>
  <button class="cart" v-on:click="goToCart()">Корзина</button>
  <button class="logout" v-on:click="goToLogout()">Выйти</button>
</template>

<style scoped>

</style>