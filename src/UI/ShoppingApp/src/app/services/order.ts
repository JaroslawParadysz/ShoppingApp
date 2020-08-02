import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AuthService } from './auth.service';
import { OrderDetailsDto } from '../models/order-details.dto';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class OrderService {
    private readonly orderApiUrl = 'https://localhost:44337/api/orders/';
    constructor(private http: HttpClient,
                private auth: AuthService) { }

    getOrders() {
        const httpOptions = this.auth.createHttpOptions();
        return this.http.get(this.orderApiUrl, httpOptions);
    }

    getOrderDetails(orderId): Observable<OrderDetailsDto> {
        const httpOptions = this.auth.createHttpOptions();
        const url: string = this.orderApiUrl + orderId;
        return this.http.get<OrderDetailsDto>(
            url,
            httpOptions);
    }

    addOrder(request) {
        const httpOptions = this.auth.createHttpOptions();
        return this.http.post<OrderDetailsDto>(
            this.orderApiUrl,
            request,
            httpOptions);
    }

    updateOrderProduct(orderId, orderProductId, request) {
        const httpOptions = this.auth.createHttpOptions();
        const url = this.orderApiUrl + orderId + '/order-product/' + orderProductId;
        return this.http.put(url, request, httpOptions);
    }

    deleteOrderProduct(orderId, orderProductId) {
        const httpOptions = this.auth.createHttpOptions();
        const url = this.orderApiUrl + orderId + '/order-product/' + orderProductId;
        return this.http.delete(url);
    }

    addNewOrderProduct(orderId, request) {
        const httpOptions = this.auth.createHttpOptions();
        const url = this.orderApiUrl + orderId + '/order-product/';
        return this.http.post(url, request, httpOptions);
    }

    deleteOrder(orderId) {
        const httpOptions = this.auth.createHttpOptions();
        const url = this.orderApiUrl + orderId;
        return this.http.delete(url, httpOptions);
    }

    isLogged(): Observable<any> {
        const httpOptions = this.auth.createHttpOptions();
        const url = 'https://localhost:44337/api/users';
        return this.http.get(url, httpOptions);
    }


}
