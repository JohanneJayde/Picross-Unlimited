import { createRouter, createWebHistory } from 'vue-router'
import index from '../views/index.vue'
import About from '../views/About.vue'
import Game from '../views/Game.vue'
import Player from '../views/Player.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: index
    },
    {
      path: '/About',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: About
    },
    {
      path: '/Game',
      name: 'game',
      component: Game
    },
    {
      path: '/Player',
      name: 'player',
      component: Player
    }
  ]
})

export default router
