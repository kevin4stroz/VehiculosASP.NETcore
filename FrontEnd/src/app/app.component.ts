import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'FrontEnd';

  constructor(private router: Router) { }

  ngOnInit() {
  }

  btnClick1() {
    this.router.navigateByUrl('/VehiculosLista');
    console.log("VehiculosLista");
  }

  btnClick2() {
    this.router.navigateByUrl('/VehiculosCrear');
    console.log("VehiculosCrear");
  }
}
