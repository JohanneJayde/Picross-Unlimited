<template>
  <div v-if="puzzle">
    <Header :color="color" :title="title === '' ? 'Edit Puzzle' : title" />
    <v-container>
      <v-row>
        <v-col cols="4">
          <v-card :color="color" class="pa-5 rounded-xl">
            <v-text-field variant="outlined" v-model="title" label="Title" />
            <v-textarea variant="outlined" v-model="description" label="Description" />
            <v-text-field variant="outlined" v-model="maxClicks" label="Max Clicks" />
            <v-select variant="outlined" v-model="color" :items="htmlColors" label="Colors" />
            <v-select
              variant="outlined"
              v-model="difficulty"
              :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
              label="Difficulty"
            />
            <v-card-actions>
              <v-spacer />
              <v-btn variant="outlined" @click="savePuzzle">Save</v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
        <v-col cols="auto">
          <PicrossBoard
            :solution="solution"
            @playerUpdate="(values) => updateGameState(values)"
            :mistakeMode="false"
            :loadSolution="isEditing"
            :correctColor="color"
          />
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, reactive } from 'vue'
import type Puzzle from '../models/puzzle'
import { useRoute, useRouter } from 'vue-router'
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
import { Picross } from '@/scripts/picross'
import htmlColors from '@/scripts/colors'
import PuzzleUtils from '@/scripts/puzzleUtils'
import { toNumber } from 'lodash'
import Header from '@/components/Header.vue'

const puzzle = ref<Puzzle>()
const route = useRoute()
const router = useRouter()
const Game = reactive<Picross>(new Picross())
const title = ref('')
const description = ref('')
const difficulty = ref(1)
const maxClicks = ref(0)
const color = ref('')
const isEditing = ref(true)
const solution = ref<number[][]>([])

const id = route.params.id

function updateGameState(values: number[]) {
  Game.updatePlayerState(values)
  solution.value[values[0]][values[1]] = values[2]
}

onMounted(async () => {
  puzzle.value = await PuzzleUtils.getPuzzleById(toNumber(id))
  Game.setSize(puzzle.value!.size)
  Game.setSolution(JSON.parse(puzzle.value!.solution))
  Game.SetPuzzle(puzzle.value!)
  Game.startEditor()

  title.value = puzzle.value!.title
  description.value = puzzle.value!.description
  difficulty.value = puzzle.value!.difficulty
  maxClicks.value = puzzle.value!.maxClicks
  color.value = puzzle.value!.color.toLowerCase()
  solution.value = JSON.parse(puzzle.value!.solution)
  color.value = puzzle.value!.color
})

async function savePuzzle() {
  const success: boolean = await Game.SavePuzzle(
    title.value,
    description.value,
    difficulty.value,
    maxClicks.value,
    color.value
  )
  if (success) {
    router.push({ name: 'Puzzle Editor' })
  } else {
    console.error('Error saving puzzle')
  }
}
</script>
