import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AuthService } from './auth.service';
import { OrderDetailsDto } from '../models/order-details.dto';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class OrderService {
    constructor(private http: HttpClient,
                private auth: AuthService) { }

    getOrders() {
        const httpOptions = this.auth.createHttpOptions();
        return this.http.get('https://localhost:44337/api/orders', httpOptions);
    }

    getOrderDetails(orderId): Observable<OrderDetailsDto> {
        const httpOptions = this.auth.createHttpOptions();
        const url: string = 'https://localhost:44337/api/orders/' + orderId;
        return this.http.get<OrderDetailsDto>(
            url,
            httpOptions);
    }

    updateOrderProduct(orderId, orderProductId, request) {
        const httpOptions = this.auth.createHttpOptions();
        const url = 'https://localhost:44337/api/orders/' + orderId + '/order-product/' + orderProductId;
        return this.http.put(url, request, httpOptions);
    }

    addNewOrderProduct(orderId, request) {
        const httpOptions = this.auth.createHttpOptions();
        const url = 'https://localhost:44337/api/orders/' + orderId + '/order-product/';
        return this.http.post(url, request, httpOptions);
    }

    isLogged(): Observable<any> {
        const httpOptions = this.auth.createHttpOptions();
        const url = 'https://localhost:44337/api/users';
        return this.http.get(url, httpOptions);
    }


}
