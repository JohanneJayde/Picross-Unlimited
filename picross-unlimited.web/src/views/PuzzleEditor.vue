<template>
  <v-container v-if="tokenService.isLoggedIn()">
    <v-row justify="center">
      <v-col cols="12">
        <v-card class="pa-3" color="primary">
          <v-card-title>Puzzle Editor</v-card-title>
        </v-card>
      </v-col>
      <v-col cols="12">
        <v-btn @click="showAddPuzzleDialog = true" color="primary" rounded>Create Puzzle</v-btn>
      </v-col>
      <v-col cols="12">
        <PuzzleGroup :puzzles="Puzzles" :edit="true" @deletePuzzle="removePuzzle" />
      </v-col>
    </v-row>
  </v-container>
  <v-container v-else>
    <v-card color="primary" class="pa-3">
      <v-card-title>Sorry! You Must Be Logged In</v-card-title>
    </v-card>
  </v-container>
  <AddPuzzleDialog v-model="showAddPuzzleDialog" @close="showAddPuzzleDialog = false" />
</template>
<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models/puzzle'
import PuzzleGroup from '@/components/PuzzleGroup.vue'
import TokenService from '@/scripts/tokenService'
import AddPuzzleDialog from '@/components/AddPuzzleDialog.vue'
import PuzzleUtils from '@/scripts/puzzleUtils'

const tokenService = new TokenService()

const Puzzles = ref<Puzzle[]>([])
const showAddPuzzleDialog = ref(false)

Puzzles.value = await PuzzleUtils.getUserPuzzles(tokenService.getSub())

function removePuzzle(id: number) {
  console.log('Deleting puzzle:', id)
  Axios.delete('Puzzle/DeletePuzzle?puzzleId=' + id)
    .then((response) => {
      console.log('Puzzle deleted:', response.data)

      if (response.data) {
        Puzzles.value = Puzzles.value.filter((puzzle) => puzzle.id !== id)
      } else {
        console.error('Error deleting puzzle:', response.data)
      }
    })
    .catch((error) => {
      console.error('Error deleting puzzle:', error)
    })
}
</script>
