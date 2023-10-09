import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestTypeListComponent } from './testType-list.component';

describe('TestTypeListComponent', () => {
  let component: TestTypeListComponent;
  let fixture: ComponentFixture<TestTypeListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TestTypeListComponent]
    });
    fixture = TestBed.createComponent(TestTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
