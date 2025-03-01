import {createApp} from 'vue'
import App from './App.vue'
import router from "@/router";
import apiClient from "@/interceptors/authInterceptor";
import {createVuetify} from "vuetify";

const app = createApp(App);

app.provide('apiClient', apiClient)
app.use(router)
app.use(createVuetify)
app.mount('#app')