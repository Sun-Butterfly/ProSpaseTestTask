import axios from "axios";
import TokenService from '@/services/TokenService';
import router from "@/main";

const apiClient = axios.create({
    baseURL: 'http://localhost:5284',
    headers:{
        'Content-Type': 'application/json'
    },
});

apiClient.interceptors.request.use(
    (config) => {
        const token = TokenService.getToken();
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);


apiClient.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response && error.response.status === 401) {
            TokenService.removeToken();
            router.push({ name: 'Login' });
        }
        return Promise.reject(error);
    }
);

export default apiClient;