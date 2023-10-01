import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DeleteMouldComponent } from './delete-mould.component';


describe('DeleteMouldComponent', () => {
  let component: DeleteMouldComponent;
  let fixture: ComponentFixture<DeleteMouldComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteMouldComponent]
    });
    fixture = TestBed.createComponent(DeleteMouldComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
