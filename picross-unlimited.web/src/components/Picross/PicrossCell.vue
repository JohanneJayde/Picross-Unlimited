<template>
  <v-btn
    height="50"
    width="50"
    :color="stateColor"
    :rounded="false"
    @click="handleState"
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
</style>

<script setup lang="ts">
import { ref, onMounted, watch } from 'vue'
import { CellState, CellType } from '@/scripts/enums'

const props = withDefaults(
  defineProps<{
    type: CellType
    value: number
    mistakeMode: boolean
    startSolved: boolean
    correctColor: string
  }>(),
  {
    type: CellType.Playable,
    mistakeMode: false,
    correctColor: 'primary'
  }
)

const emits = defineEmits<{
  (e: 'stateChange', state: number): number
}>()
const chosenIcon = ref('')

const state = ref(CellState.Empty)
const playerState = ref(0)

const stateColor = ref(props.type === CellType.Hint ? '#89cff0' : 'white')

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
    stateColor.value = props.correctColor
    playerState.value = 1
    stateValue = 1
  } else {
    state.value = CellState.Empty
    stateColor.value = 'white'
    playerState.value = 0

    stateValue = 0
  }

  emits('stateChange', stateValue)
}

onMounted(() => {
  if (props.startSolved) {
    if (props.value === 1 && props.type === CellType.Playable) {
      state.value = CellState.Filled
      stateColor.value = props.correctColor
      playerState.value = 1
    }
  }
})
</script>
