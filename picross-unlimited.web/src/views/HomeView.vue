<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card class="pa-6">
          <v-img src="/homelogo.svg" alt="Logo"></v-img>
          <v-card-text class="text-center text-h6">
            Dive into our logic puzzle game where players fill in squares on a grid based on numbers
            along the edges to reveal a hidden picture!
          </v-card-text>
          <v-card-actions class="d-flex justify-center">
            <v-btn color="white" class="bg-primary pa-2 px-5" to="/game" text="Play Game" />
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'

const router = useRouter()

function navigateTo(page) {
  router.push({ name: page })
}
</script>

<style scoped>
.fill-height {
  min-height: 100vh;
}
</style>
