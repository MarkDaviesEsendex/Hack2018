import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { GoogleMapsProvider } from '../../providers/google-maps/google-maps';
import { GoogleMap } from '@ionic-native/google-maps';

// this.icons = ['flask', 'wifi', 'beer', 'football', 'basketball', 'paper-plane',
//     'american-football', 'boat', 'bluetooth', 'build'];

@Component({
  selector: 'map',
  templateUrl: 'map.html'
})
export class MapPage {
  map: GoogleMap;

  constructor(private googleMapsProvider: GoogleMapsProvider) {
  }

  ionViewDidLoad(): void {
    console.log('[MAP] Loading up map');
    this.googleMapsProvider.loadMap('mapthing').then((map) => {
      this.map = map;
      console.log(`[MAP] Map Loaded: ${JSON.stringify(this.map)}`);
    });

  }
}
