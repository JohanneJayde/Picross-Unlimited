<template>
  <v-card v-if="!tokenService.isLoggedIn()" width="500px" class="pa-3">
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
    <v-card-item>
      <v-text-field v-model="email" @keyup.stop label="Email" />
      <v-text-field
        v-model="password"
        @keyup.stop
        label="Password"
        :type="showPassword ? 'text' : 'password'"
        :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
        @click:append-inner="showPassword = !showPassword"
      />
      <v-card-subtitle>
        Don't have an account?
        <router-link to="/Register">Register here!</router-link>
      </v-card-subtitle>
    </v-card-item>
    <v-card-actions>
      <v-spacer />
      <v-btn class="w-100" color="primary" variant="flat" @click="signIn">Sign In</v-btn>
    </v-card-actions>
  </v-card>
  <v-card v-else width="300px" class="pa-3">
    <v-card-subtitle class="text-center">
      Welcome {{ tokenService.getUserName() }}!
    </v-card-subtitle>
    <v-card-actions>
      <v-btn @click="showConfirmDialog = true" class="w-100" color="primary" variant="flat"
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
const email = ref('')
const password = ref('')
const errorMessage = ref('')

const emits = defineEmits<{
  (e: 'loginLogout'): void
}>()

function signIn() {
  errorMessage.value = ''
  axios
    .post('/Token/GetToken', {
      email: email.value,
      password: password.value
    })
    .then((response) => {
      tokenService.setToken(response.data.token)
      router.push('/')
      emits('loginLogout')
    })
    .catch((error) => {
      errorMessage.value = error.response.data
    })
}

function logout() {
  localStorage.removeItem('token')
  localStorage.removeItem('user')
  emits('loginLogout')

  router.push('/')
}
</script>
