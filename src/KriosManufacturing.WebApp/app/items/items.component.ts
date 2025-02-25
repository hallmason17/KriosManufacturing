import { Component, inject, OnInit, signal } from '@angular/core';
import { Item } from '../models/item.type';
import { ItemsService } from './items.service';
import { MatTableModule } from '@angular/material/table';
import { catchError } from 'rxjs';

@Component({
    selector: 'app-items',
    imports: [MatTableModule],
    templateUrl: './items.component.html',
    styleUrl: './items.component.scss',
})
export class ItemsComponent implements OnInit {
    itemService: ItemsService = inject(ItemsService);
    items = signal<Array<Item>>([]);
    loading: boolean = true;
    tableHeaders: Array<string> = ['id', 'sku', 'name', 'description'];
    sortedAsc: boolean = true;

    ngOnInit(): void {
        this.itemService
            .getAll()
            .pipe(
                catchError((err) => {
                    console.log(err);
                    throw err;
                }),
            )
            .subscribe((items) => {
                this.items.set(items);
                console.log(this.items());
            });
    }
}
