<template>
  <v-container>
    <v-card class="pa-3 mb-4" color="primary">
      <v-card-title>Puzzles</v-card-title>
    </v-card>
    <v-row justify="center">
      <v-col cols="12">
        <PuzzleGroup :puzzles="Puzzles" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type Puzzle from '../models/puzzle'
import PuzzleGroup from '@/components/PuzzleGroup.vue'
import PuzzleUtils from '@/scripts/puzzleUtils'

const Puzzles = ref<Puzzle[]>([])

onMounted(async () => {
  Puzzles.value = await PuzzleUtils.getAllPuzzles()
})
</script>
