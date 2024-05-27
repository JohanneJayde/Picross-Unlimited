<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card class="pa-6">
          <v-card-title class="text-h5 text-center pa-4" style="display: block; margin-bottom: 16px;">
            Welcome to Picross
          </v-card-title>
          <v-card-text class="text-center" style="display: block;">
            Dive into our logic puzzle game where players fill in squares on a grid based on numbers along the edges to reveal a hidden picture!
          </v-card-text>
            <v-btn color="#EF5350" @click="navigateTo('about')">About</v-btn>
            <v-btn color="#EF5350" @click="navigateTo('play')">Play Game</v-btn>
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

<style scoped>
.fill-height {
  min-height: 100vh;
}
</style>