<template>
  <v-btn
    height="50px"
    width="50px"
    :color="stateColor"
    :rounded="false"
    @click="handleState"
    @contextmenu.prevent="handleRightClick"
    :icon="chosenIcon"
    :class="[
      type !== CellType.Playable ? 'no-pointer' : '',
      type === CellType.NonPlayable ? 'non-playable' : '',
      type === CellType.Hint ? 'hint' : '',
      mistakeMode === true && playerState != value && type === CellType.Playable ? 'mistake' : ''
    ]"
    flat
    >{{ type === CellType.Hint ? value : '' }}
  </v-btn>
</template>

<style scoped lang="scss">
.v-btn {
  border: 1px solid grey;
}
.no-pointer {
  pointer-events: none;
}

.non-playable {
  border: none;
  display: hidden;
}
.mistake {
  border: 2px solid red;
  opacity: 0.8;
  font-weight: bold;
}
.correct {
  border: 2px solid green;
}
</style>

<script setup lang="ts">
import { ref, computed, watch } from 'vue'
import { CellState, CellType } from '@/scripts/enums'

const props = withDefaults(
  defineProps<{
    type: CellType
    value: number
    mistakeMode: boolean
  }>(),
  {
    type: CellType.Playable,
    mistakeMode: false
  }
)

const emits = defineEmits<{
  (e: 'stateChange', state: number): number
}>()
const chosenIcon = ref('')

const state = ref(CellState.Empty)
const playerState = ref(0)

const stateColor = computed(() => {
  if (props.type === CellType.Hint) {
    return '#add8e6'
  }

  switch (state.value) {
    case CellState.Empty:
      return 'white'
    default:
      return 'primary'
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
  let stateValue = 0
  if (state.value === CellState.Empty) {
    state.value = CellState.Filled
    playerState.value = 1
    stateValue = 1
  } else {
    state.value = CellState.Empty
    playerState.value = 0

    stateValue = 0
  }

  emits('stateChange', stateValue)
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
