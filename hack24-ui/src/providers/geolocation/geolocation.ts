import { Injectable } from '@angular/core';
import { Geolocation, Geoposition } from '@ionic-native/geolocation';

/*
  Generated class for the GeolocationProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class GeolocationProvider {

  constructor(private geolocator: Geolocation) {
  }

  async getLocation(): Promise<Geoposition> {
    return await this.geolocator.getCurrentPosition();
  }
}
