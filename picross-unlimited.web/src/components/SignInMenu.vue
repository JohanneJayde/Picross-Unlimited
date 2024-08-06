<template>
  <v-card :width="tokenService.isLoggedIn() ? '300px' : '500px'" class="pa-3">
    <v-alert
      v-if="errorMessage"
      type="error"
      title-date-format="Function"
      rounded
      class="w-100 mx-auto"
      closable
    >
      {{ errorMessage }}
    </v-alert>
    <div v-if="!tokenService.isLoggedIn()">
      <v-card-item>
        <v-text-field v-model="userName" @keyup.stop label="Username" />
        <v-text-field
          v-model="password"
          @keyup.stop
          label="Password"
          :type="showPassword ? 'text' : 'password'"
          :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
          @click:append-inner="showPassword = !showPassword"
        />
      </v-card-item>
    </div>
    <v-card-actions>
      <v-spacer />
      <v-btn
        v-if="!tokenService.isLoggedIn()"
        class="w-100"
        color="primary"
        variant="flat"
        @click="signIn"
        >Sign In</v-btn
      >
      <v-btn v-else @click="showConfirmDialog = true" class="w-100" color="primary" variant="flat"
        >Log Out</v-btn
      >
    </v-card-actions>
  </v-card>
  <ConfirmDialog
    v-model="showConfirmDialog"
    message="Are you sure you want to logout?"
    title="Log Out"
    action="Log Out"
    @updated="logout"
  />
</template>

<script setup lang="ts">
import axios from 'axios'
import TokenService from '../scripts/tokenService'
import { useRouter } from 'vue-router'
import { ref } from 'vue'
import ConfirmDialog from '@/components/ConfirmDialog.vue'

const router = useRouter()
const tokenService = new TokenService()
const showConfirmDialog = ref(false)

const showPassword = ref(false)
const userName = ref('')
const password = ref('')
const email = ref('')
const errorMessage = ref('')
const currentPage = ref(0)

function signIn() {
  errorMessage.value = ''
  axios
    .post('/Token/GetToken', {
      username: userName.value,
      password: password.value
    })
    .then((response) => {
      tokenService.setToken(response.data.token)
      router.push('/')
    })
    .catch((error) => {
      errorMessage.value = error.response.data
    })
}

function logout() {
  localStorage.removeItem('token')
  localStorage.removeItem('user')

  router.push('/')
}
</script>
