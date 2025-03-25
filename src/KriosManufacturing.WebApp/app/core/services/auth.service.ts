import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
  ) {}

  isLoggedIn = () => localStorage.getItem('access_token') != null;
  loggedInUser = () => localStorage.getItem('user');

  login(email: string, password: string) {
    const authRequest = this.httpClient.post<AuthReponse>(
      'http://localhost:5069/login',
      { email: email, password: password },
    );

    authRequest
      .pipe(
        catchError((err) => {
          console.log(err);
          throw err;
        }),
      )
      .subscribe((res) => {
        localStorage.setItem('access_token', res.accessToken);
        localStorage.setItem('refresh_token', res.refreshToken);
        localStorage.setItem('user', email);
        this.router.navigate(['/items']);
      });
  }
  logout() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('user');
  }
}

interface AuthReponse {
  tokenType: string;
  accessToken: string;
  expiresIn: number;
  refreshToken: string;
}
