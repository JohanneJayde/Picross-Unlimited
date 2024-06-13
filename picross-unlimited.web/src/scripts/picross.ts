export class Picross {
  public solution: number[][]
  public playerStates: number[][]
  public size: number

  constructor(size: number, solution: number[][]) {
    this.solution = solution
    this.size = size
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
}

export enum GameState {
  Playing,
  Won,
  Lost
}
