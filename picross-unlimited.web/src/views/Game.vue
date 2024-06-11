<!-- eslint-disable vue/multi-word-component-names -->
<template>
  <v-container>
    <v-row align="center" justify="center">
      <v-col cols="12">
        <PicrossBoard :size="10" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import PicrossBoard from '@/components/Picross/PicrossBoard.vue'
</script>
