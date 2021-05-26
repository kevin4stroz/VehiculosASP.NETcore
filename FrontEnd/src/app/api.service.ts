import { Injectable } from '@angular/core';

import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

import { Vehiculo } from './Models/Vehiculos';

// se agrega apiUr y httpOptions
const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}
const apiUrl = 'http://localhost:5000/Vehiculos';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor( private http: HttpClient ) { }

  listaVehiculos(): Observable<Vehiculo[]> {
    return this.http.get<Vehiculo[]>(apiUrl + '/ListaVehiculos')
      .pipe(
        tap(vehiculo => console.log('fetched Vehiculos')),
        catchError(this.handleError('listaVehiculos', []))
      );
  }

  addVehiculo(vehiculo: Vehiculo): Observable<Vehiculo> {
    return this.http.post<Vehiculo>(apiUrl + '/CrearVehiculo', vehiculo, httpOptions).pipe(
      tap((veh: any) => console.log('added vehiculo :', veh)),
      catchError(this.handleError<Vehiculo>('addVehiculo'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T){
    return (error: any): Observable<T> => {
      console.log(error);
      return of(result as T);
    }
  };
}
