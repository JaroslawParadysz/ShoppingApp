import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../services/product';
import { OrderService } from '../services/order';
import { map, switchMap } from 'rxjs/operators';
import { Subscription } from 'rxjs';

@Component({
    selector: 'app-add-new-order-product',
    templateUrl: 'add-new-order-product.component.html',
    styleUrls: ['add-new-order-product.component.scss']
})
export class AddNewOrderProductComponent implements OnDestroy {
    subscriptions: Subscription;
    constructor(formBuilder: FormBuilder,
                private productService: ProductService,
                private orderService: OrderService,
                private route: ActivatedRoute,
                private router: Router) {
        this.addNewProductForm = formBuilder.group({
            product: ['', [Validators.required]],
            quantity: ['', [Validators.required]]
        });
    }
    addNewProductForm: FormGroup;
    products$ = this.productService.getOrders();

    onAddNewOrderProduct() {
        const orderProductToAdd = {
            productId: this.product.value,
            quantity: this.quantity.value
        };

        this.subscriptions = this.route.paramMap.pipe(
            map(x => x.get('orderId')),
            switchMap(x => this.orderService.addNewOrderProduct(x, orderProductToAdd)),
        ).subscribe(() => {
            const sub = this.route.paramMap.subscribe(x => {
                const orderId = x.get('orderId');
                const url = 'order/' + orderId;
                this.router.navigateByUrl(url);
            });
            this.subscriptions.add(sub);
        });
    }

    get product() {
        return this.addNewProductForm.get('product');
    }

    get quantity() {
        return this.addNewProductForm.get('quantity');
    }

    ngOnDestroy(): void {
        if (this.subscriptions) {
            this.subscriptions.unsubscribe();
        }
    }
}
