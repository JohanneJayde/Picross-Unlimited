<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title class="text-wrap">{{ title }}</v-card-title>
      </v-sheet>
      <v-card-text class="text-body-1 ma-3 text-center">{{ messsage }}</v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" variant="tonal" @click="cancel()" text="Cancel" />
        <v-btn color="primary" variant="elevated" :text="action" @click="close()" />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const props = withDefaults(
  defineProps<{
    title: string
    messsage: string
    action: string
  }>(),
  {
    title: 'Confirm',
    messsage: 'Are you sure?',
    action: 'Confirm'
  }
)

const emits = defineEmits(['updated', 'cancel'])

const modelValue = defineModel<boolean>({ default: false })

function close() {
  modelValue.value = false
  emits('updated')
}

function cancel() {
  modelValue.value = false
  emits('cancel')
}
</script>
