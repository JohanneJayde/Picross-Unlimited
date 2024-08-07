import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: () => import('@/views/index.vue')
    },
    {
      path: '/About',
      name: 'About',
      component: () => import('@/views/About.vue')
    },
    {
      path: '/Player',
      name: 'Player',
      component: () => import('@/views/Player.vue')
    },
    {
      path: '/Puzzles',
      name: 'Puzzles',
      component: () => import('@/views/Puzzles.vue')
    },
    {
      path: '/Puzzle/:id',
      name: 'Puzzle',
      component: () => import('@/views/Puzzle.vue')
    },
    {
      path: '/PuzzleEditor',
      name: 'Puzzle Editor',
      component: () => import('@/views/PuzzleEditor.vue')
    },
    {
      path: '/EditPuzzle/:id',
      name: 'Edit Puzzle',
      component: () => import('@/views/EditPuzzle.vue')
    },
    {
      path: '/Register',
      name: 'Register',
      component: () => import('@/views/Register.vue')
    }
  ]
})

export default router
