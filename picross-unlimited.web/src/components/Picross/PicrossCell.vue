<template>
  <v-btn
    height="50px"
    width="50px"
    :color="stateColor"
    :rounded="false"
    @click="handleState"
    @contextmenu.prevent="handleRightClick"
    :icon="chosenIcon"
  />
</template>

<style scoped lang="scss">
.v-btn {
  border: 1px solid grey;
}
</style>

<script setup lang="ts">
import { ref, computed, watch } from 'vue'

enum CellState {
  Empty,
  Filled,
  Marked
}

const chosenIcon = ref('')

const state = ref(CellState.Empty)

const stateColor = computed(() => {
  switch (state.value) {
    case CellState.Empty:
      return 'white'
    default:
      return 'blue'
  }
})

watch(
  () => state.value,
  () => {
    if (state.value === CellState.Filled) {
      chosenIcon.value = ''
    }
  }
)

function handleState() {
  if (state.value === CellState.Empty) {
    state.value = CellState.Filled
  } else {
    state.value = CellState.Empty
  }
}

function handleRightClick() {
  if (chosenIcon.value === '') {
    state.value = CellState.Empty
    chosenIcon.value = 'mdi-close'
  } else {
    state.value = CellState.Empty
    chosenIcon.value = ''
  }
}
</script>
