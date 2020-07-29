import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../services/product';

@Component({
    selector: 'app-add-new-order-product',
    templateUrl: 'add-new-order-product.component.html',
    styleUrls: ['add-new-order-product.component.scss']
})
export class AddNewOrderProductComponent {
    constructor(formBuilder: FormBuilder,
                private productService: ProductService){
        this.addNewProductForm = formBuilder.group({
            product: ['', [Validators.required]],
            quantity: ['', [Validators.required]]
        });
    }

    addNewProductForm: FormGroup;
    products$ = this.productService.getOrders();

    onAddNewOrderProduct() {
        if (!this.addNewProductForm.invalid){
            console.log('NO');
            return;
        }
        const orderProductToAdd = {
            productId: this.product.value,
            quantity: this.quantity.value
        };
        console.log(orderProductToAdd);
    }

    get product() {
        return this.addNewProductForm.get('product');
    }

    get quantity() {
        return this.addNewProductForm.get('quantity');
    }
}
