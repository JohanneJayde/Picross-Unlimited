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
          <v-app-bar-nav-icon>
            <v-avatar v-bind="props">
              <v-icon icon="mdi-account" />
            </v-avatar>
          </v-app-bar-nav-icon>
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
        <v-list-item to="/Player" v-if="tokenService.isLoggedIn()">Profile</v-list-item>
        <v-list-item to="/PuzzleEditor" v-if="tokenService.isLoggedIn()"
          >Puzzle Creator</v-list-item
        >
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

const handleLoginLogout = () => {
  showSignInMenu.value = false
}
</script>
