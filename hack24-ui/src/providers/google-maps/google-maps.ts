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
    console.log('[MAP] Got location');
    const markers = await this.getMarkers(location.coords);
    console.log('[MAP] Got markers');
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
    console.log('[MAP] Reached end before promise');
    console.log(`[MAP] ${JSON.stringify(map)}`);
    // Wait the MAP_READY before using any methods.
    await map.one(GoogleMapsEvent.MAP_READY)
      .then(() => {
        console.log('[MAP] Creating da markerrrrrs');
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
              console.log('[MAP] Created marker ple');
              mark.on(GoogleMapsEvent.MARKER_CLICK)
                .subscribe(() => {
                  console.log('clicked a marker');
                });
            });
        }
      });

      return map;
  }

  private async getMarkers(coords : Coordinates) : Promise<MapMarker[]> {
    const markerDtOs: any = await this.http.get(
      `${constants.ApiBaseUrl}incidents/nearbyincidents?latitude=${coords.latitude}&longitude=${coords.longitude}&radius=${5000}`)
      .toPromise();

    console.log('[MAP] Done do did the load');
    let markers = [];

    for (let dto of markerDtOs.result) {
      markers.push(new MapMarker(dto));
    }

    console.log(`[MAP] Done do did the markers: ${markers}`);
    return markers;
  }
}
