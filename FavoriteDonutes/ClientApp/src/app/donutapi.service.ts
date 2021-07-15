import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// have to put in providers in app.module.ts
@Injectable()
export class DonutapiService {

  username: string = null;

  http: HttpClient = null;
    constructor(theHttp: HttpClient) {
      this.http = theHttp;
  }

  // PRACTICE the callback function
  getAllDonuts(cb) {
    this.http.get<any>('/donut').subscribe(donuts => {
      cb(donuts)
    });
    // alternative way to explore after studying
    // this whole "callback" mechanism
    // this.http.get<any>('/donut').subscribe(cb);
  }

  getDonutDetail(id, cb) {
    this.http.get<any>(`/donut/${id}`).subscribe(detail => {
      cb(detail);
    });
  }

  addFavorite(id) {
    this.http.post<any>(`/favorite/add?username=${this.username}&donut=${id}`, {}).subscribe(results => {
      console.log(results);
    });
  }

  removeFavorite(id) {

  }

  isFavorite(username, id, cb) {

  }
}
