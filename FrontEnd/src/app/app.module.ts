import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// agregar cliente
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material.module';
import { VehiculosListaComponent } from './vehiculos-lista/vehiculos-lista.component';
import { VehiculosCrearComponent } from './vehiculos-crear/vehiculos-crear.component';

@NgModule({
  declarations: [
    AppComponent,
    VehiculosListaComponent,
    VehiculosCrearComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
