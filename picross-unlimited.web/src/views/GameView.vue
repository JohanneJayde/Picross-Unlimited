<template>
  <v-container>
      <v-card>
          <v-row v-for="(row,rowIndex) in grid" :key="rowIndex" no-gutters>
              <v-col v-for="(cell, colIndex) in row" :key="colIndex">
                  <v-btn @click="fillCell(rowIndex, colIndex)">
                      {{ cell }}
                  </v-btn>
              </v-col>
          </v-row>
      </v-card>
  </v-container>
</template>

<script lang ="ts">
import { useRouter } from 'vue-router';
import { ref } from 'vue';

import { defineComponent } from 'vue';
    //now
    //1. set up an 2D array to store the game board
    //2. set up a function that fills the with x or o
    export default defineComponent({
        name: 'GridButtons',
        data() {
        return {
            grid: this.createGrid()
        };
    },
        methods: {
            createGrid(): string[][] {
            const size = 10;
            const grid = Array.from({ length: size }, (_, rowIndex) => 
                Array.from({ length: size }, (_, colIndex) => 
                colIndex <= rowIndex ? 'o' : 'x'
                )
            );
            return grid;
            },
            fillCell(rowIndex: number, colIndex: number) {
               this.grid[rowIndex][colIndex] = this.grid[rowIndex][colIndex] === 'o' ? 'x' : 'o';
            }
        }
    });

const router = useRouter();

function navigateTo(page) {
  router.push({ name: page });
}
</script>