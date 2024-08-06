export default class TokenService {
  private tokenKey: string = 'token'

  public setToken(token: string) {
    localStorage.setItem(this.tokenKey, token)
  }

  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? ''
  }

  public isLoggedIn(): boolean {
    // Won't work if the token is expired
    return this.getToken() !== ''
  }

  public getUserName() {
    const token = this.getToken()
    if (token === '') {
      return 'Guest'
    }
    return JSON.parse(atob(token.split('.')[1])).email
  }

  public getSub() {
    const token = this.getToken()
    if (token === '') {
      return ''
    }
    return JSON.parse(atob(token.split('.')[1])).sub
  }
  public generateTokenHeader() {
    return { Authorization: 'Bearer $(this.getToken()}' }
  }
}
