<template>
  <v-app>  
    <v-main>
      <RouterView></RouterView>
      <v-container>
      </v-container>
    </v-main>
  </v-app>
</template>

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