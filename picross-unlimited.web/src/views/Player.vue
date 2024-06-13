<template>
  <v-container class="d-flex justify-center">
    <v-col>
      <v-card>
        <v-card-title class="d-flex justify-center">Player</v-card-title>
        <v-card-text class="d-flex justify-center">
          The player homepage to display stats and edit your profile
        </v-card-text>
        <v-card-actions>
          <v-btn color="primary" to="/game">Play Game</v-btn>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-container>

  <v-container>
    <v-row>
      <v-col cols="20" class="d-flex justify-center">
        <v-card>
          <v-card-title class="d-flex justify-center">Player Stats</v-card-title>
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
</script>
