import { Component, inject, OnInit, signal } from '@angular/core';
import { Item } from '../models/item';
import { ItemsService } from './items.service';
import { catchError } from 'rxjs';

@Component({
  selector: 'app-items',
  imports: [],
  templateUrl: './items.component.html',
  styleUrl: './items.component.scss',
})
export class ItemsComponent implements OnInit {
  itemService: ItemsService = inject(ItemsService);
  items = signal<Array<Item>>([]);
  loading: boolean = true;
  tableHeaders: Array<string> = ['Id', 'Sku', 'Name', 'Description'];
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
      });
  }

  sortArray<T>(arr: T[], compareFn: (a: T, b: T) => number): T[] {
    const sortedArray = [...arr];
    sortedArray.sort(compareFn);
    return sortedArray;
  }

  sort(column: string): void {
    this.items.set(
      this.items().sort((a, b) => (this.sortedAsc ? b.id - a.id : a.id - b.id)),
    );
    console.log(column);
    this.sortedAsc = !this.sortedAsc;
  }
}
