import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewWorkspaceComponent } from './view-workspace.component';

describe('ViewWorkspaceComponent', () => {
  let component: ViewWorkspaceComponent;
  let fixture: ComponentFixture<ViewWorkspaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewWorkspaceComponent]
    });
    fixture = TestBed.createComponent(ViewWorkspaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
