import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailsComponent } from './order-details/order-detials.component';

import { WindowService } from './services/window';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderListComponent,
    OrderDetailsComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: 'windowObject', useValue: window },
    WindowService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
