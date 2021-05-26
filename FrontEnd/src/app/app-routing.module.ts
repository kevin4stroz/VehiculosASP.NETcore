import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// agregar componentes
import { VehiculosListaComponent } from './vehiculos-lista/vehiculos-lista.component';
import { VehiculosCrearComponent } from './vehiculos-crear/vehiculos-crear.component';


const routes: Routes = [
  {
    path : 'VehiculosLista',
    component: VehiculosListaComponent,
    data: { title : 'Lista de vehiculos'}
  },
  {
    path : 'VehiculosCrear',
    component: VehiculosCrearComponent,
    data: { title : 'Creacion de vehiculos'}
  },
  {
    path : '',
    redirectTo: '/VehiculosLista',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
