import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { ImageProvider } from '../../providers/image/image';
import { GeolocationProvider } from '../../providers/geolocation/geolocation';
import { Geoposition } from '@ionic-native/geolocation';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  latitude: number;
  longitude: number;
  imageBase64: string;

  constructor(public navCtrl: NavController, private imageProvider: ImageProvider, private geolocator: GeolocationProvider) { }

  async takePicture() {
    const location = await this.geolocator.getLocation();
    this.latitude = location.coords.latitude;
    this.longitude = location.coords.longitude;
    this.imageBase64 = await this.imageProvider.takePicture();
    console.log(`[CORDOVA] ${this.latitude}, ${this.longitude}`);
    console.log(`[CORDOVA] ${this.imageBase64}`);
  }
}
