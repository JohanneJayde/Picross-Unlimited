<template>
  <v-container v-if="gamePuzzle">
    <v-row align="center" justify="center">
      <v-col cols="12">
        <PicrossBoard :solution="gamePuzzle.solution" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import { useRoute } from 'vue-router'
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
import { Picross } from '@/scripts/picross'

const Game = ref<Picross>()
const gamePuzzle = ref<Puzzle>()
const router = useRoute()

const id = router.params.id

onMounted(() => {
  Axios.get(`/Puzzle/${id}`)
    .then((response) => response.data)
    .then((puzzle: Puzzle) => {
      gamePuzzle.value = {
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        colorPalette: new Map<number, string>(Object.entries(JSON.parse(puzzle.colorPalette))),
        solution: JSON.parse(puzzle.solution)
      }
    })
    .catch((error) => {
      console.error('Error fetching puzzles:', error)
    })
})
</script>
