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
    items = signal<Item[]>([]);
    loading = true;
    tableHeaders: string[] = ['id', 'sku', 'name', 'description'];
    sortedAsc = true;

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
                this.loading = false;
            });
    }
}
