import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteWorkplaceComponent } from './delete-workplace.component';

describe('DeleteWorkplaceComponent', () => {
  let component: DeleteWorkplaceComponent;
  let fixture: ComponentFixture<DeleteWorkplaceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteWorkplaceComponent]
    });
    fixture = TestBed.createComponent(DeleteWorkplaceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
