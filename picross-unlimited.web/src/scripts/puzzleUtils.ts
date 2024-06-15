import Axios from 'axios'
import type Puzzle from '../models/puzzle'

export default class PuzzleUtils {
  public static async getUserPuzzles(username: string): Promise<Puzzle[]> {
    const Puzzles: Puzzle[] = []
    const response = await Axios.get('Puzzle/Users/' + username)
    const puzzleData = response.data
    puzzleData.map((puzzle: Puzzle) => {
      Puzzles.push({
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        solution: puzzle.solution,
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        color: puzzle.color,
        maxClicks: puzzle.maxClicks
      })
    })
    return Puzzles
  }
  public static async getPuzzleById(puzzleId: number): Promise<Puzzle> {
    const response = await Axios.get('Puzzle/' + puzzleId)
    const puzzle = response.data
    return {
      id: puzzle.id,
      title: puzzle.title,
      description: puzzle.description,
      difficulty: puzzle.difficulty,
      size: puzzle.size,
      solution: puzzle.solution,
      creator: puzzle.creator,
      dateCreated: puzzle.dateCreated,
      color: puzzle.color,
      maxClicks: puzzle.maxClicks
    }
  }
  public static async getAllPuzzles(): Promise<Puzzle[]> {
    const Puzzles: Puzzle[] = []
    const response = await Axios.get('/Puzzle/AllPuzzles')
    const puzzleData = response.data
    puzzleData.map((puzzle: Puzzle) => {
      Puzzles.push({
        id: puzzle.id,
        title: puzzle.title,
        description: puzzle.description,
        difficulty: puzzle.difficulty,
        size: puzzle.size,
        solution: puzzle.solution,
        creator: puzzle.creator,
        dateCreated: puzzle.dateCreated,
        color: puzzle.color,
        maxClicks: puzzle.maxClicks
      })
    })
    return Puzzles
  }
}
