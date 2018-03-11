import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController } from 'ionic-angular';
import { GoogleMapsProvider } from '../../providers/google-maps/google-maps';
import { GoogleMap } from '@ionic-native/google-maps';
import { TagsProvider } from '../../providers/tags/tags';

// this.icons = ['flask', 'wifi', 'beer', 'football', 'basketball', 'paper-plane',
//     'american-football', 'boat', 'bluetooth', 'build'];

@Component({
  selector: 'map-by-tag',
  templateUrl: 'map-by-tag.html'
})
export class MapByTagPage {
  map: GoogleMap;
  selectedTag: string = '';
  tags: string[];

  constructor(private googleMapsProvider: GoogleMapsProvider, private loadingCtrl: LoadingController, private tagsProvider : TagsProvider) {
  }

  ionViewDidLoad(): void {
    console.log('[MAP] Loading up map');
    this.loadMap();

  }

  reloadMaps($event) {
    this.selectedTag = $event;
    this.loadMap();
  }

  loadMap() {
    const spinner = this.loadingCtrl.create({ content: "Getting map by tags" });
    spinner.present();
    this.tagsProvider.getAllTags().then(tags => this.tags = tags);
    this.googleMapsProvider.loadMap('mapthing').then((map) => {
      this.map = map;
      this.googleMapsProvider.addMarkersByTag(this.selectedTag);
      spinner.dismissAll();
    });
  }
}
