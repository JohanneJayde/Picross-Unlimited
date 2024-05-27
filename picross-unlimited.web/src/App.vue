<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>Picross Game</v-toolbar-title>
      <v-spacer></v-spacer>
      <RouterLink to="/about">About</RouterLink>
      <RouterLink to="/">Home</RouterLink>
    </v-app-bar>
    <v-main>
      <RouterView></RouterView>
      <v-container>
      </v-container>
    </v-main>
  </v-app>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
