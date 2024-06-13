<template>
  <v-container v-if="gamePuzzle">
    <v-card class="pa-3 mb-5" color="primary">
      <v-card-title>Edit Puzzle</v-card-title>
    </v-card>
    <v-row>
      <v-col cols="3">
        <v-card color="secondary" class="pa-3" rounded>
          <v-card-title>Edit Puzzle</v-card-title>
        <v-text-field v-model="title" label="Title" />
        <v-text-field v-model="description" label="Description" />
        <v-select
          v-model="difficulty"
          :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
          label="Difficulty"
        />
        <v-btn @click="savePuzzle">Save</v-btn>

      </v-card>
      </v-col>
      <v-col cols="auto">
        <PicrossBoard
          :solution="gamePuzzle.solution"
          @playerUpdate="(values) => updateGameState(values)"
          :mistakeMode="false"
          :loadSolution="true"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive, computed } from 'vue'
import Axios from 'axios'
import type Puzzle from '../models'
import { useRoute, useRouter } from 'vue-router'
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
import { Picross, GameState } from '@/scripts/picross'

const gamePuzzle = ref<Puzzle>()
const route = useRoute()
const router = useRouter()
const Game = reactive<Picross>(new Picross())
const title = ref('')
const description = ref('')
const difficulty = ref(1)

const id = route.params.id

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
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        solution: JSON.parse(puzzle.solution)
      }
      Game.setSize(gamePuzzle.value.size)
      Game.setSolution(gamePuzzle.value.solution)
      Game.SetPuzzle(gamePuzzle.value)
      Game.startEditor()

      title.value = gamePuzzle.value.title
      description.value = gamePuzzle.value.description
      difficulty.value = gamePuzzle.value.difficulty
    })
    .catch((error) => {
      console.error('Error fetching puzzles:', error)
    })
})

function savePuzzle() {
  const success: boolean = Game.SavePuzzle(title.value, description.value, difficulty.value)
  if (success) {
    router.push({ name: 'Puzzle Editor' })
  } else {
    console.error('Error saving puzzle')
  }
}
</script>
