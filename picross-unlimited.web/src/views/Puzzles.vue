<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="12" md="8">
        <PuzzleGroup :puzzles="Puzzles" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import PuzzleGroup from '@/components/PuzzleGroup.vue'

const Puzzles = ref<Puzzle[]>([])

Axios.get('/Puzzle/AllPuzzles')
  .then((response) => response.data)
  .then((date) => {
    date.map((puzzle: Puzzle) => {
      Puzzles.value.push({
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        solution: JSON.parse(puzzle.solution)
      })
    })
  })
  .catch((error) => {
    console.error('Error fetching puzzles:', error)
  })
</script>
