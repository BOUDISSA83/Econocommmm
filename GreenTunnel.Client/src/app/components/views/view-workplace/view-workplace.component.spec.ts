import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewWorkplaceComponent } from './view-workplace.component';

describe('ViewWorkplaceComponent', () => {
  let component: ViewWorkplaceComponent;
  let fixture: ComponentFixture<ViewWorkplaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewWorkplaceComponent]
    });
    fixture = TestBed.createComponent(ViewWorkplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
