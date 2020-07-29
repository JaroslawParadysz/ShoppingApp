import { catchError, map, switchMap, tap } from 'rxjs/operators';
import { Observable, EMPTY, Subscription } from 'rxjs';

import { OrderService } from './../services/order';
import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html',
    styleUrls: ['order-details.component.scss']
})

export class OrderDetailsComponent implements OnDestroy {
    private updateOrderProductSubscription: Subscription;
    private navigateToComponentSubscription: Subscription;

    OrderDetailsDto$ = this.route.paramMap.pipe(
        map(x => x.get('orderId')),
        switchMap(x => this.service.getOrderDetails(x)),
        tap(x => console.log(x)),
        catchError(error => {
            console.log(error);
            return EMPTY;
        })
    );

    constructor(
        private service: OrderService,
        private route: ActivatedRoute,
        private router: Router) { }

    onChanged(checked, orderProductId) {
        if (this.updateOrderProductSubscription) {
            this.updateOrderProductSubscription.unsubscribe();
        }

        const request = { Purchased: checked };
        this.updateOrderProductSubscription = this.route.paramMap.pipe(
            map(x => x.get('orderId')),
            switchMap(x => this.service.updateOrderProduct(x, orderProductId, request)),
            catchError(error => {
                console.log(error);
                return EMPTY;
            })
        ).subscribe(() => {});
    }

    onAddNewOrderProduct($event) {
        if (this.navigateToComponentSubscription) {
            return;
        }

        this.navigateToComponentSubscription = this.route.paramMap.pipe(
                map(x => x.get('orderId'))
            ).subscribe(orderId => {
                const url = 'add-new-order-product/' + orderId;
                console.log('UrL: ' + url);
                this.router.navigateByUrl(url);
            });
    }

    ngOnDestroy(): void {
        if (this.navigateToComponentSubscription) {
            this.navigateToComponentSubscription.unsubscribe();
        }
        if (this.updateOrderProductSubscription) {
            this.updateOrderProductSubscription.unsubscribe();
        }
    }
}
