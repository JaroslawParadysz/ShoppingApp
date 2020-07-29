import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailsComponent } from './order-details/order-detials.component';

import { WindowService } from './services/window';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { AppInterceptor } from './services/AppInterceptor';
import { MenuComponent } from './menu/menu.component';
import { AddNewOrderProductComponent } from './add-new-order-product/add-new-order-product.component';
import { OrderService } from './services/order';
import { ProductService } from './services/product';
import { AddNewOrderComponent } from './add-new-order/add-new-order.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderListComponent,
    OrderDetailsComponent,
    LoginComponent,
    RegisterComponent,
    MenuComponent,
    AddNewOrderProductComponent,
    AddNewOrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: 'windowObject', useValue: window },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppInterceptor,
      multi: true
    },
    WindowService,
    AuthService,
    OrderService,
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
