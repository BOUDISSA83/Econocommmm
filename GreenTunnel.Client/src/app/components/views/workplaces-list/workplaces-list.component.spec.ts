import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkplacesListComponent } from './workplaces-list.component';

describe('WorkplacesListComponent', () => {
  let component: WorkplacesListComponent;
  let fixture: ComponentFixture<WorkplacesListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WorkplacesListComponent]
    });
    fixture = TestBed.createComponent(WorkplacesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
