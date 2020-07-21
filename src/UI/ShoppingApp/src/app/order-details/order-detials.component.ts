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

export class OrderDetailsComponent implements OnInit, OnDestroy {
    windowSize: WindowSize;
    subscription;
    orderId;
    orderDetailsDto: OrderDetailsDto;

    constructor(
        private service: OrderService,
        private windowService: WindowService,
        private route: ActivatedRoute) {
            route.paramMap.subscribe(x => {
                this.orderId = x.get('orderId');
                this.loadData();
            });
        }

    ngOnInit() {
        this.subscription = this.windowService.windowSizeChanged.subscribe(
            value => this.windowSize = value
        );
    }

    onChanged(checked, orderProductId) {
        const request = { Purchased: checked };
        this.service.updateOrderProduct(this.orderId, orderProductId, request)
            .subscribe(() => {
                this.loadData();
            });
    }

    ngOnDestroy() {
        this.subscription = null;
    }

    private loadData() {
        return this.service.getOrderDetails(this.orderId)
            .subscribe(orderDetailsDto => {
                this.orderDetailsDto = orderDetailsDto;
            });
    }
}
