import { Component } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';
import { ImageProvider } from '../../providers/image/image';
import { GeolocationProvider } from '../../providers/geolocation/geolocation';
import { ReportIncidentComponent } from '../../components/report-incident/report-incident';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {


  constructor(public navCtrl: NavController,

              private modalCtrl: ModalController) { }

  openReportIncidentModal() {
    let reportModal = this.modalCtrl.create(ReportIncidentComponent);
    reportModal.present();

    reportModal.onDidDismiss(() => {

    });
  }
}
