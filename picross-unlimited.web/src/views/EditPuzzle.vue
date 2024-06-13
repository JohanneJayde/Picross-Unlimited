<template>
  <v-container v-if="gamePuzzle">
    <v-card class="pa-3" color="primary">
      <v-card-title>{{ gamePuzzle.title }}</v-card-title>
      <v-card-subtitle>{{ gamePuzzle.description }}</v-card-subtitle>
    </v-card>
    <v-row align="center" justify="center">
      <v-col cols="6">
        <PicrossBoard
          :solution="gamePuzzle.solution"
          @playerUpdate="(values) => updateGameState(values)"
          :mistakeMode="false"
          :loadSolution="true"
        />
      </v-col>
    </v-row>
    <v-btn @click="SavePuzzle">Save</v-btn>
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
      Game.SetPuzzle(gamePuzzle.value)
      Game.startEditor()
    })
    .catch((error) => {
      console.error('Error fetching puzzles:', error)
    })
})

function savePuzzle() {
  Game.SaveCurrentPuzzle()
}
</script>
