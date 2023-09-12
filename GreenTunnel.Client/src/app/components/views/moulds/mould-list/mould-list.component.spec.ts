import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MouldListComponent } from './mould-list.component';


describe('MouldListComponent', () => {
  let component: MouldListComponent;
  let fixture: ComponentFixture<MouldListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MouldListComponent]
    });
    fixture = TestBed.createComponent(MouldListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
