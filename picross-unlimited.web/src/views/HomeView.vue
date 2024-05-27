<template>
  <v-container>
    <v-row class = "justify-center align-center">
      <v-col cols="12" md="8">
        <v-card>
          <v-card-title class="text-h2 pa-6">Welcome to Picross</v-card-title>
          <v-card-text>
            Embark on a journey through recent wordly wonders with our Replay and Stats section, where the last ten Wordles await your exploration.
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