<template>
  <v-container v-if="gamePuzzle">
    <v-row align="center" justify="center">
      <v-col cols="12">
        <v-btn @click="mistakeMode = !mistakeMode">Show Mistakes</v-btn>
        {{ mistakeMode }}
        <PicrossBoard
          :solution="gamePuzzle.solution"
          @playerUpdate="(values) => updateGameState(values)"
          :mistakeMode="mistakeMode"
        />
      </v-col>
      <v-alert v-if="gameWon" color="green">Congrats!!!</v-alert>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive, computed } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import { useRoute } from 'vue-router'
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
import { Picross, GameState } from '@/scripts/picross'

const gamePuzzle = ref<Puzzle>()
const router = useRoute()
const Game = reactive<Picross>(new Picross())
const mistakeMode = ref(false)
const gameWon = computed(() => {
  if (Game.gameState === GameState.Playing) {
    return false
  }
  return true
})

const id = router.params.id

function updateGameState(values: number[]) {
  Game.updatePlayerState(values)
}

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
      Game.setSize(gamePuzzle.value.size)
      Game.setSolution(gamePuzzle.value.solution)
      Game.startNewGame()
    })
    .catch((error) => {
      console.error('Error fetching puzzles:', error)
    })
})
</script>
