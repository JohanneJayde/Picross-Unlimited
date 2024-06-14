<template>
  <v-container v-if="tokenService.isLoggedIn()">
    <v-row justify="center">
      <v-col cols="12" md="12">
        <v-card class="pa-3 mb-4" color="primary">
          <v-card-title>Puzzle Editor</v-card-title>
        </v-card>

        <v-btn class="ma-3" @click="showAddPuzzleDialog = true" color="primary"
          >Create Puzzle</v-btn
        >

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

const tokenService = new TokenService()

const Puzzles = ref<Puzzle[]>([])
const showAddPuzzleDialog = ref(false)

Axios.get('Puzzle/Users/' + tokenService.getSub())
  .then((response) => response.data)
  .then((date) => {
    date.map((puzzle: Puzzle) => {
      Puzzles.value.push({
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        solution: puzzle.solution,
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        color: puzzle.color,
        maxClicks: puzzle.maxClicks
      })
    })
  })
  .catch((error) => {
    console.error('Error fetching puzzles:', error)
  })

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
