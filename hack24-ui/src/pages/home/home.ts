import { Component } from '@angular/core';
import { NavController, ModalController, LoadingController } from 'ionic-angular';
import { ImageProvider } from '../../providers/image/image';
import { GeolocationProvider } from '../../providers/geolocation/geolocation';
import { IncidentHttpProvider } from '../../providers/incident-http/incident-http';
import { Node } from '../../model/node.model';
import { IncidentModel } from '../../model/incident.model';
import { Status } from '../../model/status.enum';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  latitude: number;
  longitude: number;
  imageBase64: string;
  description: string;
  status: string = null;

  constructor(private navCtrl: NavController,
              private incidentHttpService: IncidentHttpProvider,
              private imageProvider: ImageProvider,
              private geolocator: GeolocationProvider,
              private loadingCtrl: LoadingController) {}


            async takePicture() {
              this.status = null;
              const location = await this.geolocator.getLocation();
              this.latitude = location.coords.latitude;
              this.longitude = location.coords.longitude;
              this.imageBase64 = await this.imageProvider.takePicture();
            }

            displaySubmit() {
              return this.imageBase64 || (this.description && this.description.length > 0);
            }

            submit() {
              const spinner = this.loadingCtrl.create({ content: "Saving..." });
              spinner.present();

              const position = new Node(this.latitude, this.longitude);
              const strippedImageBase64 = this.imageBase64.startsWith('data:image/jpeg;base64,') ?
                                          this.imageBase64.replace('data:image/jpeg;base64', '') :
                                          this.imageBase64;


              const incidentModel = new IncidentModel(this.imageBase64, position, this.description);
              this.incidentHttpService.RecordIncident(incidentModel, spinner).then((status) => {
                this.status = status.toString();
              });
            }
}
