import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditTestComponent } from './add-edit-test.component';

describe('AddEditTestComponent', () => {
  let component: AddEditTestComponent;
  let fixture: ComponentFixture<AddEditTestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditTestComponent]
    });
    fixture = TestBed.createComponent(AddEditTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
