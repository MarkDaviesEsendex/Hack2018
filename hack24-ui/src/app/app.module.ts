import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { Camera } from '@ionic-native/camera';
import { Geolocation } from '@ionic-native/geolocation';
import { GoogleMaps } from '@ionic-native/google-maps';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { ImageProvider } from '../providers/image/image';
import { GeolocationProvider } from '../providers/geolocation/geolocation';
import { IncidentHttpProvider } from '../providers/incident-http/incident-http';
import { HttpClientModule } from '@angular/common/http';
import { GoogleMapsProvider } from '../providers/google-maps/google-maps';
import { MapPage } from '../pages/map/map';
import { MapByTagPage } from '../pages/map-by-tag/map-by-tag';
import { TagsProvider } from '../providers/tags/tags';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    MapPage,
    MapByTagPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpClientModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    MapPage,
    MapByTagPage
  ],
  providers: [
    StatusBar,
    Camera,
    Geolocation,
    SplashScreen,
    { provide: ErrorHandler, useClass: IonicErrorHandler },
    ImageProvider,
    GeolocationProvider,
    IncidentHttpProvider,
    GoogleMaps,
    GoogleMapsProvider,
    TagsProvider
  ]
})
export class AppModule { }
