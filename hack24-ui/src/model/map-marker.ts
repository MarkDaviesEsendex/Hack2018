export class MapMarker {

  constructor(dto: any) {
    this.latitude = dto.latitude;
    this.longitude = dto.longitude;
    this.time = dto.time;
    this.description = dto.description;
    this.positivitySentimentScore = dto.positivitySentimentScore;
    this.imagePath = dto.imagePath;
  }

  latitude : number;
  longitude: number;
  time : string;
  description : string;
  positivitySentimentScore : number;
  imagePath : string;
}
