<template>
  <v-container v-if="tokenService.isLoggedIn()">
    <v-row justify="center">
      <v-col cols="12" md="12">
        
        <v-card class="pa-3 mb-4" color="primary">
          <v-card-title>Puzzle Editor</v-card-title>
        </v-card>
        
        <v-btn class="ma-3" @click="showAddPuzzleDialog = true" color="primary">Create Puzzle</v-btn>

        <PuzzleGroup :puzzles="Puzzles" :edit="true" @deletePuzzle="removePuzzle" />
      </v-col>
    </v-row>
  </v-container>
  <v-card v-else> 
    Sorry you must be logged in to create and edit Puzzles :(
  </v-card>
  <AddPuzzleDialog v-model="showAddPuzzleDialog" @close="showAddPuzzleDialog = false" />
</template>
<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import PuzzleGroup from '@/components/PuzzleGroup.vue'
import TokenService from '@/scripts/tokenService'
import AddPuzzleDialog from '@/components/AddPuzzleDialog.vue'

const tokenService = new TokenService()

const Puzzles = ref<Puzzle[]>([])
const showAddPuzzleDialog = ref(false);

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
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        solution: JSON.parse(puzzle.solution),
        maxClicks: puzzle.maxClicks,
        color: puzzle.color
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

      if(response.data) {
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
