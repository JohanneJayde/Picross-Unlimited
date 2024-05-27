<template>
  <v-app>
    <v-main>
      <v-container>
        <RouterView />
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import SigninDialog from '../components/SignInDialogue.vue';

const showLoginDialog = ref(false);
</script>