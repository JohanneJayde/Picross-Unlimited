<template>
  <v-card class="pa-3 mb-4" :color="color">
    <v-card-title class="font-weight-bold">{{ title }}</v-card-title>
  </v-card>
</template>

<script setup lang="ts">
withDefaults(
  defineProps<{
    title: string
    color?: string
  }>(),
  {
    color: 'primary'
  }
)
</script>
