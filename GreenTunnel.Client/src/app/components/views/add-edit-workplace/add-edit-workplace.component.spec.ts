import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWorkplaceComponent } from './add-edit-workplace.component';

describe('AddEditWorkplaceComponent', () => {
  let component: AddEditWorkplaceComponent;
  let fixture: ComponentFixture<AddEditWorkplaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditWorkplaceComponent]
    });
    fixture = TestBed.createComponent(AddEditWorkplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
