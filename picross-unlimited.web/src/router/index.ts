import { createRouter, createWebHistory } from 'vue-router'
import index from '../views/index.vue'
import About from '../views/About.vue'
import Player from '../views/Player.vue'
import Puzzles from '../views/Puzzles.vue'
import Puzzle from '../views/Puzzle.vue'
import PuzzleEditor from '../views/PuzzleEditor.vue'

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
      path: '/Player',
      name: 'Player',
      component: Player
    },
    {
      path: '/Puzzles',
      name: 'Puzzles',
      component: Puzzles
    },
    {
      path: '/Puzzle/:id',
      name: 'Puzzle',
      component: Puzzle
    },
    {
      path: '/PuzzleEditor',
      name: 'Puzzle Editor',
      component: PuzzleEditor
    }
  ]
})

export default router
