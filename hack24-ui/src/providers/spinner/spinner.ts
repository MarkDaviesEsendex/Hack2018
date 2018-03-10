import { Injectable } from '@angular/core';
import {BehaviorSubject} from 'rxjs/src/BehaviorSubject';

@Injectable()
export class SpinnerProvider {
  status = new BehaviorSubject<boolean>(false);

  start() : void {
    this.status.next(true);
  }

  stop() : void {
    this.status.next(false);
  }

}
