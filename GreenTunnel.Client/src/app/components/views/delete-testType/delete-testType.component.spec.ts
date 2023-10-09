import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTestTypeComponent } from './delete-testType.component';

describe('DeleteTestTypeComponent', () => {
  let component: DeleteTestTypeComponent;
  let fixture: ComponentFixture<DeleteTestTypeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteTestTypeComponent]
    });
    fixture = TestBed.createComponent(DeleteTestTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
