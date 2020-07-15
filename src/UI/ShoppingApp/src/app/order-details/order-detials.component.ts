import { OrderService } from './../services/order';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WindowService, WindowSize } from './../services/window';

@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html',
    styleUrls: ['order-details.component.scss']
})

export class OrderDetailsComponent implements OnInit, OnDestroy {
    windowSize: WindowSize;
    subscription;
    orderId;
    order;

    constructor(
        private service: OrderService,
        private windowService: WindowService,
        private route: ActivatedRoute) {
            route.paramMap.subscribe(x => {
                this.orderId = x.get('orderId');
                service.getOrderDetails(this.orderId)
                    .subscribe(y => this.order = y);
            });
        }

    ngOnInit() {
        this.subscription = this.windowService.windowSizeChanged.subscribe(
            value => this.windowSize = value
        );
    }

    onChanged(checked, name) {
        console.log('OK');
        console.log(checked);
        console.log(name);
    }

    ngOnDestroy() {
        this.subscription = null;
    }
}
