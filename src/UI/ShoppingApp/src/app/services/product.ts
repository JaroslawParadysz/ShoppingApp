import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { ProductDto } from '../models/product.dto';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ProductService {
    constructor(private http: HttpClient,
                private auth: AuthService){ }

    getOrders(): Observable<ProductDto[]> {
        const httpOptions = this.auth.createHttpOptions();
        return this.http.get<ProductDto[]>('https://localhost:44337/api/products', httpOptions);
    }
}
