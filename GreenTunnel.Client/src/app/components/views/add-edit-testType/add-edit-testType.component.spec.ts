import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditTestTypeComponent } from './add-edit-testType.component';

describe('AddEditTestTypeComponent', () => {
  let component: AddEditTestTypeComponent;
  let fixture: ComponentFixture<AddEditTestTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditTestTypeComponent]
    });
    fixture = TestBed.createComponent(AddEditTestTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
