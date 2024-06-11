<template>
  <v-container fluid>
    <v-row cols="12" v-for="(item, indexRow) in halfCeiling + size" :key="indexRow" no-gutters>
      <v-col v-for="(item, indexCol) in halfCeiling + size" :key="indexCol" cols="auto" no-gutters>
        <PicrossCell :type="getType(indexRow, indexCol)" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import { CellType } from '@/scripts/enums'
import PicrossCell from './PicrossCell.vue'

const props = defineProps<{
  size: number
}>()

const halfCeiling =
  props.size % 2 != 0 ? Math.floor(props.size * 0.5) + 1 : Math.floor(props.size * 0.5)

function getType(row: number, col: number) {
  if (row < halfCeiling && col < halfCeiling ? CellType.NonPlayable : CellType.Playable) {
    return CellType.NonPlayable
  } else if (
    (row < halfCeiling && col >= halfCeiling) ||
    (row >= halfCeiling && col < halfCeiling)
  ) {
    return CellType.Hint
  }
  return CellType.Playable
}
</script>
