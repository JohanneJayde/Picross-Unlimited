<template>
  <v-container fluid>
    <v-row
      cols="12"
      v-for="(item, indexRow) in halfCeiling + props.solution[0].length"
      :key="indexRow"
      no-gutters
    >
      <v-col
        v-for="(item, indexCol) in halfCeiling + props.solution[0].length"
        :key="indexCol"
        cols="auto"
        no-gutters
      >
        <PicrossCell
          :type="getType(indexRow, indexCol)"
          :hintVal="getHintValue(indexRow, indexCol)"
        />
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import { CellType } from '@/scripts/enums'
import PicrossCell from './PicrossCell.vue'

const props = defineProps<{
  solution: number[][]
}>()

const halfCeiling =
  props.solution[0].length % 2 != 0
    ? Math.floor(props.solution[0].length * 0.5) + 1
    : Math.floor(props.solution[0].length * 0.5)

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

function generateHintValsRow(rowNum: number): number[] {
  let hintvals: number[] = new Array(halfCeiling).fill(0)

  let currentHintIndex = hintvals.length - 1

  for (let i = 0; i < props.solution[rowNum].length; i++) {
    if (props.solution[rowNum][i] == 1) {
      hintvals[currentHintIndex]++
    } else {
      if (hintvals[currentHintIndex] != 0) {
        currentHintIndex--
      }
    }
  }

  return hintvals
}

function generateHintValsColumn(colNum: number): number[] {
  let hintvals: number[] = new Array(halfCeiling).fill(0)

  let currentHintIndex = hintvals.length - 1

  for (let i = 0; i < props.solution[colNum].length; i++) {
    if (props.solution[i][colNum] == 1) {
      hintvals[currentHintIndex]++
    } else {
      if (hintvals[currentHintIndex] != 0) {
        currentHintIndex--
      }
    }
  }

  return hintvals
}

function getHintValue(row: number, col: number) {
  let hintVal = 0
  if (row < halfCeiling && col >= halfCeiling) {
    hintVal = generateHintValsColumn(col - halfCeiling)[row]
  }
  if (row >= halfCeiling && col < halfCeiling) {
    console.log('add hint for column', row, col)

    hintVal = generateHintValsRow(row - halfCeiling)[col]
  }

  return hintVal
}
console.log(generateHintValsRow(0))
</script>
