<!-- eslint-disable vue/valid-v-slot -->
<template>
  <v-container>
    <v-card class="pa-3 mb-4" color="primary">
      <v-card-title>{{ userName + "'s Profile" }}</v-card-title>
    </v-card>

    <v-row>
      <v-col cols="6">
        <v-col cols="12">
        <v-card color="primary" class="pa-3 rounded-xl">
          <v-card-title class="d-flex justify-center">Games Played:</v-card-title>
          <v-data-table 
          :headers="[
            { title: 'Date Played', key: 'datePlayed', value: 'datePlayed' },
            { title: 'Total', key: 'numberOfClicks', value: 'numberOfClicks' },
            { title: 'Win', key: 'isWin', value: 'isWin' },
            { title: 'Puzzle Title', key: 'puzzleTitle', value: 'puzzleTitle'},

          ]"
          :items="gameStats"

          >
            <template v-slot:item.datePlayed="{item}">
              {{ new Date(item.DatePlayed).toLocaleDateString() }}
            </template>
            <template v-slot:item.isWin="{item}" >
              <v-chip :color="item.isWin ? 'success' : 'error'">
                {{ item.isWin ? 'Win' : 'Loss' }}
              </v-chip>
            </template>
          </v-data-table>
        </v-card>
      </v-col>
      </v-col>
      <v-col cols="6">
        <v-col cols="12">
          <v-card color="primary" class="pa-3 rounded-xl">
            <v-card-title class="text-center">Detailed Stats:</v-card-title>
            <v-card-item> Total Games Played: {{ gameStats.length }}</v-card-item>
            <v-card-item>
              Total Wins Played:
              {{ gameStats.filter((game) => game.isWin === true).length }}</v-card-item
            >
            <v-card-item>
              Total Clicks:
              {{ _.sum(gameStats.map((gamestat) => gamestat.numberOfClicks)) }}</v-card-item
            >
            <v-card-item>
              First Game Played on:
              {{ _.min(gameStats.map((stats) => stats.datePlayed)) }}</v-card-item
            >
          </v-card>
        </v-col>

        <v-col cols="12">
          <v-card color="primary" class="pa-3 rounded-xl">
            <v-card-title class="text-center">Puzzles Made:</v-card-title>
 
            <v-card-item>
              <v-col v-for="(puzzle, i) in puzzles" :key="i">
              <v-btn :color="puzzle.color" @click="$router.push(
                { name: 'Puzzle', params: { id: puzzle.id } }
              )" class="w-100" rounded variant="flat" >
                {{ puzzle.title }}
              </v-btn>
            </v-col>
            </v-card-item>
          </v-card>
        </v-col>
      </v-col>
    </v-row>
  </v-container>
</template>
<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type GameDetail from '@/models'
import TokenService from '@/scripts/tokenService'
import type Puzzle from '@/models'
import _ from 'lodash'
import Axios from 'axios'

const tokenService = new TokenService()
const userName = tokenService.getUserName() ?? 'Guest'
const gameStats = ref<GameDetail[]>([])

const puzzles = ref<Puzzle[]>([])

onMounted(() => {
  console.log('User:', tokenService.getUserName())

  Axios.get('Game/Stats/$' + tokenService.getUserName())
    .then((response) => {
      gameStats.value = response.data
      console.log('Stats:', gameStats.value)
    })
    .catch((error) => {
      console.error('Error fetching stats:', error)
    })
})

Axios.get('Puzzle/Users/' + tokenService.getSub())
  .then((response) => response.data)
  .then((date) => {
    date.map((puzzle: Puzzle) => {
      puzzles.value.push({
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        solution: JSON.stringify(puzzle.solution),
        maxClicks: puzzle.maxClicks,
        color: puzzle.color
      })
    })
  })
  .catch((error) => {
    console.error('Error fetching puzzles:', error)
  })
</script>
