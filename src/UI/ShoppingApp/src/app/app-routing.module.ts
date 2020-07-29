import { AddNewOrderComponent } from './add-new-order/add-new-order.component';
import { AddNewOrderProductComponent } from './add-new-order-product/add-new-order-product.component';
import { RegisterComponent } from './register/register.component';
import { OrderDetailsComponent } from './order-details/order-detials.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';

import { OrderListComponent } from './order-list/order-list.component';

const routes: Routes = [
  { path: '', component: OrderListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'order/:orderId', component: OrderDetailsComponent },
  { path: 'add-new-order-product/:orderId', component: AddNewOrderProductComponent },
  { path: 'add-new-order', component: AddNewOrderComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
