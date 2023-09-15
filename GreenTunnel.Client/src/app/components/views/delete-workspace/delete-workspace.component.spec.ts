import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteWorkspaceComponent } from './delete-workspace.component';

describe('DeleteWorkspaceComponent', () => {
  let component: DeleteWorkspaceComponent;
  let fixture: ComponentFixture<DeleteWorkspaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteWorkspaceComponent]
    });
    fixture = TestBed.createComponent(DeleteWorkspaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
