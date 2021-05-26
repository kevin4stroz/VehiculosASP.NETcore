import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiculosCrearComponent } from './vehiculos-crear.component';

describe('VehiculosCrearComponent', () => {
  let component: VehiculosCrearComponent;
  let fixture: ComponentFixture<VehiculosCrearComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiculosCrearComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiculosCrearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
