import type Puzzle from '@/models/puzzle'
import Axios from 'axios'
import _ from 'lodash'

export class Picross {
  public solution: number[][]
  public playerStates: number[][]
  public size: number
  public gameState: GameState
  public puzzle: Puzzle | undefined
  public maxClicks: number
  public playerClicks: number

  constructor() {
    this.solution = []
    this.size = 0
    this.playerStates = []
    this.gameState = GameState.Playing
    this.playerClicks = 0
    this.maxClicks = 0
  }

  public async startEditor() {
    this.playerStates = this.solution
    this.gameState = GameState.Edit
  }

  public async startNewGame() {
    for (let i = 0; i < this.size; i++) {
      this.playerStates[i] = []
      for (let j = 0; j < this.size; j++) {
        this.playerStates[i][j] = 0
      }
    }
    this.gameState = GameState.Playing
    this.playerClicks = 0
  }

  public setSolution(solution: number[][]) {
    this.solution = solution
  }
  public setSize(size: number) {
    this.size = size
  }

  public SetPuzzle(puzzle: Puzzle) {
    this.puzzle = puzzle
  }

  public SetMaxClicks(maxClicks: number) {
    this.maxClicks = maxClicks
  }

  public updatePlayerState(values: number[]): void {
    this.playerClicks++
    this.playerStates[values[0]][values[1]] = values[2]
    if (this.gameState === GameState.Playing) {
      if (_.isEqual(this.solution, this.playerStates)) {
        this.gameState = GameState.Won
      } else if (this.playerClicks >= this.maxClicks) {
        this.gameState = GameState.Lost
      }
    }
  }
  public async SavePuzzle(
    title: string,
    description: string,
    difficulty: number,
    maxClicks: number,
    color: string
  ): Promise<boolean> {
    const isSuccessful = Axios.post('Puzzle/SavePuzzle', {
      id: this.puzzle?.id,
      title: title,
      description: description,
      difficulty: difficulty,
      solution: JSON.stringify(this.solution),
      color: color.toLowerCase(),
      maxClicks: maxClicks
    }).then((response) => {
      return response.data
    })
    return isSuccessful
  }
}

export enum GameState {
  Playing,
  Won,
  Lost,
  Edit
}
