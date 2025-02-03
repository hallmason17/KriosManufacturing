import { Component, inject, OnInit, signal } from '@angular/core';
import { Item } from '../models/item';
import { ItemsService } from './items.service';
import { catchError } from 'rxjs';

@Component({
    selector: 'app-items',
    imports: [],
    templateUrl: './items.component.html',
    styleUrl: './items.component.scss'
})
export class ItemsComponent implements OnInit {
    itemService = inject(ItemsService)
    items = signal<Array<Item>>([])

    ngOnInit(): void {
        this.itemService.getAll()
            .pipe(
                catchError((err) => {
                    console.log(err);
                    throw err;
                }))
            .subscribe((items) => {
                this.items.set(items);
            })
    }
}
