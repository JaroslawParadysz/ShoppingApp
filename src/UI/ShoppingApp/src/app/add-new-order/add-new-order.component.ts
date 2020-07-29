import { Router } from '@angular/router';
import { OrderService } from './../services/order';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-new-order',
    templateUrl: 'add-new-order.component.html'
})

export class AddNewOrderComponent {
    addNewOrderForm: FormGroup;

    constructor(private fb: FormBuilder,
                private orderService: OrderService,
                private router: Router) {
        this.addNewOrderForm = fb.group({
            orderName: ['', Validators.required]
        });
    }

    onAddNewOrder() {
        const newOrder = {
            orderName: this.orderName.value
        };

        this.orderService.addOrder(newOrder).subscribe(() => {
            this.router.navigateByUrl('');
        });
    }

    get orderName() {
        return this.addNewOrderForm.get('orderName');
    }
}
