<template>
  <v-row>
    <v-col v-for="(puzzle, i) in puzzles" :key="i" cols="4">
      <PuzzleCard :puzzle="puzzle" :EditMode="edit" @delete="(id) => $emit('deletePuzzle',id )" />
    </v-col>
  </v-row>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models'
import PuzzleCard from '@/components/PuzzleCard.vue'

defineEmits<{
  (e: 'deletePuzzle', puzzleId : number): void
}>()

const props = withDefaults(
  defineProps<{
    puzzles: Puzzle[]
    edit?: boolean
  }>(),
  {
    edit: false
  }
)
</script>
