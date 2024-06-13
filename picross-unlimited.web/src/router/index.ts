import { createRouter, createWebHistory } from 'vue-router'
import index from '../views/index.vue'
import About from '../views/About.vue'
import Game from '../views/Game.vue'
import Player from '../views/Player.vue'
import Puzzles from '../views/Puzzles.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: index
    },
    {
      path: '/About',
      name: 'About',
      component: About
    },
    {
      path: '/Game',
      name: 'Game',
      component: Game
    },
    {
      path: '/Player',
      name: 'Player',
      component: Player
    },
    {
      path: '/Puzzles',
      name: 'Puzzles',
      component: Puzzles
    }
  ]
})

export default router
