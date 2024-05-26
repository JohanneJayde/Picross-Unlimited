<template>
    <div>
      <h1>Welcome to the Home Page</h1>
      <v-btn @click="showLoginDialog = true">Sign In</v-btn>
  
      <SigninDialog v-model:visible="showLoginDialog" />
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  import SigninDialog from '@/components/SigninDialog.vue';
  
  const showLoginDialog = ref(false);
  </script>