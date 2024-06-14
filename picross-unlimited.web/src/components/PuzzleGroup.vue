<template>
  <v-row>
    <v-col v-for="(puzzle, i) in puzzles" :key="i" cols="4">
      <PuzzleCard :puzzle="puzzle" :EditMode="edit" @delete="(id) => $emit('deletePuzzle', id)" />
    </v-col>
  </v-row>
</template>
<script setup lang="ts">
import type Puzzle from '../models/puzzle'
import PuzzleCard from '@/components/PuzzleCard.vue'

defineEmits<{
  (e: 'deletePuzzle', puzzleId: number): void
}>()

withDefaults(
  defineProps<{
    puzzles: Puzzle[]
    edit?: boolean
  }>(),
  {
    edit: false
  }
)
</script>
