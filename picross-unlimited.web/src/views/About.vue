<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row class="justify-center">
      <v-col cols="12" md="8">
        <v-card>
          <v-img src="/homelogo.svg" alt="Logo"></v-img>
          <v-card-text class="text-center text-h6">
            This Project was made my Johanne McClennan, Spencer West, and Alexa Darrington. We know
            how much Grant loves games so we wanted to make one. Enjoy!
          </v-card-text>
          <v-card-actions class="d-flex justify-center">
            <v-btn color="white" class="bg-primary pa-2 px-5" to="/" text="Go Home" />
            <v-btn color="white" class="bg-primary pa-2 px-5" to="/game" text="Play Picross" />
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts"></script>
