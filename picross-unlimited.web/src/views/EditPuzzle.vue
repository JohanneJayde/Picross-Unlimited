<template>
  <v-container v-if="gamePuzzle">
    <v-card class="pa-3 mb-5" :color="gamePuzzle.color">
      <v-card-title>Edit Puzzle</v-card-title>
    </v-card>
    <v-row>
      <v-col cols="3">
        <v-card :color="gamePuzzle.color" class="pa-3" rounded>
          <v-card-title>Edit Puzzle</v-card-title>
        <v-text-field v-model="title" label="Title" />
        <v-text-field v-model="description" label="Description" />
        <v-text-field v-model="maxClicks" label="Max Clicks" />
        <v-select v-model="color" :items="htmlColors" label="Colors"/>
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
          :correctColor="gamePuzzle.color"
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
import htmlColors from '@/scripts/colors'

const gamePuzzle = ref<Puzzle>()
const route = useRoute()
const router = useRouter()
const Game = reactive<Picross>(new Picross())
const title = ref('')
const description = ref('')
const difficulty = ref(1)
const maxClicks = ref(0)
const color = ref('')

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
        solution: JSON.parse(puzzle.solution),
        color: puzzle.color,
        maxClicks: puzzle.maxClicks
      }
      Game.setSize(gamePuzzle.value!.size)
      Game.setSolution(gamePuzzle.value!.solution)
      Game.SetPuzzle(gamePuzzle.value!)
      Game.startEditor()

      title.value = gamePuzzle.value!.title
      description.value = gamePuzzle.value!.description
      difficulty.value = gamePuzzle.value!.difficulty
      maxClicks.value = gamePuzzle.value!.maxClicks
      color.value = gamePuzzle.value!.color.toLowerCase()
    })
    .catch((error) => {
      console.error('Error fetching puzzles:', error)
    })
})

async function savePuzzle() {
  const success: boolean =  await Game.SavePuzzle(title.value, description.value, difficulty.value, maxClicks.value, color.value)
  if (success) {
    router.push({ name: 'Puzzle Editor' })
  } else {
    console.error('Error saving puzzle')
  }
}
</script>
