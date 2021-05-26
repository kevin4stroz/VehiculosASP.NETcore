import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiculosListaComponent } from './vehiculos-lista.component';

describe('VehiculosListaComponent', () => {
  let component: VehiculosListaComponent;
  let fixture: ComponentFixture<VehiculosListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiculosListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiculosListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
