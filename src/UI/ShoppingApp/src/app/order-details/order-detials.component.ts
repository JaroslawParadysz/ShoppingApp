import { catchError } from 'rxjs/operators';
import { Observable, EMPTY } from 'rxjs';
import { OrderService } from './../services/order';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WindowService, WindowSize } from './../services/window';
import { OrderDetailsDto } from '../models/order-details.dto';

@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html',
    styleUrls: ['order-details.component.scss']
})

export class OrderDetailsComponent implements OnInit {
    orderId;
    OrderDetailsDto$: Observable<OrderDetailsDto>;

    constructor(
        private service: OrderService,
        private route: ActivatedRoute) { }

    ngOnInit() {
        this.route.paramMap.subscribe(x => {
            this.orderId = x.get('orderId');
            this.setOrderDetailsDto();
        });
    }

    onChanged(checked, orderProductId) {
        const request = { Purchased: checked };
        this.service.updateOrderProduct(this.orderId, orderProductId, request)
            .subscribe(() => {
                this.setOrderDetailsDto();
            });
    }

    private setOrderDetailsDto() {
        this.OrderDetailsDto$ = this.service.getOrderDetails(this.orderId).pipe(
            catchError(error => {
                console.log(error);
                return EMPTY;
            })
        );
    }
}
