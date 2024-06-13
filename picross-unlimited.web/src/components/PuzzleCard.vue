<template>
  <v-card color="white" class="border" width="500" rouned :to="`Puzzle/${props.puzzle.id}`">
    <v-card-title>{{ props.puzzle.title }}</v-card-title>
    <v-card-subtitle>{{ props.puzzle.description }}</v-card-subtitle>
    <v-card-text> Size: {{ props.puzzle.size }} </v-card-text>

    <v-card-text>
      <v-progress-circular :model-value="difficulty * 10" :size="90" :width="15" color="red">
        {{ difficulty }}
      </v-progress-circular>
    </v-card-text>
  </v-card>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models'

const props = defineProps<{
  puzzle: Puzzle
}>()

const difficulty = ref<number>(props.puzzle.difficulty)
</script>
