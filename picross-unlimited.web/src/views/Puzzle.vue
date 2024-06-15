<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <v-container v-if="puzzle">
    <v-card class="pa-3" :color="puzzle.color">
      <v-card-title>{{ puzzle.title }}</v-card-title>
      <v-card-subtitle>{{ puzzle.description }}</v-card-subtitle>
      <v-card-subtitle>Difficulty: {{ puzzle.difficulty }}</v-card-subtitle>
      <v-card-subtitle>Creator: {{ puzzle.creator }}</v-card-subtitle>
      <v-card-subtitle>Date Created: {{ puzzle.dateCreated }}</v-card-subtitle>
    </v-card>
    <v-row align="center" justify="center">
      <v-col cols="12">
        <PicrossBoard
          :solution="JSON.parse(puzzle.solution)"
          @playerUpdate="(values) => updateGameState(values)"
          :mistakeMode="mistakeMode"
          :loadSolution="false"
          :correctColor="puzzle.color"
        />
      </v-col>
    </v-row>
    <v-dialog v-model="showEndScreen" persistent>
      <v-card
        width="500"
        class="mx-auto pa-3 rounded-xl"
        :color="Game.gameState === GameState.Won ? 'green' : 'red'"
      >
        <v-card-title v-if="Game.gameState === GameState.Won" class="text-center font-weight-bold">
          Congrats! You Won!</v-card-title
        >
        <v-card-title v-else class="text-center font-weight-bold"> Sorry You Lost :(</v-card-title>
        <v-card-text class="text-center text-h4"> You Clicked a total of {{ count }}!</v-card-text>
        <v-card-actions class>
          <v-btn @click="$router.push({ name: 'Puzzles' })">Go Back To Puzzles</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive, watch } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models/puzzle'
import { useRoute } from 'vue-router'
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
import { Picross, GameState } from '@/scripts/picross'
import TokenService from '@/scripts/tokenService'
import PuzzleUtils from '@/scripts/puzzleUtils'
import { toNumber } from 'lodash'

const puzzle = ref<Puzzle>()
const router = useRoute()
const Game = reactive<Picross>(new Picross())
const mistakeMode = ref(false)
const tokenService = new TokenService()
const showEndScreen = ref(false)

const count = ref(0)
const id = router.params.id

function updateGameState(values: number[]) {
  Game.updatePlayerState(values)
  count.value++
}

watch(Game, () => {
  if (Game.gameState != GameState.Playing) {
    showEndScreen.value = true
    Axios.post(`/Game/Post/`, {
      username: tokenService.getUserName(),
      puzzleId: puzzle.value!.id,
      isWin: Game.gameState == GameState.Won,
      numberOfClicks: count.value
    })
      .then(() => {
        console.log('Game recorded')
      })
      .catch((error) => {
        console.error('Error recording win:', error)
      })
  }
})

onMounted(async () => {
  puzzle.value = await PuzzleUtils.getPuzzleById(toNumber(id))
  Game.setSize(puzzle.value!.size)
  Game.setSolution(JSON.parse(puzzle.value!.solution))
  Game.SetMaxClicks(puzzle.value!.maxClicks)
  Game.startNewGame()
})
</script>
