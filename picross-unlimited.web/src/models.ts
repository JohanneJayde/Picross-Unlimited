export default interface Puzzle {
  id: number
  title: string
  description: string
  difficulty: number
  size: number
  solution: number[][]
  creator: string
  dateCreated: string
  color: string
  maxClicks: number
}

export default interface UpdatePuzzle {
  id: number
  title: string
  description: string
  difficulty: number
  solution: number[][]
  color: string
  maxClicks: number

}

export default interface Game {
  username : string
  isWin : boolean
  numberOfClicks : number
  puzzleId : number

}
