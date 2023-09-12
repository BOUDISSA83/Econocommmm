import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkspacesListComponent } from './workspaces-list.component';

describe('WorkspacesListComponent', () => {
  let component: WorkspacesListComponent;
  let fixture: ComponentFixture<WorkspacesListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WorkspacesListComponent]
    });
    fixture = TestBed.createComponent(WorkspacesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
