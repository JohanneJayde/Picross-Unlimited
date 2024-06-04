<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card>
          <v-card-title class="text-h5 text-center pa-4"> About Page </v-card-title>
          <v-card-text class="text-center" style="display: block">
            This Project was made my Johanne McClennan, Spencer West, And Alexa Darrington. We knew
            how much Grant loves games so we wanted to make a fun one!
          </v-card-text>
          <v-card-actions class="d-flex justify-center">
            <v-btn color="white" class="bg-primary pa-2 px-5" to="/" text="Go Home" />
            <v-btn color="white" class="bg-primary pa-2 px-5" to="/game" text="Play Game" />
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup>
import { useRouter } from 'vue-router'

const router = useRouter()

function navigateTo(page) {
  router.push({ name: page })
}
</script>
