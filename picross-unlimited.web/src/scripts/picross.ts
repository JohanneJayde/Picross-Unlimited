import type Puzzle from '@/models'
import Axios from 'axios'
import _ from 'lodash'

export class Picross {
  public solution: number[][]
  public playerStates: number[][]
  public size: number
  public gameState: GameState
  public puzzle: Puzzle | undefined

  constructor() {
    this.solution = []
    this.size = 0
    this.playerStates = []
    this.gameState = GameState.Playing
  }

  public async startEditor() {
    this.playerStates = this.solution
    this.gameState = GameState.Edit
  }

  public async startNewGame() {
    //init playe states;
    for (let i = 0; i < this.size; i++) {
      this.playerStates[i] = []
      for (let j = 0; j < this.size; j++) {
        this.playerStates[i][j] = 0
      }
    }
    this.gameState = GameState.Playing
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

  public updatePlayerState(values: number[]): void {
    this.playerStates[values[0]][values[1]] = values[2]
    if (this.gameState === GameState.Playing) {
      this.checkForWin()
    }
  }

  public checkForWin() {
    if (_.isEqual(this.solution, this.playerStates)) {
      this.gameState = GameState.Won
    }
  }

  public async SavePuzzle(title: string, description: string, difficulty: number): boolean {
    const isSuccessful = Axios.post('Puzzle/SavePuzzle', {
      id: this.puzzle?.id,
      title: title,
      description: description,
      difficulty: difficulty,
      solution: JSON.stringify(this.solution)
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
