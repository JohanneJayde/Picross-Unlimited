import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css' 

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import 'vuetify/styles'
import { mdi } from 'vuetify/iconsets/mdi'

import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import 'vuetify/styles';

// Import Axios
import axios from 'axios';

const app = createApp(App)

app.use(router)
const vuetify = createVuetify({
    components,
    directives,
    icons: {
      defaultSet: 'mdi',
      sets: {
        mdi
      }
    },
    theme: {
      defaultTheme: 'dark',
      themes: {
        dark: {
          colors: {
            correct: '#4CAF50',
            misplaced: '#FFC107',
            wrong: '#F44336',
            unknown: '#222222'
          }
        },
        light: {
          colors: {
            correct: '#6CCF70',
            misplaced: '#FFD137',
            wrong: '#F46356',
            unknown: '#eeeeee'
          }
        }
      }
    }
  })
app.use(vuetify);

app.mount('#app')
