<template>
  <v-container>
      <v-card class="pa-3 mb-4" color="primary">
        <v-card-title>{{ userName + "'s Profile" }}</v-card-title>
        </v-card>    
  </v-container>

  <v-container>
    <v-row>
      <v-col cols="20" class="d-flex justify-center">
        <v-card>
          <v-card-title class="d-flex justify-center">Player Stats</v-card-title>
          <v-data-table :items="gameStats"/>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
  <v-container>
    <v-col cols="6" class="flex-fill justify-center">
      <v-card>
        <v-card-title class="d-flex justify-center">Edit Profile</v-card-title>
        <v-select :items="colors" :item-props="changeColor"> </v-select>
      </v-card>
    </v-col>
  </v-container>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue'
import {GameDetail} from '@/models'
import TokenService from '@/scripts/tokenService'
import Axios from 'axios'


const tokenService = new TokenService()
const userName = tokenService.getUserName() ?? 'Guest'
const gameStats : ref<GameDetail[]> = ref([])

const colors: { color: string }[] = [
  {
    color: 'Red'
  },
  { color: 'Blue' },
  { color: 'Green' },
  { color: 'Yellow' },
  { color: 'Purple' }
]
function changeColor(colors: { color: string }) {
  return {
    title: colors.color
  }
}

onMounted(() => {
  console.log('User:', tokenService.getUserName())

  Axios.get('Game/Stats/$' + tokenService.getUserName())
    .then((response) => {
      gameStats.value = response.data
      console.log('Stats:', gameStats.value)
    })
    .catch((error) => {
      console.error('Error fetching stats:', error)
    }
  );

})


</script>
