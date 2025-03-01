import {createRouter, createWebHistory} from "vue-router";
import HomePage from "@/components/HomePage.vue";
import AdminPage from "@/components/AdminPage.vue";
import CustomerPage from "@/components/CuspomerPage.vue";
import LoginPage from "@/components/LoginPage.vue";
import RegisterPage from "@/components/RegisterPage.vue";
import UsersPageForAdmin from "@/components/UsersPageForAdmin.vue";
import ItemsPageForAdmin from "@/components/ItemsPageForAdmin.vue";
import RedactUserPage from "@/components/RedactUserPage.vue";


const routes = [
    {
        path: '/',
        name: 'Home',
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
        path: '/users_adm',
        name: 'Users_adm',
        component: UsersPageForAdmin,
    },
    {
        path: '/items_adm',
        name: 'Items_adm',
        component: ItemsPageForAdmin,
    },
    {
        path: '/redact_user',
        name: 'Redact_user',
        component: RedactUserPage,
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