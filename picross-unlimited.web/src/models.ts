export default interface Puzzle {
  id: number
  title: string
  description: string
  difficulty: number
  size: number
  solution: number[][]
  creator: string
  dateCreated: string
}

export default interface UpdatePuzzle {
  id: number
  title: string
  description: string
  difficulty: number
  solution: number[][]
}
