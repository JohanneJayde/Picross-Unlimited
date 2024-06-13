import _ from 'lodash'

export class Picross {
  public solution: number[][]
  public playerStates: number[][]
  public size: number

  constructor() {
    this.solution = []
    this.size = 0
    this.playerStates = []
  }

  public async startNewGame() {
    //init playe states;
    for (let i = 0; i < this.size; i++) {
      this.playerStates[i] = []
      for (let j = 0; j < this.size; j++) {
        this.playerStates[i][j] = 0
      }
    }
  }

  public setSolution(solution: number[][]) {
    this.solution = solution
  }
  public setSize(size: number) {
    this.size = size
  }

  public updatePlayerState(values: number[]): void {
    this.playerStates[values[0]][values[1]] = values[2]

    this.checkForWin()
  }

  public checkForWin() {
    if (_.isEqual(this.solution, this.playerStates)) {
      console.log('Winnner')
    } else {
      console.log('keep trying!!!')
    }
  }
}

export enum GameState {
  Playing,
  Won,
  Lost
}
