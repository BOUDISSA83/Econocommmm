import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTestTypeComponent } from './view-testType.component';

describe('ViewTestTypeComponent', () => {
  let component: ViewTestTypeComponent;
  let fixture: ComponentFixture<ViewTestTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewTestTypeComponent]
    });
    fixture = TestBed.createComponent(ViewTestTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
