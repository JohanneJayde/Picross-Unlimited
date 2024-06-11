<template>
  <v-container fluid>
    <v-row cols="12" v-for="(item, index) in size" :key="index" no-gutters>
      <v-col v-for="(item, index) in size" :key="index" cols="auto" no-gutters>
        <PicrossCell />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import PicrossCell from './PicrossCell.vue'

const props = defineProps<{
  size: number
}>()
</script>
