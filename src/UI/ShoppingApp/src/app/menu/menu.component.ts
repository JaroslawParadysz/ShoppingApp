import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order';

@Component({
    selector: 'app-menu',
    templateUrl: 'menu.component.html',
    styleUrls: ['menu.component.scss']
})

export class MenuComponent implements OnInit {
    isLoged: boolean;

    constructor(private orderService: OrderService) {
        this.setDelay();
    }

    private setDelay() {
        setTimeout(() => { this.setTimeoutMethod(); }, 1000);
    }

    private setTimeoutMethod() {
        this.isLoged = false;
        this.orderService.isLogged()
            .subscribe(() => {
                this.isLoged = true;
            },
                (error) => {
                    this.isLoged = false;
                    this.setDelay();
                }
            );
    }

    ngOnInit() { }
}
