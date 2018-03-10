import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import * as constants from "../../constants";
import { Node } from "../../model/node.model";
import { IncidentModel } from "../../model/incident.model";
import { Status } from "../../model/status.enum";
import { Observable } from "rxjs/Observable";
import { map } from 'rxjs/operators';

/*
  Generated class for the IncidentHttpProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class IncidentHttpProvider {
  constructor(private http: HttpClient) {}

  RecordIncident(incidentModel: IncidentModel): Observable<Status> {
    return this.http
      .post(`${constants.ApiBaseUrl}/submit/recordincident`, incidentModel)
      .pipe(
        map(success => Status.Success, error =>  Status.Error)
      );
  }
}
