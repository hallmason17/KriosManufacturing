import { Component, input, type OnInit } from '@angular/core';
import { ItemsService } from '../items.service';
import { type Item } from '../../models/item.type';

@Component({
  selector: 'app-item',
  imports: [],
  templateUrl: './item.component.html',
  styleUrl: './item.component.scss',
})
export class ItemComponent implements OnInit {
  itemId = input.required<number>();
  item?: Item;

  constructor(private itemsService: ItemsService) {}

  ngOnInit() {
    this.itemsService.getById(this.itemId()).subscribe((item) => {
      this.item = item;
    });
  }
}
