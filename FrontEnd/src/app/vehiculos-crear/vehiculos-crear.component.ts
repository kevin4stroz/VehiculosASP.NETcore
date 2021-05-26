import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import {
  FormControl,
  FormGroupDirective,
  FormBuilder,
  NgForm,
  Validators,
  FormGroup
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';


export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-vehiculos-crear',
  templateUrl: './vehiculos-crear.component.html',
  styleUrls: ['./vehiculos-crear.component.scss']
})
export class VehiculosCrearComponent implements OnInit {

  // datos de formulario
  vehiculoForm: FormGroup;

  vehiculoId:number = null;
  modelo = '';
  cilindraje:number = null;
  agno: number = null;
  marcaId: number = null;
  tipoVehiculoId: number = null;

  isLoadingResults = false;
  matcher = new MyErrorStateMatcher();

  constructor(
    private api: ApiService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.vehiculoForm = this.formBuilder.group({
      'vehiculoId' : 0,
      'modelo' : [null, Validators.required],
      'cilindraje' : [null, Validators.required],
      'agno' : [null, Validators.required],
      'marcaId' : [null, Validators.required],
      'tipoVehiculoId' : [null, Validators.required],
    });
  }

  // funcion on submit del formulario
  onFormSubmit() {
    var vehForm = this.vehiculoForm.value;

    console.log('creando formulario : ', vehForm);

    this.isLoadingResults = true;
    this.api.addVehiculo(vehForm)
      .subscribe( (res: any) => {
        alert('Vehiculo creado');
      },
      (err: any) => {
        console.log(err);
        this.isLoadingResults = false;
        alert('Error Creando vehiculo');
      });
  }

}
