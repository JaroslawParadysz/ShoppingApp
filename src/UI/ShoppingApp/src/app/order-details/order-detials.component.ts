import { OrderService } from './../services/order';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html',
    styleUrls: ['order-details.component.scss']
})

export class OrderDetailsComponent implements OnInit {
    orderId;
    order;

    constructor(
        private service: OrderService,
        private route: ActivatedRoute) {
            route.paramMap.subscribe(x => {
                this.orderId = x.get('orderId');
                service.getOrderDetails(this.orderId)
                    .subscribe(y => this.order = y);
            });
        }

    ngOnInit() { }
}
