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
import 'vuetify/styles'

// Import Axios
import Axios from 'axios'

//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7112/'
} else {
  Axios.defaults.baseURL = 'https://picrossunlimited.azurewebsites.net'
}

Axios.defaults.headers.common['Content-Type'] = 'application/json'
Axios.defaults.headers.common['Accept'] = 'application/json'
Axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*'

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
    defaultTheme: 'light',
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

const app = createApp(App)

app.use(router)
app.use(vuetify)

app.mount('#app')
