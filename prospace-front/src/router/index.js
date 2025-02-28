import {createRouter, createWebHistory} from "vue-router";
import HomePage from "@/components/HomePage.vue";
import AdminPage from "@/components/AdminPage.vue";
import CustomerPage from "@/components/CuspomerPage.vue";
import LoginPage from "@/components/LoginPage.vue";
import RegisterPage from "@/components/RegisterPage.vue";


const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: HomePage,
    },
    {
        path: '/admin',
        name: 'Admin',
        component: AdminPage,
    },
    {
        path: '/customer',
        name: 'Customer',
        component: CustomerPage,
    },
    {
        path: '/login',
        name: 'Login',
        component: LoginPage,
    },
    {
        path: '/register',
        name: 'Register',
        component: RegisterPage,
    },
    {
        path: '/**',
        redirectTo: 'home'
    }

];

const router = createRouter({
    history: createWebHistory(),
    routes
})
export default router;