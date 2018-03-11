import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import * as constants from "../../constants";

@Injectable()
export class TagsProvider {

  constructor(public http: HttpClient) {
  }

  async getAllTags(): Promise<string[]> {
    const markerDtOs: any = await this.http.get(
      `${constants.ApiBaseUrl}tags/getalltags`)
      .toPromise();

    console.log('[MAP] Loaded tags');
    let tags = [];

    for (let dto of markerDtOs.result) {
      tags.push(dto.name);
    }

    return tags;
  }

}
