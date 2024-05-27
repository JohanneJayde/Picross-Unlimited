<template>
  <v-container>
    <v-row class = "justify-center align-center">
      <v-col cols="12" md="8">
        <v-card>
          <v-card-title class="pa-6">Welcome to Picross</v-card-title>
          <v-card-text>
            Dive into our logic puzzle game where players fill in squares on a grid based on numbers along the edges to reveal a hidden picture!
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="primary" @click="navigateTo('about')">About</v-btn>
            <v-btn color="primary" @click="navigateTo('play')">Play Game</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup>
import { useRouter } from 'vue-router';
import "vuetify" 

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