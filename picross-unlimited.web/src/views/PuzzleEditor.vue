<template>
  <Header title="Puzzle Editor" />
  <v-container>
    <v-row justify="center">
      <v-col cols="12">
        <v-btn @click="showAddPuzzleDialog = true" color="primary" prepend-icon="mdi-plus"
          >Create Puzzle</v-btn
        >
      </v-col>
      <v-col cols="12">
        <PuzzleGroup :puzzles="Puzzles" :edit="true" @deletePuzzle="removePuzzle" />
      </v-col>
    </v-row>
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
import Header from '@/components/Header.vue'

const tokenService = new TokenService()

const Puzzles = ref<Puzzle[]>([])
const showAddPuzzleDialog = ref(false)

Puzzles.value = await PuzzleUtils.getUserPuzzles(tokenService.getSub())

function removePuzzle(id: number) {
  Axios.delete('Puzzle/DeletePuzzle?puzzleId=' + id)
    .then((response) => {
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
