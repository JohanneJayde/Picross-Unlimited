<template>
  <v-dialog v-model="modelValue" width="500">
    <v-card>
      <v-sheet color="primary mb-3">
        <v-card-title class="text-wrap">Sign in</v-card-title>
      </v-sheet>
      <v-alert
        v-if="errorMessage"
        type="error"
        title-date-format="Function"
        rounded
        class="w-75 mx-auto"
      >
        {{ errorMessage }}
      </v-alert>
      <v-card-text class="text-center align-center">
        Sign in or register to customize your experience. You can save, load, add puzzles and create
        rooms for your friends!
      </v-card-text>
      <v-tabs v-model="currentPage" align-tabs="center">
        <v-tab>Sign In</v-tab>
        <v-tab>Register</v-tab>
      </v-tabs>
      <v-card-text>
        <v-text-field v-model="email" @keyup.stop label="Email" v-if="currentPage == 1" />
        <v-text-field v-model="userName" @keyup.stop label="Username" />
        <v-text-field
          v-model="password"
          @keyup.stop
          label="Password"
          :type="showPassword ? 'text' : 'password'"
          :append-inner-icon="showPassword ? 'mdi-eye-off-outline' : 'mdi-eye-outline'"
          @click:append-inner="showPassword = !showPassword"
        />
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" variant="tonal" @click="close">Cancel</v-btn>
        <v-btn color="primary" variant="flat" @click="signIn">Sign In</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import axios from "axios";
import TokenService from "../scripts/tokenService";
import { useRouter } from "vue-router";
import { ref } from "vue";

const router = useRouter();
const tokenService = new TokenService();

const modelValue = defineModel<boolean>({ default: false });
const showPassword = ref(false);
const userName = ref("");
const password = ref("");
const email = ref("");
const errorMessage = ref("");
const currentPage = ref(0);

function signIn() {
  errorMessage.value = "";
  axios
    .post("/Token/GetToken", {
      username: userName.value,
      password: password.value,
    })
    .then((response) => {
      tokenService.setToken(response.data.token);
      modelValue.value = false;
      router.push("/");
    })
    .catch((error) => {
      errorMessage.value = error.response.data;
    });
}

function close() {
  userName.value = "";
  password.value = "";
  modelValue.value = false;
}
</script>
