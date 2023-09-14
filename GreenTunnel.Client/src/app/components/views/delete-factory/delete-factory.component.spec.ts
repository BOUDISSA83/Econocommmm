import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFactoryComponent } from './delete-factory.component';

describe('DeleteFactoryComponent', () => {
  let component: DeleteFactoryComponent;
  let fixture: ComponentFixture<DeleteFactoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteFactoryComponent]
    });
    fixture = TestBed.createComponent(DeleteFactoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
