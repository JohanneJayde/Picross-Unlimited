<template>
  <v-card :color="props.puzzle.color" class="rounded-xl pa-3">
    <v-row justify="start" no-gutters>
      <v-col cols="auto">
        <v-progress-circular :model-value="difficulty * 10" :size="60" :width="10" class="ma-1">
          {{ difficulty }}
        </v-progress-circular>
      </v-col>
      <v-col cols="auto">
        <v-card-title class="font-weight-bold text-wrap">{{ props.puzzle.title }}</v-card-title>
      </v-col>
      <v-col align="end">
        <v-chip variant="outlined" class="ma-1"> {{ formattedDate }} </v-chip>
      </v-col>
    </v-row>

    <v-card-item>
      <span>{{ props.puzzle.description }}</span>
    </v-card-item>

    <v-card-item>
      <v-chip variant="outlined" class="ma-1"> Size: {{ props.puzzle.size }} </v-chip>
      <v-chip variant="outlined" class="ma-1"> Creator: {{ props.puzzle.creator }} </v-chip>
      <v-chip variant="outlined" class="ma-1"> Max Clicks: {{ props.puzzle.maxClicks }} </v-chip>
    </v-card-item>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn rounded variant="outlined" :to="`Puzzle/${props.puzzle.id}`">Play</v-btn>
      <v-btn rounded variant="outlined" v-if="EditMode" :to="`EditPuzzle/${props.puzzle.id}`"
        >Edit</v-btn
      >
      <v-btn rounded variant="outlined" v-if="EditMode" @click="$emit('delete', props.puzzle.id)"
        >Delete</v-btn
      >
    </v-card-actions>
  </v-card>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models/puzzle'
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
  (e: 'delete', puzzleId: number): void
}>()

const formattedDate = formatDate(new Date(props.puzzle.dateCreated), 'MMMM do, yyyy')

const difficulty = ref<number>(props.puzzle.difficulty)
</script>
