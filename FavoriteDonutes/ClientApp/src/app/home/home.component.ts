import { Component } from '@angular/core';
import { User } from 'oidc-client';
import { DonutapiService } from '../donutapi.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  donutService: DonutapiService = null;
  constructor(theDService: DonutapiService) {
    this.donutService = theDService;
  }

  username: string = '';
  clickLogin() {
    this.donutService.username = this.username;
    alert(this.username);
  }
}
