<template>
  <v-container>
    <v-row justify="center">
      <v-col cols="12" md="8">
        <v-card class="pa-3 mb-4" color="primary">
          <v-card-title>My Puzles</v-card-title>
        </v-card>
        <PuzzleGroup :puzzles="Puzzles" :edit="true" />
      </v-col>
    </v-row>
  </v-container>
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
        colorPalette: new Map<number, string>(Object.entries(JSON.parse(puzzle.colorPalette))),
        solution: JSON.parse(puzzle.solution)
      })
    })
  })
  .catch((error) => {
    console.error('Error fetching puzzles:', error)
  })
</script>
