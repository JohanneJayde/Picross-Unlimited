<template>
  <v-container class="fill-height">
    <v-row align="center" justify="center">
      <v-col cols="12" md="6" lg="4">
        <v-card width="600px">
          <v-sheet color="primary">
            <v-card-title class="white--text">
              <v-icon icon="mdi-account" /> Register for an Account</v-card-title
            >
          </v-sheet>
          <v-card-item class="mt-3">
            <v-form v-model="form">
              <v-card-subtitle>Email</v-card-subtitle>

              <v-text-field
                v-model="email"
                required
                :rules="[
                  (v) => !!v || 'E-mail is required',
                  (v) =>
                    /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail must be valid'
                ]"
                class="mb-2"
              />

              <v-card-subtitle>Username</v-card-subtitle>
              <v-text-field
                v-model="userName"
                required
                :rules="[
                  (v) => !!v || 'Name is required',
                  (v) => v.length <= 20 || 'Name must be less than 20 characters'
                ]"
                class="mb-2"
              />

              <v-card-subtitle>Password</v-card-subtitle>

              <v-text-field
                v-model="password"
                label="Password"
                :type="showPassword ? 'text' : 'password'"
                :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
                @click:append-inner="showPassword = !showPassword"
                required
                :rules="passwordRules"
                class="mb-2"
              />
              <v-card-subtitle>Confirm Password</v-card-subtitle>
              <v-text-field
                v-model="confirmPassword"
                label="Confirm Password"
                :type="showPassword ? 'text' : 'password'"
                :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
                @click:append-inner="showPassword = !showPassword"
                required
                :rules="confirmPasswordRules"
                class="mb-2"
              />
            </v-form>
          </v-card-item>
          <v-card-actions>
            <v-btn
              class="w-50 text-center mx-auto"
              color="primary"
              variant="flat"
              :disabled="!form"
              @click="register"
            >
              Register
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const showPassword = ref(false)
const userName = ref<string>('')
const password = ref<string>('')
const confirmPassword = ref<string>('')

const email = ref<string>('')

const form = ref(false)

const passwordRules = [
  (passwordValue: string) => !!passwordValue || 'Password is required',
  (passwordValue: string) => passwordValue.length >= 8 || 'Password must be at least 8 characters',
  (passwordValue: string) =>
    /[A-Z]/.test(passwordValue) || 'Password must contain an uppercase letter',
  (passwordValue: string) =>
    /[a-z]/.test(passwordValue) || 'Password must contain a lowercase letter',
  (passwordValue: string) => /\d/.test(passwordValue) || 'Password must contain a number',
  (passwordValue: string) => /\W/.test(passwordValue) || 'Password must contain a special character'
]

const confirmPasswordRules = [
  (passwordValue: string) => !!passwordValue || 'Password is required',
  (passwordValue: string) => passwordValue === password.value || 'Passwords do not match'
]

function register() {}
</script>
