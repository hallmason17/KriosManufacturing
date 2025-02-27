import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { CareersComponent } from './careers/careers.component';
import { LocationsComponent } from './locations/locations.component';
import { ItemsComponent } from './items/items.component';
import { InventoryLevelsComponent } from './inventory-levels/inventory-levels.component';
import { AuthComponent } from './auth/auth.component';

export const routes: Routes = [
    { path: 'items', component: ItemsComponent },
    { path: 'inventory-levels', component: InventoryLevelsComponent },
    { path: 'locations', component: LocationsComponent },
    { path: 'about', component: AboutUsComponent },
    { path: 'careers', component: CareersComponent },
    { path: 'login', component: AuthComponent },
    { path: 'register', component: AuthComponent },
    { path: '', component: HomeComponent }
];
