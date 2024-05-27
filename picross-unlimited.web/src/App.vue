<template>
  <v-app>  
    <v-container>
            <v-app-bar :elevation="2">
            <template v-slot:prepend>
              <v-app-bar-nav-icon variant="text" @click.stop=""></v-app-bar-nav-icon>
            </template>
             
            <v-app-bar-title>Picross</v-app-bar-title>
            <v-spacer></v-spacer>
            <v-navigation-drawer
            v-model="drawer"
            :location="$vuetify.display.mobile ? 'bottom' : undefined"
            temporary
            >
            <v-list>
              <v-list-item>
                <v-list-item-icon>
                  <v-icon>mdi-home</v-icon>
                </v-list-item-icon>
                <v-list-item-content>
                  <v-list-item-title @click="navigateTo('home')">Home</v-list-item-title>
                </v-list-item-content>
              </v-list-item>
            </v-list>
          </v-navigation-drawer>           
            </v-app-bar>
      </v-container>
    <v-main>
    
      <RouterView></RouterView>
    </v-main>
  </v-app>
</template>
<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

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