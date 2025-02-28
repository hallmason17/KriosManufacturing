import { HttpClient, HttpHeaders } from '@angular/common/http';
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
    token = localStorage.getItem("access_token");


    getAll(): Observable<Item[]> {
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${this.token}`, 'Access-Control-Allow-Origin': '*' });
        return this.httpClient.get<Item[]>(this.itemsUrl, { headers: headers })
    }

    getById(id: number): Observable<Item> {
        const headers = new HttpHeaders({ 'Authorization': `Bearer ${this.token}` });
        return this.httpClient.get<Item>(this.itemsUrl + `/${id}`, { headers: headers });
    }
}
