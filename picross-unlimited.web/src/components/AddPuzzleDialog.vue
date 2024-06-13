<template>
  <v-dialog v-model="modelValue">
    <v-card color="secondary" rounded>
      <v-card-title>Create a new Puzzle</v-card-title>
      <v-card-item>
        <v-col>
          <v-col>
            <v-text-field v-model="title" label="Title" />
          </v-col>
          <v-col>
            <v-text-field v-model="description" label="Description" />
          </v-col>

          <v-row>
            <v-col cols="6">
              <v-select v-model="color" :items="htmlColors" label="Colors">
                <template v-slot:prepend-item>
                  <v-chip :color="item">{{ item }}</v-chip>
                </template>
              </v-select>
            </v-col>

            <v-col cols="6">
              <v-text-field v-model="maxClicks" label="Max Clicks" />
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="6">
              <v-select
                v-model="difficulty"
                :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
                label="Difficulty"
              />
            </v-col>
            <v-col cols="6">
              <v-select v-model="size" :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]" label="SIze" />
            </v-col>
          </v-row>
        </v-col>
      </v-card-item>
      <v-card-actions>
        <v-btn @click="modelValue = false">Cancel</v-btn>
        <v-btn @click="createPuzzle">Create</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script setup lang="ts">
import { ref } from 'vue'
import { defineModel } from 'vue'
import { useRouter } from 'vue-router'
import Axios from 'axios'
import TokenService from '@/scripts/tokenService'
import htmlColors from '@/scripts/colors'
const title = ref('')
const description = ref('')
const difficulty = ref(1)
const size = ref(5)
const color = ref('')
const maxClicks = ref(0)

const modelValue = defineModel<boolean>({ default: false })

const tokenService = new TokenService()
const router = useRouter()

function createPuzzle() {
  Axios.post('Puzzle/CreatePuzzle', {
    title: title.value,
    description: description.value,
    difficulty: difficulty.value,
    size: size.value,
    creator: tokenService.getSub(),
    dateCreated: new Date(),
    solution: JSON.stringify(new Array(size.value).fill(new Array(size.value).fill(0))),
    color: color.value.toLowerCase(),
    maxClicks: maxClicks.value
  })
    .then((response) => {
      console.log('Puzzle created:', response.data)
      modelValue.value = false

      router.push({ name: 'Edit Puzzle', params: { id: response.data } })
    })
    .catch((error) => {
      console.error('Error creating puzzle:', error)
    })
}
</script>
