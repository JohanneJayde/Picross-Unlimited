<template>
  <v-card color="white" class="border" rouned>
    <v-card-title>{{ props.puzzle.title }}</v-card-title>
    <v-card-subtitle>{{ props.puzzle.description }}</v-card-subtitle>

    <v-card-text> Size: {{ props.puzzle.size }} </v-card-text>
    <v-card-text> Creator: {{ props.puzzle.creator }} </v-card-text>
    <v-card-text> Date Created: {{ formattedDate }} </v-card-text>
    
    <v-card-text>
      <v-progress-circular :model-value="difficulty * 10" :size="90" :width="15" color="red">
        {{ difficulty }}
      </v-progress-circular>
    </v-card-text>
    <v-card-actions>
      <v-btn :to="`Puzzle/${props.puzzle.id}`">Play</v-btn>
      <v-btn v-if="EditMode" :to="`EditPuzzle/${props.puzzle.id}`">Edit</v-btn>
      <v-btn v-if="EditMode" @click="$emit('delete', props.puzzle.id)">Delete</v-btn>

    </v-card-actions>
  </v-card>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models'
import { formatDate } from 'date-fns'
const props = withDefaults(
  defineProps<{
    puzzle: Puzzle
    EditMode?: boolean
  }>(),
  {
    EditMode: false
  }
)

defineEmits<{
  (e: 'delete', puzzleId : number): void
}>()

const formattedDate = formatDate(new Date(props.puzzle.dateCreated), 'MMMM do, yyyy')

const difficulty = ref<number>(props.puzzle.difficulty)
</script>
