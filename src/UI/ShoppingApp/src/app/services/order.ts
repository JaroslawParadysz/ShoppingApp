import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({providedIn: 'root'})
export class OrderService {
    constructor(private http: HttpClient) { }

    getOrders() {
        return this.http.get('https://localhost:44337/api/orders');
    }
}
