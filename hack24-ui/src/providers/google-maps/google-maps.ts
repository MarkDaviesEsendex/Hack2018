import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  GoogleMaps,
  GoogleMap,
  GoogleMapsEvent,
  GoogleMapOptions,
  CameraPosition,
  MarkerOptions,
  Marker
} from '@ionic-native/google-maps';

import { GeolocationProvider } from '../geolocation/geolocation';
import * as constants from "../../constants";
import { MapMarker } from '../../model/map-marker';

@Injectable()
export class GoogleMapsProvider {

  constructor(private http: HttpClient, private geolocation: GeolocationProvider) { }

  async loadMap(mapId : string) : Promise<GoogleMap> {
    const location = await this.geolocation.getLocation();
    const markers = await this.getMarkers(location.coords);
    const mapOptions: GoogleMapOptions = {
      camera: {
        target: {
          lat: location.coords.latitude,
          lng: location.coords.longitude
        },
        zoom: 18,
        tilt: 30
      }
    };

    const map = GoogleMaps.create(mapId, mapOptions);

    // Wait the MAP_READY before using any methods.
    return map.one(GoogleMapsEvent.MAP_READY)
      .then(() => {
        for (let marker of markers) {
          map.addMarker({
              title: marker.description,
              icon: 'blue',
              animation: 'DROP',
              position: {
                lat: marker.latitude,
                lng: marker.longitude
              }
            })
            .then(mark => {
              mark.on(GoogleMapsEvent.MARKER_CLICK)
                .subscribe(() => {
                  console.log('clicked a marker');
                });
            });
        }
        
        return map;
      });
  }

  private async getMarkers(coords : Coordinates) : Promise<MapMarker[]> {
    const markerDtOs: any = await this.http.get(
      `${constants.ApiBaseUrl}incidents/nearbyincidents?latitude=${coords.latitude}&longitude=${coords.longitude}&radius=${5000}`)
      .toPromise();

    let markers = [];

    for (let dto of markerDtOs.result) {
      markers.push(new MapMarker(dto));
    }

    return markers;
  }
}
