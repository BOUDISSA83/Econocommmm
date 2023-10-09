import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTestComponent } from './delete-test.component';

describe('DeleteTestComponent', () => {
  let component: DeleteTestComponent;
  let fixture: ComponentFixture<DeleteTestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteTestComponent]
    });
    fixture = TestBed.createComponent(DeleteTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
