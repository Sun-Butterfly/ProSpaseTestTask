import {createApp} from 'vue'
import App from './App.vue'
import router from "@/router";
import apiClient from "@/interceptors/authInterceptor";


const app = createApp(App);
app.provide('apiClient', apiClient)
app.use(router)
app.mount('#app')