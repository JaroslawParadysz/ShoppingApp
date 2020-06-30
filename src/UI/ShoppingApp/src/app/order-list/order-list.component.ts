import { Component, OnInit } from '@angular/core';

import { OrderService } from './../services/order';

@Component({
    selector: 'app-order-list',
    templateUrl: 'order-list.component.html',
    styleUrls: ['order-list.component.scss']
})

export class OrderListComponent implements OnInit {
    orders = [];
    constructor(private orderService: OrderService) {
    }

    ngOnInit() {
        this.orderService.getOrders().subscribe((response: any[]) => {
            this.orders = response;
        });
    }
}
