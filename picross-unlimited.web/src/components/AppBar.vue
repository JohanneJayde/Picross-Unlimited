<template>
    <v-app>  
        <v-container>
            <v-app-bar :elevation="2">
            <template v-slot:prepend>
                <v-app-bar-nav-icon @click="navigateTo('home')"></v-app-bar-nav-icon>
            </template>
             
            <v-app-bar-title>Picross</v-app-bar-title>
            </v-app-bar>
        </v-container>
    </v-app>
</template>
<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

function navigateTo(page) {
  router.push({ name: page });
}
</script>