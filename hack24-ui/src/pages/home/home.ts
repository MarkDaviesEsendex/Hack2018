import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { ImageProvider } from '../../providers/image/image';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(public navCtrl: NavController, private imageProvider: ImageProvider) { }

  takePicture() {
    this.imageProvider.takePicture();
  }
}
