import { catchError, map, switchMap } from 'rxjs/operators';
import { Observable, EMPTY } from 'rxjs';

import { OrderService } from './../services/order';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html',
    styleUrls: ['order-details.component.scss']
})

export class OrderDetailsComponent {
    orderId;
    OrderDetailsDto$ = this.route.paramMap.pipe(
        map(x => x.get('orderId')),
        switchMap(x => this.service.getOrderDetails(x)),
        catchError(error => {
            console.log(error);
            return EMPTY;
        })
    );

    constructor(
        private service: OrderService,
        private route: ActivatedRoute) { }

    onChanged(checked, orderProductId) {
        const request = { Purchased: checked };
        this.route.paramMap.pipe(
            map(x => x.get('orderId')),
            switchMap(x => this.service.updateOrderProduct(x, orderProductId, request)),
            catchError(error => {
                console.log(error);
                return EMPTY;
            })
        ).subscribe(() => {});
    }
}
