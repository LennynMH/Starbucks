import {AfterViewInit, Component, ViewChild} from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: []
})
export class DashboardComponent implements AfterViewInit{

  bloqueo: string;
  @ViewChild('drawer') drawer: any;
  public selectedItem : string = '';

  constructor() {
  
  }

  obtener_localstorage(){
  }

  closeSideNav() {
    if (this.drawer._mode == 'over') {
      this.drawer.close();
    }
  }

  ngAfterViewInit() {
  }
}
