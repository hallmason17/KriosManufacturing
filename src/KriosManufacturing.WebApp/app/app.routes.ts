import { Routes } from '@angular/router';
import { HomeComponent } from '../pages/home/home.component';
import { AboutUsComponent } from '../pages/about-us/about-us.component';
import { CareersComponent } from '../pages/careers/careers.component';

export const routes: Routes = [
    { path: 'about', component: AboutUsComponent },
    { path: 'careers', component: CareersComponent },
    { path: '', component: HomeComponent }
];
