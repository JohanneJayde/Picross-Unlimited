import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

import { createApp } from 'vue'
import App from './App.vue'
import 'vuetify/styles'
import { mdi } from 'vuetify/iconsets/mdi'
import router from './router'

import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

// Import Axios
import Axios from 'axios'

// Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7112/'
} else {
  Axios.defaults.baseURL = 'https://picrossunlimitedapi.azurewebsites.net'
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
          unknown: '#222222'
        }
      },
      light: {
        colors: {
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
