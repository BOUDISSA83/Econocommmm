import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditWorkspaceComponent } from './add-edit-workspace.component';

describe('AddEditWorkspaceComponent', () => {
  let component: AddEditWorkspaceComponent;
  let fixture: ComponentFixture<AddEditWorkspaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditWorkspaceComponent]
    });
    fixture = TestBed.createComponent(AddEditWorkspaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
