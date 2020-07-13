import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class AppInterceptor implements HttpInterceptor {

    constructor(private router: Router){
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe( tap(() => {},
        (err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status !== 401) {
           return;
          }
          console.log('Need to login!');
          this.router.navigate(['login']);
        }
      }));
    }
}
