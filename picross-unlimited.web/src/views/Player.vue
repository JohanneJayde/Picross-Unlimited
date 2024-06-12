<template>
  <v-container class="fill-height d-flex align-center justify-center">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card>
          <v-card-title class="text-h5 text-center pa-4"> Profile Stats </v-card-title>
          <v-card-text class="text-center">
            This is the stats and edit your profile page
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  <v-container class="d-flex align-center justify-center">
  <v-row justify="center">
      <v-card>
        <v-progress-circular
        color="green"
        model-value="100"
        />  
           
      </v-card>
    </v-row>
  </v-container>
</template>
<script setup lang="ts"></script>
