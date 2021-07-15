import { Component, ViewChild } from '@angular/core';
import { DonutapiService } from '../donutapi.service';
import { DonutdetailComponent } from '../donutdetail/donutdetail.component';

@Component({
    selector: 'app-listdonuts',
    templateUrl: './listdonuts.component.html',
    styleUrls: ['./listdonuts.component.css']
})
/** listdonuts component*/
export class ListdonutsComponent {

  donutService: DonutapiService = null;
  donuts = null;
  @ViewChild('MyDonutDetail', { static: false }) detailComp: DonutdetailComponent = null;

    /** listdonuts ctor */
  constructor(theDService: DonutapiService) {
    this.donutService = theDService;

    this.donutService.getAllDonuts(donuts => {
      // We don't need the whole object we got back, all we need is the result member
      this.donuts = donuts.results;
      console.log(this.donuts);
    });
  }

  showDetail(id) {
    console.log(id);
    this.donutService.getDonutDetail(id, det_result => {
      console.log(det_result);
      this.detailComp.detail = det_result;
    });
  }
}
