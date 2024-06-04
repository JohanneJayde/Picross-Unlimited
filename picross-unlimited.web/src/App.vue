<template>
  <v-app> 
    <div class="text-h5 ml-5">
          <v-icon
            color="secondary"
            @click="router.push('/')"
            class="cursor-pointer"
            >mdi-alpha-w</v-icon
          >
        </div> 
    <v-app-bar app>
      <v-app-bar-nav-icon @click.stop="showDrawer = !showDrawer" />
      <v-toolbar-title>Picross Unlimited</v-toolbar-title>
      <nav>
        <v-btn @click="navigateTo('home')">Home</v-btn>
        <v-btn @click="navigateTo('about')">About</v-btn>
      </nav>
    </v-app-bar>
    <v-navigation-drawer v-model="showDrawer" location="left">
      <v-list>
        <v-list-item @click="navigateTo('home')">Home</v-list-item>
        <v-list-item @click="navigateTo('about')">About</v-list-item>
        <v-list-item @click="navigateTo('game')">Play</v-list-item>
        <v-list-item @click="navigateTo('settings')">Settings</v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
    
      <RouterView></RouterView>
    </v-main>
  </v-app>
</template>
<script setup lang="ts">
import { useRouter } from 'vue-router';
import { ref } from 'vue';

const router = useRouter();
const showDrawer = ref(false);

function navigateTo(page) {
  router.push({ name: page });
}
</script>

<style scoped>
nav {
  display: flex;
  gap: 10px;
}

nav a {
  text-decoration: none;
  color: inherit;
}

nav a.v-btn {
  color: #1976d2;
}
</style>