import { Vehiculo } from './../Models/Vehiculos';
import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-vehiculos-lista',
  templateUrl: './vehiculos-lista.component.html',
  styleUrls: ['./vehiculos-lista.component.scss'],
})

export class VehiculosListaComponent implements OnInit {

  // agregar tabla
  displayedColumns: string[] = ['ID Vehiculo', 'Modelo', 'Cilindraje', 'Año', 'Marca', "Tipo de vehiculo"];

  dataSource: Vehiculo[] = [];

  isLoadResults = true;

  constructor(
    private api : ApiService
  ) { }

  ngOnInit() {

    this.api.listaVehiculos()
      .subscribe( (res : any) => {
        this.dataSource = res;
        console.log( "getProducts : ", this.dataSource);
        this.isLoadResults = false;
      },
      err => {
          console.log(err);
          this.isLoadResults = false
      }
      );
  }

}
