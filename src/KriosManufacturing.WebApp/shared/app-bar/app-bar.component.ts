import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon'

@Component({
  selector: 'app-app-bar',
  standalone: true,
  imports: [RouterLink, MatIcon],
  templateUrl: './app-bar.component.html',
  styleUrl: './app-bar.component.scss'
})
export class AppBarComponent {

}
