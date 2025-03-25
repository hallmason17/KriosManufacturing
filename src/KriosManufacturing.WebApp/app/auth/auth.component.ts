import { Component, inject } from '@angular/core';
import { AuthService } from '../core/services/auth.service';
import { FormControl, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-auth',
  imports: [ReactiveFormsModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
})
export class AuthComponent {
  authService: AuthService = inject(AuthService);
  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  login() {
    if (
      this.loginForm.value.email != null &&
      this.loginForm.value.password != null
    ) {
      this.authService.login(
        this.loginForm.value.email,
        this.loginForm.value.password,
      );
    }
  }
  logout() {
    this.authService.logout();
  }
}
