<template>
  <v-app>
    <v-app-bar app flat class="border-md">
      <v-app-bar-nav-icon @click="showDrawer = !showDrawer" />
      <v-img
        @click="router.push('/')"
        class="cursor-pointer"
        src="/applogo.svg"
        alt="Logo"
        max-width="180"
        max-height="110"
      />
      <v-spacer />
      <v-menu :close-on-content-click="false" v-model="showSignInMenu">
        <template v-slot:activator="{ props }">
          <v-btn
            v-bind="props"
            v-if="$vuetify.display.smAndUp"
            prepend-icon="mdi-account-cowboy-hat"
          >
            {{ tokenService.getUserName() }}
          </v-btn>
          <v-btn v-bind="props" :icon="loggedIn ? 'mdi-account' : 'mdi-login'" v-else />
        </template>
        <SignInMenu @loginLogout="handleLoginLogout" />
      </v-menu>
    </v-app-bar>
    <v-main>
      <RouterView />
    </v-main>
    <v-navigation-drawer v-model="showDrawer" location="left">
      <v-list>
        <v-list-item to="/About">About</v-list-item>
        <v-list-item to="/Puzzles">View Puzzles</v-list-item>
        <v-list-item to="/Player" v-if="loggedIn">Profile</v-list-item>
        <v-list-item to="/PuzzleEditor" v-if="loggedIn">Puzzle Creator</v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-app>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router'
import { computed, reactive, ref, watch } from 'vue'
import TokenService from './scripts/tokenService'
import SignInMenu from '@/components/SignInMenu.vue'

const router = useRouter()
const showDrawer = ref(false)
const tokenService = reactive(new TokenService())
const showSignInMenu = ref(false)

const loggedIn = computed(() => tokenService.isLoggedIn())

const handleLoginLogout = () => {
  showSignInMenu.value = false
}
</script>
