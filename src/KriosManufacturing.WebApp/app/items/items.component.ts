import { Component, inject, type OnInit, signal } from "@angular/core";
import { type Item } from "../models/item.type";
import { ItemsService } from "./items.service";
import { MatTableModule } from "@angular/material/table";
import { catchError } from "rxjs";
import { AuthService } from "../core/services/auth.service";

@Component({
  selector: "app-items",
  imports: [MatTableModule],
  templateUrl: "./items.component.html",
  styleUrl: "./items.component.scss",
})
export class ItemsComponent implements OnInit {
  itemService: ItemsService = inject(ItemsService);
  authService: AuthService = inject(AuthService);
  items = signal<Item[]>([]);
  loading = true;
  tableHeaders: string[] = ["id", "sku", "name", "description"];
  sortedAsc = true;

  ngOnInit(): void {
    if (this.authService.isLoggedIn()) {
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
}
