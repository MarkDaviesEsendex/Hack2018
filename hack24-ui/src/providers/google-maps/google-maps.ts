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
  markers: Marker[];
  map: GoogleMap;

  constructor(private http: HttpClient, private geolocation: GeolocationProvider) { }

  async loadMap(mapId: string): Promise<GoogleMap> {
    const location = await this.geolocation.getLocation();
    console.log('[MAP] Got location');
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
    await map.one(GoogleMapsEvent.MAP_READY);
    this.map = map;
    return map;
  }

  async addMarkersToMap(): Promise<void> {
    const location = await this.geolocation.getLocation();
    const markerDtOs: any = await this.http.get(
      `${constants.ApiBaseUrl}incidents/nearbyincidents?latitude=${location.coords.latitude}&longitude=${location.coords.longitude
      }&radius=${5000}`)
      .toPromise();

    console.log('[MAP] Done do did the load');
    let markers = [];

    for (const mark of this.markers) {
      mark.remove();
    }

    for (let dto of markerDtOs.result) {
      const m = new MapMarker(dto);
      const mark = {
        title: m.description,
        icon: 'blue',
        animation: 'DROP',
        position: {
          lat: m.latitude,
          lng: m.longitude
        }
      };
      markers.push(mark);
      this.map.addMarker(mark);
      console.log(`[MAP] Done do did the markers: ${markers}`);
    }

    this.markers = markers;
  }

  async addMarkersByTag(tag: string): Promise<void> {
    const location = await this.geolocation.getLocation();
    const markerDtOs: any = await this.http.get(
      `${constants.ApiBaseUrl}incidents/nearby?latitude=${location.coords.latitude}&longitude=${location.coords.longitude}&radius=${5000
      }&tag=${tag}`)
      .toPromise();

    console.log('[MAP] Done do did the load');
    let markers = [];

    for (const mark of this.markers) {
      mark.remove();
    }

    for (let dto of markerDtOs.result) {
      const m = new MapMarker(dto);
      const mark = {
        title: m.description,
        icon: 'blue',
        animation: 'DROP',
        position: {
          lat: m.latitude,
          lng: m.longitude
        }
      };
      markers.push(mark);
      this.map.addMarker(mark);
      console.log(`[MAP] Done do did the markers: ${markers}`);
    }
  }
}
