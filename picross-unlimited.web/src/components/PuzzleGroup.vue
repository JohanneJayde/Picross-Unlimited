<template>
  <v-row>
    <v-col v-for="(puzzle, i) in puzzles" :key="i">
      <PuzzleCard :puzzle="puzzle" :EditMode="edit" />
    </v-col>
  </v-row>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models'
import PuzzleCard from '@/components/PuzzleCard.vue'

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
