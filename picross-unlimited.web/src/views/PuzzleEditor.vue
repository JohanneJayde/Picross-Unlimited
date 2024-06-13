<template>
  <v-container v-if="tokenService.isLoggedIn()">
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card class="pa-3 mb-4" color="primary">
          <v-card-title>My Puzles</v-card-title>
        </v-card>
        <v-btn @click="createPuzzle">Create Puzzle</v-btn>
        <v-select v-model="Size" :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]" label="Size of Puzzle" />
        <PuzzleGroup :puzzles="Puzzles" :edit="true" />
      </v-col>
    </v-row>
  </v-container>
  <v-card v-else> Sorry you must be logged in to create and edit Puzzles :(</v-card>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import PuzzleGroup from '@/components/PuzzleGroup.vue'
import TokenService from '@/scripts/tokenService'

const tokenService = new TokenService()

const Puzzles = ref<Puzzle[]>([])

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
        solution: JSON.parse(puzzle.solution)
      })
    })
  })
  .catch((error) => {
    console.error('Error fetching puzzles:', error)
  })

const Size = ref(5)
function createPuzzle() {
  Axios.post('Puzzle/CreatePuzzle', {
    title: 'New Puzzle',
    description: 'New Puzzle',
    difficulty: 1,
    size: Size.value,
    creator: tokenService.getSub(),
    dateCreated: new Date(),
    solution: JSON.stringify(new Array(Size.value).fill(new Array(Size.value).fill(0)))
  })
    .then((response) => {
      console.log('Puzzle created:', response.data)
    })
    .catch((error) => {
      console.error('Error creating puzzle:', error)
    })
}
</script>
