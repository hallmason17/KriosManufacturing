import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private httpClient: HttpClient, private cookieService: CookieService) { }

    login() {
        this.cookieService.set('test', 'hello world');
        console.log(this.cookieService.get('test'))
    }

    logout() {
        this.cookieService.delete('test');
    }

    isLoggedIn() {
        return this.cookieService.get('test') !== ""
    }
}
