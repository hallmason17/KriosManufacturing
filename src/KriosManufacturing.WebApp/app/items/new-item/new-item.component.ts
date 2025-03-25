import { Component } from "@angular/core";
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from "@angular/forms";
import { ItemsService } from "../items.service";

@Component({
  selector: "app-new-item",
  imports: [ReactiveFormsModule],
  templateUrl: "./new-item.component.html",
  styleUrl: "./new-item.component.scss",
})
export class NewItemComponent {
  itemForm = new FormGroup({
    sku: new FormControl("", [Validators.required, Validators.maxLength(64)]),
    name: new FormControl("", [Validators.required, Validators.maxLength(128)]),
    description: new FormControl("", [Validators.maxLength(256)]),
  });

  constructor(private itemService: ItemsService) {}

  onSubmit() {
    console.log(this.itemForm);
  }
}
