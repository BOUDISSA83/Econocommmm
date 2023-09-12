import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMouldComponent } from './view-mould.component';

describe('ViewMouldComponent', () => {
  let component: ViewMouldComponent;
  let fixture: ComponentFixture<ViewMouldComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewMouldComponent]
    });
    fixture = TestBed.createComponent(ViewMouldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
