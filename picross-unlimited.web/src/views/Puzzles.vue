<template>
  <Header title="Puzzles" />
  <v-container>
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
import Header from '@/components/Header.vue'
import PuzzleGroup from '@/components/PuzzleGroup.vue'
import PuzzleUtils from '@/scripts/puzzleUtils'

const Puzzles = ref<Puzzle[]>([])

onMounted(async () => {
  Puzzles.value = await PuzzleUtils.getAllPuzzles()
})
</script>
