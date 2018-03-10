import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { Camera } from '@ionic-native/camera';
import { Geolocation } from '@ionic-native/geolocation';
import { GoogleMaps } from '@ionic-native/google-maps';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { ImageProvider } from '../providers/image/image';
import { GeolocationProvider } from '../providers/geolocation/geolocation';
import { IncidentHttpProvider } from '../providers/incident-http/incident-http';
import { SpinnerProvider } from '../providers/spinner/spinner';
import { GoogleMapsProvider } from '../providers/google-maps/google-maps';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    ListPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),

  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    ListPage
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
    SpinnerProvider,
    GoogleMaps,
    GoogleMapsProvider
  ]
})
export class AppModule { }
