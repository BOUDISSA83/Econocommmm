import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFactoryComponent } from './view-factory.component';

describe('ViewFactoryComponent', () => {
  let component: ViewFactoryComponent;
  let fixture: ComponentFixture<ViewFactoryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewFactoryComponent]
    });
    fixture = TestBed.createComponent(ViewFactoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
