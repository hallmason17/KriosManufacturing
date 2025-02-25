import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Item } from '../models/item.type';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ItemsService {
    httpClient = inject(HttpClient)
    apiUrl = 'http://localhost:5069'
    itemsUrl = this.apiUrl + '/api/v1/items'


    getAll(): Observable<Item[]> {
        return this.httpClient.get<Item[]>(this.itemsUrl)
    }

    getById(id: number): Observable<Item> {
        return this.httpClient.get<Item>(this.itemsUrl + `/${id}`);
    }
}
