import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { CareersComponent } from './careers/careers.component';

export const routes: Routes = [
    { path: 'about', component: AboutUsComponent },
    { path: 'careers', component: CareersComponent },
    { path: '', component: HomeComponent }
];
