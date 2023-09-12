import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddEditMouldComponent } from './add-edit-mould.component';



describe('AddEditMouldComponent', () => {
  let component: AddEditMouldComponent;
  let fixture: ComponentFixture<AddEditMouldComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEditMouldComponent]
    });
    fixture = TestBed.createComponent(AddEditMouldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
