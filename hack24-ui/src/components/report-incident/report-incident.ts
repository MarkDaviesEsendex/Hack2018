import { Component } from '@angular/core';
import { ImageProvider } from '../../providers/image/image';
import { GeolocationProvider } from '../../providers/geolocation/geolocation';
import { ViewController } from 'ionic-angular';
import { IncidentHttpProvider } from '../../providers/incident-http/incident-http';
import { IncidentModel } from '../../model/incident.model';
import { Node } from '../../model/node.model';

/**
 * Generated class for the ReportIncidentComponent component.
 *
 * See https://angular.io/api/core/Component for more info on Angular
 * Components.
 */
@Component({
  selector: 'report-incident',
  templateUrl: 'report-incident.html'
})
export class ReportIncidentComponent {
  latitude: number;
  longitude: number;
  imageBase64: string;
  description: string;

  constructor(private viewCtrl: ViewController,
              private incidentHttpService: IncidentHttpProvider,
              private imageProvider: ImageProvider,
              private geolocator: GeolocationProvider) {
  }

  async takePicture() {
    const location = await this.geolocator.getLocation();
    this.latitude = location.coords.latitude;
    this.longitude = location.coords.longitude;
    this.imageBase64 = await this.imageProvider.takePicture();
    }

  displaySubmit() {
    return this.imageBase64 || (this.description && this.description.length > 0);
  }

  submit() {
    const position = new Node(this.latitude, this.longitude);
    const incidentModel = new IncidentModel(this.imageBase64, position, this.description);
    this.incidentHttpService.RecordIncident(incidentModel).subscribe((status) => {
    });
  }
}
