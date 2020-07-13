import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class OrderService {
    constructor(private http: HttpClient,
                private auth: AuthService) { }

    getOrders() {
        const httpOptions = this.createHttpOptions();
        return this.http.get('https://localhost:44337/api/orders', httpOptions);
    }

    getOrderDetails(orderId) {
        const httpOptions = this.createHttpOptions();
        return this.http.get('https://localhost:44337/api/orders/' + orderId, httpOptions);
    }

    private createHttpOptions() {
        const token = this.auth.getToken();
        const authorizationHeader = 'Bearer ' + token;
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: authorizationHeader
            })
        };
        return httpOptions;
    }
}
