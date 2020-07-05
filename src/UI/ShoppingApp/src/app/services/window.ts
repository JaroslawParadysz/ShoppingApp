import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, fromEvent } from 'rxjs';
import { auditTime, map } from 'rxjs/operators';

export interface WindowSize {
  height: number;
  width: number;
}

@Injectable()
export class WindowService {

  constructor(@Inject('windowObject') private window: Window) {

    fromEvent(window, 'resize')
        .pipe(auditTime(100))
        .pipe(map(event => <WindowSize>{ 
          width: (event.target as Window).innerWidth, 
          height: (event.target as Window).innerHeight
        }))
        .subscribe((windowSize) => {
            this.windowSizeChanged.next(windowSize);
        })
  };

  readonly windowSizeChanged = new BehaviorSubject<WindowSize>(<WindowSize>{
    width: this.window.innerWidth,
    height: this.window.innerHeight
  });

}
