import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-add-new-order-product',
    templateUrl: 'add-new-order-product.component.html',
    styleUrls: ['add-new-order-product.component.scss']
})
export class AddNewOrderProductComponent {
    addNewProductForm: FormGroup;
    products$ = [
        { ProductId: 1, ProductName: 'Ziemniaki' },
        { ProductId: 2, ProductName: 'Maka' },
    ];

    constructor(formBuilder: FormBuilder){
        this.addNewProductForm = formBuilder.group({
            product: ['', [Validators.required]],
            quantity: ['', [Validators.required]]
        });
    }

    onAddNewOrderProduct() {
        console.log(this.addNewProductForm.value);
    }

    get product() {
        return this.addNewProductForm.get('product');
    }

    get quantity() {
        return this.addNewProductForm.get('quantity');
    }
}
