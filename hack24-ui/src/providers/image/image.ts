import { Injectable } from '@angular/core';
import { Camera, CameraOptions } from '@ionic-native/camera';

@Injectable()
export class ImageProvider {
  options: CameraOptions = {
    quality: 75,
    destinationType: this.camera.DestinationType.DATA_URL,
    encodingType: this.camera.EncodingType.JPEG,
    mediaType: this.camera.MediaType.PICTURE
  }

  constructor(private camera: Camera) {}

  takePicture(): Promise<string> {
    return this.camera.getPicture(this.options).then((imageData) => {
      return imageData;
    }, (err) => {
      return err;
    });
  }
}
