<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card class="pa-6">
          <v-card-title class="text-h5 text-center pa-4" style="display: block; margin-bottom: 16px;">
            About Page
          </v-card-title>
          <v-card-text class="text-center" style="display: block;">
            This Project was made my Johanne McClennan, Spencer West And Alexa Darrington. We knew how much Grant loves games so we wanted to make a fun one!
          </v-card-text>
            <v-btn color="primary" @click="navigateTo('home')">Go Back Home</v-btn>
            <v-btn color="primary" @click="navigateTo('play')">Play Game</v-btn>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

function navigateTo(page) {
  router.push({ name: page });
}
</script>