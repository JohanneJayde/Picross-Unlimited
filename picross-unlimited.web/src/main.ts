import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { createVuetify } from 'vuetify';
import 'vuetify/styles';

// Import Axios
import axios from 'axios';

const app = createApp(App)

app.use(router)

app.mount('#app')
