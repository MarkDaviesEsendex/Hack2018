import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import * as constants from "../../constants";
import { Node } from "../../model/node.model";
import { IncidentModel } from "../../model/incident.model";
import { Status } from "../../model/status.enum";
import { Observable } from "rxjs/Observable";
import { map } from 'rxjs/operators';
import { Loading } from "ionic-angular";

/*
  Generated class for the IncidentHttpProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class IncidentHttpProvider {
  constructor(private http: HttpClient) {}

  RecordIncident(incidentModel: IncidentModel, spinner: Loading): Promise<Status> {
    console.log('[CORDOVA] Beginning request');
    console.log(`[CORDOVA] Request body: ${JSON.stringify(incidentModel.position)}`);
    return new Promise(resolve => {
      this.http
      .post(`${constants.ApiBaseUrl}submit/recordincident`, incidentModel)
      .subscribe(success => {
          console.log(`[CORDOVA] Succeeded, ${JSON.stringify(success)}`);
          spinner.dismissAll();
          return Promise.resolve(Status.Success);
        }, error => {
          console.log(`[CORDOVA] Errored, ${JSON.stringify(error)}`);
          spinner.dismissAll();
          return Promise.reject(Status.Error)
        });
    });

  }
}
