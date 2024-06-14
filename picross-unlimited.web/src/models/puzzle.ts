export default interface Puzzle {
  id: number
  title: string
  description: string
  difficulty: number
  size: number
  solution: string
  creator: string
  dateCreated: string
  color: string
  maxClicks: number
}
