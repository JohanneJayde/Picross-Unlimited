<template>
  <v-card color="primary" rouned>
    <v-card-title>{{ props.puzzle.title }}</v-card-title>
    <v-card-subtitle>{{ props.puzzle.description }}</v-card-subtitle>
    <v-card-text>
      <v-row>
        <v-col cols="12" md="6">
          <v-chip color="primary">{{ props.puzzle.difficulty }}</v-chip>
        </v-col>
        <v-col cols="12" md="6">
          <v-chip color="primary">{{ props.puzzle.size }}</v-chip>
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import type Puzzle from '../models'

const props = defineProps<{
  puzzle: Puzzle
}>()
</script>
